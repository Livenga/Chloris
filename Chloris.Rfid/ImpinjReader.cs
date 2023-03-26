namespace Chloris.Rfid;

using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using Org.LLRP.LTK.LLRPV1.Impinj;
using System;
using System.Diagnostics;


/// <summary></summary>
public class ImpinjReader : AbsLLRPReader
{
    /// <summary></summary>
    public string? ModelName => _modelName;

    /// <summary></summary>
    public string? SerialNumber => _serialNumber;

    /// <summary></summary>
    public string? SoftwareVersion => _softwareVersion;

    /// <summary></summary>
    public string? FirmwareVersion => _firmwareVersion;

    /// <summary></summary>
    public ushort AntennaCount => _antennaCount;


    private string? _modelName = null;
    private string? _serialNumber = null;
    private string? _softwareVersion = null;
    private string? _firmwareVersion = null;

    private ushort _antennaCount = 4;


    /// <summary></summary>
    public override bool Open()
    {
        var ret = base.Open();

        EnableImpinjExtensions();
        SetImpinjSettings();
        GetReaderConfig();

#if DEBUG
        Debug.WriteLine($"DEBUG | Device Info {_modelName ?? string.Empty} {_serialNumber}");
        Debug.WriteLine($"\tSoftware version: {_softwareVersion}");
        Debug.WriteLine($"\tFirmware version: {_firmwareVersion}");
#endif

        if(LLRPClient != null)
        {
            LLRPClient.OnKeepAlive += OnKeepAlive;
        }

        // TODO 
        return ret;
    }

    /// <summary></summary>
    protected override void AddROSpec(uint roSpecId)
    {
        var msg = new MSG_ADD_ROSPEC();
        var pROSpec = new PARAM_ROSpec()
        {
            CurrentState = ENUM_ROSpecState.Disabled,
            Priority = 0,
            ROSpecID = roSpecId,
        };
        msg.ROSpec = pROSpec;


        // Boundary Spec
        var pBoundary = new PARAM_ROBoundarySpec();
        pROSpec.ROBoundarySpec = pBoundary;
        pBoundary.ROSpecStartTrigger = new ();
        pBoundary.ROSpecStartTrigger.ROSpecStartTriggerType = ENUM_ROSpecStartTriggerType.Null;
        pBoundary.ROSpecStopTrigger = new ();
        pBoundary.ROSpecStopTrigger.ROSpecStopTriggerType = ENUM_ROSpecStopTriggerType.Null;


        //
        var pReport = new PARAM_ROReportSpec();
        pROSpec.ROReportSpec = pReport;
        pReport.N = 1;
        pReport.ROReportTrigger = ENUM_ROReportTriggerType.Upon_N_Tags_Or_End_Of_ROSpec;

        //
        var pSelector = new PARAM_TagReportContentSelector();
        pReport.TagReportContentSelector = pSelector;
        pSelector.EnablePeakRSSI = true;
        pSelector.EnableROSpecID = true;
        pSelector.EnableAntennaID = true;
        pSelector.EnableSpecIndex = false;
        pSelector.EnableAccessSpecID = true;
        pSelector.EnableChannelIndex = true;
        pSelector.EnableTagSeenCount = false;
        pSelector.EnableLastSeenTimestamp = false;
        pSelector.EnableFirstSeenTimestamp = false;
        pSelector.EnableInventoryParameterSpecID = true;

        //
        var pImpinjSelector = new PARAM_ImpinjTagReportContentSelector();
        pReport.Custom.Add(pImpinjSelector);

        pImpinjSelector.ImpinjEnablePeakRSSI = new () { PeakRSSIMode = ENUM_ImpinjPeakRSSIMode.Enabled };
        pImpinjSelector.ImpinjEnableRFPhaseAngle = new () { RFPhaseAngleMode = ENUM_ImpinjRFPhaseAngleMode.Enabled };
        pImpinjSelector.ImpinjEnableSerializedTID = new () { SerializedTIDMode = ENUM_ImpinjSerializedTIDMode.Enabled };

        //
        pSelector.AirProtocolEPCMemorySelector = new ();
        var mMemorySelector = new PARAM_C1G2EPCMemorySelector() { EnableCRC = true, EnablePCBits = true };
        pSelector.AirProtocolEPCMemorySelector.Add(mMemorySelector);


        pROSpec.SpecParameter = new ();
        var pAI = new PARAM_AISpec();
        pROSpec.SpecParameter.Add(pAI);
        // TODO 使用するアンテナと個々の設定
        pAI.AntennaIDs.Add(0);

        pAI.AISpecStopTrigger = new ();
        pAI.AISpecStopTrigger.AISpecStopTriggerType = ENUM_AISpecStopTriggerType.Null;

        pAI.InventoryParameterSpec = new PARAM_InventoryParameterSpec[1];
        var pInventory = new PARAM_InventoryParameterSpec();
        pAI.InventoryParameterSpec[0] = pInventory;

        pInventory.ProtocolID = ENUM_AirProtocols.EPCGlobalClass1Gen2;
        pInventory.InventoryParameterSpecID = 1234;
        pInventory.AntennaConfiguration = new PARAM_AntennaConfiguration[_antennaCount];

        for(var i = 0; i < _antennaCount; ++i)
        {
            ushort aid = (ushort)(i + 1);
            var pAc = new PARAM_AntennaConfiguration() { AntennaID = aid };
            pInventory.AntennaConfiguration[i] = pAc;

            pAc.RFReceiver = new ();
            pAc.RFReceiver.ReceiverSensitivity = 1;

            pAc.RFTransmitter = new ();
            pAc.RFTransmitter.TransmitPower = 81;
            pAc.RFTransmitter.ChannelIndex = 1;
        }


        MSG_ERROR_MESSAGE? mErr = null;
        var resp = LLRPClient?.ADD_ROSPEC(msg, out mErr, Config?.Timeout ?? 3000);
        LLRPHelper.Check(mErr, resp);
    }

    /// <summary></summary>
    private void EnableImpinjExtensions()
    {
        var msg = new MSG_IMPINJ_ENABLE_EXTENSIONS();

        MSG_ERROR_MESSAGE? mErr = null;
        var resp = LLRPClient?.CUSTOM_MESSAGE(msg, out mErr, Config?.Timeout ?? 3000);

        LLRPHelper.Check(mErr, resp);
    }

    /// <summary></summary>
    private void SetImpinjSettings()
    {
        MSG_SET_READER_CONFIG msg = new ();
        msg.KeepaliveSpec = new ();
        msg.KeepaliveSpec.KeepaliveTriggerType = ENUM_KeepaliveTriggerType.Periodic;
        msg.KeepaliveSpec.PeriodicTriggerValue = 3000;

        var pLinkMonitor = new PARAM_ImpinjLinkMonitorConfiguration();
        pLinkMonitor.LinkMonitorMode = ENUM_ImpinjLinkMonitorMode.Enabled;
        pLinkMonitor.LinkDownThreshold = 3;

        msg.Custom.Add(pLinkMonitor);

        MSG_ERROR_MESSAGE? mErr = null;
        var resp = LLRPClient?.SET_READER_CONFIG(msg, out mErr, Config?.Timeout ?? 3000);

        LLRPHelper.Check(mErr, resp);
    }

    /// <summary></summary>
    private void GetReaderConfig()
    {
        var msg = new MSG_GET_READER_CAPABILITIES();
        msg.RequestedData = ENUM_GetReaderCapabilitiesRequestedData.All;

        MSG_ERROR_MESSAGE? mErr = null;
        var resp = LLRPClient?.GET_READER_CAPABILITIES(msg, out mErr, Config?.Timeout ?? 3000);

        LLRPHelper.Check(mErr, resp);

        if(resp != null)
        {
            _antennaCount = resp.GeneralDeviceCapabilities.MaxNumberOfAntennaSupported;
            for(var i = 0; i < resp.Custom.Length; ++i)
            {
                var custom = resp.Custom[i];

                Debug.WriteLine($"DEBUG | {custom.GetType().FullName}");
                switch(custom)
                {
                    case PARAM_ImpinjDetailedVersion pVersion:
                        _modelName       = pVersion.ModelName;
                        _serialNumber    = pVersion.SerialNumber;
                        _softwareVersion = pVersion.SoftwareVersion;
                        _firmwareVersion = pVersion.FirmwareVersion;
                        break;
                }
            }
        }
    }

    /// <summary></summary>
    private void OnKeepAlive(MSG_KEEPALIVE msg)
    {
#if DEBUG
        Debug.WriteLine($"DEBUG | {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {msg.MSG_ID} {msg.MSG_TYPE}");
#endif

        MSG_KEEPALIVE_ACK mAck = new ();
        mAck.MSG_ID = msg.MSG_ID;

        MSG_ERROR_MESSAGE? mErr = null;
        LLRPClient?.KEEPALIVE_ACK(mAck, out mErr, Config?.Timeout ?? 3000);
    }
}
