
namespace Chloris.Chrome.CCsv;


/// <summary></summary>
internal sealed class DecryptLoginItem
{
    /// <summary></summary>
    public string ClassName { set; get; } = string.Empty;

    /// <summary></summary>
    public long Id { set; get; } = 0;

    /// <summary></summary>
    public string OriginUrl { set; get; } = string.Empty;

    /// <summary></summary>
    public string? Username { set; get; } = null;

    /// <summary></summary>
    public string? Password { set; get; } = null;

    /// <summary></summary>
    public long? CreatedAt { set; get; } = null;

    /// <summary></summary>
    public long? LastUsedAt { set; get; } = null;
}
