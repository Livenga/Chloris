namespace Chloris.Rfid;

using System;


/// <summary></summary>
public interface IUhf : IDisposable
{
    /// <summary></summary>
    Config? Config { set; get; }

    /// <summary></summary>
    bool IsConnected { get; }

    /// <summary></summary>
    bool Open();

    /// <summary></summary>
    bool Close();
}
