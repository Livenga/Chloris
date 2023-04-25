namespace Chloris;

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/// <summary></summary>
public static class AesCryptor
{
    private static readonly Guid _iv = Guid.Parse(input: "93676dfd-388f-42ed-99d6-2031462f244b");

    /// <summary></summary>
    public static async Task<string> EncryptToBase64StringAsync(
            string key,
            string plainText,
            Encoding? encoding = null,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        return System.Convert.ToBase64String(await EncryptAsync(key, plainText, encoding, cancellationToken));
    }

    /// <summary></summary>
    public static async Task<byte[]> EncryptAsync(
            string key,
            string plainText,
            Encoding? encoding = null,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        using var transform = CreateTransform(
                key:         AdjustZeroPadding((encoding ?? Encoding.UTF8).GetBytes(key), 32),
                iv:          _iv.ToByteArray(),
                isEncryptor: true);

        using var m = new MemoryStream();
        using(var stream = new CryptoStream(m, transform, CryptoStreamMode.Write))
        {
            var buffer = (encoding ?? Encoding.UTF8).GetBytes(plainText);

            await stream.WriteAsync(buffer, 0, buffer.Length, cancellationToken);
            await stream.FlushAsync(cancellationToken);
        }

        return m.ToArray();
    }

    /// <summary></summary>
    public static async Task<string> DecryptFromBase64StringAsync(
            string key,
            string encryptedValue,
            Encoding? encoding = null,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        var buffer = await DecryptAsync(
                key: key,
                value: System.Convert.FromBase64String(encryptedValue),
                encoding: encoding,
                cancellationToken: cancellationToken);

        return (encoding ?? Encoding.UTF8).GetString(buffer);
    }

    /// <summary></summary>
    public static async Task<byte[]> DecryptAsync(
            string key,
            byte[] value,
            Encoding? encoding = null,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        using var transform = CreateTransform(
                key:         AdjustZeroPadding((encoding ?? Encoding.UTF8).GetBytes(key), 32),
                iv:          _iv.ToByteArray(),
                isEncryptor: false);

        using var msDst = new MemoryStream();

        using(var msSrc = new MemoryStream(value))
        using(var stream = new CryptoStream(msSrc, transform, CryptoStreamMode.Read))
        {
            int size;
            var buffer = new byte[1024];
            while((size = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
            {
                await msDst.WriteAsync(buffer, 0, size, cancellationToken);
                await msDst.FlushAsync(cancellationToken);
            }
        }

        return msDst.ToArray();
    }


    /// <summary></summary>
    private static byte[] AdjustZeroPadding(
            byte[] buffer,
            int size)
    {
        // XXX 想定サイズを超過した場合は例外を発生させるかどうか
        var ret = new byte[size];
        var length = (buffer.Length > size) ? size : buffer.Length;

        Array.Copy(buffer, 0, ret, 0, length);

        return ret;
    }

    /// <summary></summary>
    private static ICryptoTransform CreateTransform(
            byte[] key,
            byte[] iv,
            bool   isEncryptor = false)
    {
#if DEBUG
        Func<byte[], string> byteArrayToString = bf => string.Join("-", bf.Select(b => $"{b:X2}"));
        Debug.WriteLine($"DEBUG | Key[{key.Length}]\t{byteArrayToString(key)}");
        Debug.WriteLine($"DEBUG |  IV[{iv.Length}]\t{byteArrayToString(iv)}");
#endif
        var aes = Aes.Create();
        aes.KeySize = 256;
        aes.BlockSize = 128;
        aes.Key  = key;
        aes.IV   = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        return isEncryptor
            ? aes.CreateEncryptor(aes.Key, aes.IV)
            : aes.CreateDecryptor(aes.Key, aes.IV);
    }
}
