namespace Chloris.Chrome.Data;

using System;
using System.Text.Json.Serialization;


/// <summary></summary>
public sealed class OsCrypt
{
    /// <summary></summary>
    [JsonPropertyName("app_bound_fixed_data")]
    public string AppBoundFixedData { set; get; } = string.Empty;

    /// <summary></summary>
    [JsonPropertyName("encrypted_key")]
    public string EncryptedKey { set; get; } = string.Empty;


    /// <summary></summary>
    public byte[] GetKey()
    {
        var data = System.Convert.FromBase64String(EncryptedKey);
        var key = new byte[data.Length - 5];
        Array.Copy(data, 5, key, 0, key.Length);

        return key;
    }
}
