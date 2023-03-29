namespace Chloris.Chrome.Data;


/// <summary></summary>
public sealed class DecryptLogin
{
    /// <summary></summary>
    public long Id => _id;

    /// <summary></summary>
    public string OriginUrl => _originUrl;

    /// <summary></summary>
    public string? Username => _username;

    /// <summary></summary>
    public string Password => _password;

    /// <summary></summary>
    public long CreatedAt => _createdAt;

    /// <summary></summary>
    public long? LastUsedAt => _lastUsedAt;


    private readonly long    _id;
    private readonly string  _originUrl;
    private readonly string? _username;
    private readonly string  _password;
    private readonly long    _createdAt;
    private readonly long?   _lastUsedAt;


    /// <summary></summary>
    public DecryptLogin(
            long    id,
            string  originUrl,
            string? username,
            string  password,
            long    createdAt,
            long?   lastUsedAt)
    {
        _id         = id;
        _originUrl  = originUrl;
        _username   = username;
        _password   = password;
        _createdAt  = createdAt;
        _lastUsedAt = lastUsedAt;
    }
}
