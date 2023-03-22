namespace Chloris.Rfid;

using Org.LLRP.LTK.LLRPV1;
using System;


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

        if(! isOpened || status != ENUM_ConnectionAttemptStatusType.Success)
        {
            _client.Dispose();
            _client = null;

            return false;
        }

        return true;
    }


    /// <summary></summary>
    public virtual bool Close()
    {
        // TODO 例外にする?
        if(IsConnected)
            _client?.Close();

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
}
