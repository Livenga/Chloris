namespace Chloris.Rfid;

using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using System;


/// <summary></summary>
public abstract class AbsLLRPReader : IUhf
{
    /// <summary></summary>
    public bool IsConnected => _client.IsConnected;

    /// <summary></summary>
    protected LLRPClient LLRPClient => _client;


    private readonly LLRPClient _client;


    /// <summary></summary>
    public AbsLLRPReader()
    {
        _client = new LLRPClient();
    }


    /// <summary></summary>
    public abstract bool Connect();


    /// <summary></summary>
    public bool Disconnect()
    {
        // TODO 例外にする?
        if(! IsConnected)
            return true;

        throw new NotImplementedException();
    }

    /// <summary></summary>
    public void Dispose()
    {
        _client.Dispose();
    }
}
