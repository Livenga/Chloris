namespace Chloris.Rfid;

public class Config
{
    /// <summary></summary>
    public string Hostname { set; get; } = string.Empty;

    /// <summary></summary>
    public int Port { set; get; } = 5084;

    /// <summary></summary>
    public int Timeout { set; get; } = 3000;

    /// <summary></summary>
    public bool UseTls { set; get; } = false;
}
