namespace Chloris.Rfid;

using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using Org.LLRP.LTK.LLRPV1.Impinj;
using System;
using System.Linq;
using System.Diagnostics;


/// <summary></summary>
public abstract class AbsLLRPReader : IUhf
{
    /// <summary></summary>
    public Config? Config { set; get; } = null;

    /// <summary></summary>
    public bool IsConnected => _client?.IsConnected ?? false;

    /// <summary></summary>
    protected LLRPClient? LLRPClient => _client;


    private LLRPClient? _client = null;
    private bool _isRunning = false;

    /// <summary></summary>
    public event UhfReceiveTagEventHandler? ReceiveTag = null;


    /// <summary></summary>
    public AbsLLRPReader() { }


    /// <summary></summary>
    public virtual bool Open()
    {
        if(IsConnected)
            return true;

        if(Config == null)
            throw new NullReferenceException();

        _client?.Dispose();
        _client = new LLRPClient(Config.Port);

        ENUM_ConnectionAttemptStatusType status;
        var isOpened = _client.Open(
                llrp_reader_name: Config.Hostname,
                timeout:          Config.Timeout,
                useTLS:           Config.UseTls,
                status:           out status);

#if DEBUG
        Debug.WriteLine($"DEBUG | Open({status})");
#endif
        if(! isOpened || status != ENUM_ConnectionAttemptStatusType.Success)
        {
            _client.Dispose();
            _client = null;

            return false;
        }

        ResetToFactoryDefault();

        try
        {
            DeleteROSpec(0);
        }
        catch(Exception ex)
        {
#if DEBUG
            Debug.WriteLine(ex.Message);
#endif
        }

        _client.OnRoAccessReportReceived += OnRoAccessReportReceived;

        return true;
    }


    private const uint _roSpecId = 14150;

    /// <summary></summary>
    public virtual void Start()
    {
        if(_isRunning)
            return;

        try
        {
            AddROSpec(_roSpecId);

            EnableROSpec(_roSpecId);

            StartROSpec(_roSpecId);
            _isRunning = true;
        }
        catch
        {
            _isRunning = false;
            throw;
        }
    }

    /// <summary></summary>
    public virtual void Stop()
    {
        if(! _isRunning)
            return;

        try
        {
            StopROSpec(_roSpecId);
            DisableROSpec(_roSpecId);
            DeleteROSpec(_roSpecId);
        }
        catch
        {
        }
        finally
        {
            _isRunning = false;
        }
    }

    /// <summary></summary>
    public virtual bool Close()
    {
        if(IsConnected)
        {
            try
            {
                StopROSpec();
            } catch { }
            try
            {
                DeleteROSpec();
            } catch { }
        }

        // TODO 例外にする?
        _client?.Dispose();
        _client = null;

        return true;
    }

    /// <summary></summary>
    public void Dispose()
    {
        Close();
    }


    /// <summary></summary>
    protected abstract void AddROSpec(uint roSpecId);

    /// <summary>リーダの初期化</summary>
    protected virtual void ResetToFactoryDefault()
    {
        MSG_SET_READER_CONFIG msg = new ()
        {
            ResetToFactoryDefault = true
        };

        MSG_ERROR_MESSAGE? mErr = null;
        var resp = _client?.SET_READER_CONFIG(msg, out mErr, Config?.Timeout ?? 3000);

        LLRPHelper.Check(mErr, resp);
    }

    /// <summary>ROSpec の有効化</summary>
    protected virtual void EnableROSpec(uint roSpecId)
    {
        MSG_ENABLE_ROSPEC msg = new () { ROSpecID = roSpecId };

        MSG_ERROR_MESSAGE? mErr = null;
        var resp = _client?.ENABLE_ROSPEC(msg, out mErr, Config?.Timeout ?? 3000);

        LLRPHelper.Check(mErr, resp);
    }

    /// <summary>ROSpec の無効化</summary>
    protected virtual void DisableROSpec(uint roSpecId = 0)
    {
        var msg = new MSG_DISABLE_ROSPEC() { ROSpecID = roSpecId };

        MSG_ERROR_MESSAGE? mErr = null;
        var resp = _client?.DISABLE_ROSPEC(msg, out mErr, Config?.Timeout ?? 3000);

        LLRPHelper.Check(mErr, resp);
    }

    /// <summary>ROSpec の削除</summary>
    protected virtual void DeleteROSpec(uint roSpecId = 0)
    {
        var msg = new MSG_DELETE_ROSPEC() { ROSpecID = roSpecId };

        MSG_ERROR_MESSAGE? mErr = null;
        var resp = _client?.DELETE_ROSPEC(msg, out mErr, Config?.Timeout ?? 3000);

        LLRPHelper.Check(mErr, resp);
    }


    /// <summary></summary>
    protected virtual void StartROSpec(uint roSpecId)
    {
        var msg = new MSG_START_ROSPEC() { ROSpecID = roSpecId };

        MSG_ERROR_MESSAGE? mErr = null;
        var resp = _client?.START_ROSPEC(msg, out mErr, Config?.Timeout ?? 3000);

        LLRPHelper.Check(mErr, resp);
    }

    /// <summary></summary>
    protected virtual void StopROSpec(uint roSpecId = 0)
    {
        var msg = new MSG_STOP_ROSPEC() { ROSpecID = roSpecId };

        MSG_ERROR_MESSAGE? mErr = null;
        var resp = _client?.STOP_ROSPEC(msg, out mErr, Config?.Timeout ?? 3000);

        LLRPHelper.Check(mErr, resp);
    }

    /// <summary></summary>
    protected virtual void OnReceiveTag(Chloris.Rfid.Data.Tag tag)
    {
        ReceiveTag?.Invoke(this, tag);
    }

    /// <summary></summary>
    private void OnRoAccessReportReceived(MSG_RO_ACCESS_REPORT mReport)
    {
        if(mReport.TagReportData == null
            || ! mReport.TagReportData.Any())
            return;

        var now = DateTime.Now;

        foreach(var report in mReport.TagReportData)
        {
            ushort? pcBits = null, crc = null;

            for(var i = 0; i < report.AirProtocolTagData.Length; ++i)
            {
                switch(report.AirProtocolTagData[i])
                {
                    case PARAM_C1G2_CRC pCrc:
                        crc = pCrc.CRC;
                        break;
                    case PARAM_C1G2_PC pPc:
                        pcBits = pPc.PC_Bits;
                        break;
                }
            }

            var epc = report.EPCParameter[0] switch
            {
                PARAM_EPC_96  pEpc => pEpc.EPC.ToHexString(),
                PARAM_EPCData pEpc => pEpc.EPC.ToHexString(),
                _ => throw new NotSupportedException(),
            };

            string? tid = null;
            double? phaseAngle = null, rssi = null;
            for(var i = 0; i < report.Custom.Length; ++i)
            {
                switch(report.Custom[i])
                {
                    case PARAM_ImpinjRFPhaseAngle pAngle:
                        phaseAngle = (pAngle.PhaseAngle / 4096d) * 360d;
                        break;

                    case PARAM_ImpinjPeakRSSI pRssi:
                        rssi = pRssi.RSSI / 100d;
                        break;

                    case PARAM_ImpinjSerializedTID pTid:
                        tid = string.Join(string.Empty, pTid.TID.ToHexString().Split(' '));
                        break;
                }
            }
            if(rssi == null)
                rssi = (double)report.PeakRSSI.PeakRSSI;

            var tag = new Rfid.Data.Tag(
                    crc: crc,
                    pcBits: pcBits,
                    tid: tid,
                    epc: epc,
                    antennaId: report.AntennaID.AntennaID,
                    rssi: rssi,
                    phaseAngle: phaseAngle,
                    roSpecId: report.ROSpecID.ROSpecID,
                    accessSpecId: report.AccessSpecID?.AccessSpecID,
                    publishedAt: now);

            OnReceiveTag(tag);
#if DEBUG
            Debug.WriteLine($"DEBUG | {epc}");
#endif
        }
    }
}
