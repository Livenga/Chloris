namespace Chloris.Chrome;

using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Modes;
using System;
using System.Linq;
using System.Diagnostics;
using System.Security.Cryptography;


/// <summary></summary>
public static class Cryptor
{
    /// <summary></summary>
    public static byte[] GoogleChromePasswordValueDecrypt(
            byte[] key,
            byte[] passwordValue,
            DataProtectionScope scope = DataProtectionScope.CurrentUser)
    {
#if DEBUG
        Debug.WriteLine($"DEBUG | {nameof(GoogleChromePasswordValueDecrypt)}");
        Debug.WriteLine($"\tkey: {BytesToHex(key)}");
        Debug.WriteLine($"\tpasswordValue: {BytesToHex(passwordValue)}");
        Debug.WriteLine($"\tscope: {scope}");
#endif
        key = ByteTake(key, 5, key.Length - 5);

        passwordValue = ByteTake(passwordValue, 3, passwordValue.Length - 3);
        var iv = ByteTake(passwordValue, 0, 12);
        var encryptedValue = ByteTake(passwordValue, 12, passwordValue.Length - 12);

        return Aes256GcmDecrypt(
                encryptedValue: encryptedValue,
                key: ProtectedData.Unprotect(key, null, scope),
                iv: iv);
    }

    /// <summary></summary>
    public static byte[] Aes256GcmDecrypt(
            byte[] encryptedValue,
            byte[] key,
            byte[] iv)
    {
        var cipher = new GcmBlockCipher(new AesEngine());
        var pAead = new AeadParameters(new KeyParameter(key), 128, iv, null);

#if DEBUG
        Debug.WriteLine($"  e | ({encryptedValue.Length}) {BytesToHex(encryptedValue)}");
        Debug.WriteLine($"key | ({key.Length}) {BytesToHex(key)}");
        Debug.WriteLine($" iv | ({iv.Length}) {BytesToHex(iv)}");
#endif
        cipher.Init(
                forEncryption: false,
                parameters:    pAead);

        Debug.WriteLine($"DEBUG | Mac Length {cipher.GetMac().Length} ({encryptedValue.Length})");

        var plainLength = cipher.GetOutputSize(len: encryptedValue.Length);
        var ret = new byte[plainLength];

        var processedLength = cipher.ProcessBytes(encryptedValue, 0, encryptedValue.Length, ret, 0);
#if DEBUG
        Debug.WriteLine($"DEBUG | LENGTH plain: {plainLength}, processed: {processedLength}");
#endif
        var finalLength = cipher.DoFinal(ret, processedLength);
#if DEBUG
        Debug.WriteLine($"DEBUG | DoFinal = {finalLength} {BytesToHex(ret)}");
#endif

        return ret;
    }

    /// <summary></summary>
    private static string BytesToHex(byte[] buffer, string s = "-") =>
        string.Join(s, buffer.Select(b => $"{b:X2}"));

    /// <summary></summary>
    private static byte[] ByteTake(byte[] src, int offset, int length)
    {
        var ret = new byte[length];
        Array.Copy(src, offset, ret, 0, length);

        return ret;
    }
}
