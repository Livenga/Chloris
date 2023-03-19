namespace Chloris.Rfid;

using System;


/// <summary></summary>
public interface IUhf : IDisposable
{
    /// <summary></summary>
    bool Connect();

    /// <summary></summary>
    bool Disconnect();
}
