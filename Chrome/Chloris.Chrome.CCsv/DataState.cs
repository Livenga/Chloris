
namespace Chloris.Chrome.CCsv;

using Chloris.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;


/// <summary></summary>
internal class DataState : IDisposable
{
    /// <summary></summary>
    public string ClassName => _className;

    private readonly string _loginDataPath;
    private readonly string _localStatePath;

    private readonly string _className;

    private DataLoader? _dataLoader = null;

    /// <summary></summary>
    public DataState(
            string loginDataPath,
            string localStatePath)
    {
        _loginDataPath  = loginDataPath;
        _localStatePath = localStatePath;

        /*
        _className = Directory.GetParent(path: _loginDataPath)
            .FullName
            .Split(Path.DirectorySeparatorChar)
            .Last();
          */
        _className = _loginDataPath;
#if DEBUG
        Debug.WriteLine($"DEBUG | ClassName: {_className} ({Path.DirectorySeparatorChar})");
#endif
    }


    private string? _shadowLoginDataPath = null;
    private string? _shadowLocalStatePath = null;

    /// <summary>初期化処理</summary>
    public void Init()
    {
        if(! File.Exists(_loginDataPath)
                || ! File.Exists(_localStatePath))
        {
            throw new FileNotFoundException();
        }

        // データベースの複製
        _shadowLoginDataPath = $"ld_{Guid.NewGuid().ToString()}";
        _shadowLocalStatePath = $"ls_{Guid.NewGuid().ToString()}";

        Console.Error.WriteLine($"Copy {_loginDataPath} -> {_shadowLoginDataPath}");
        File.Copy(
                sourceFileName: _loginDataPath,
                destFileName: _shadowLoginDataPath);

        Console.Error.WriteLine($"Copy {_localStatePath} -> {_shadowLocalStatePath}");
        File.Copy(
                sourceFileName: _localStatePath,
                destFileName: _shadowLocalStatePath);

        _dataLoader = new DataLoader(
                dataSource: _shadowLoginDataPath,
                localStatePath: _shadowLocalStatePath);
    }

    /// <summary></summary>
    public async Task<IEnumerable<DecryptLoginItem>> PasswordDecryptAsync(
            DataProtectionScope protectionScope = DataProtectionScope.CurrentUser,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        if(_dataLoader == null)
            throw new NullReferenceException();

        var logins = (await _dataLoader.GetLoginsAsync(cancellationToken))
            .Where(l => l.PasswordValue?.Length > 0)
            .ToArray();
        if(! logins.Any())
            // TODO Custom Exception
            throw new Exception();

        var items = new List<DecryptLoginItem>();

        var osCrypt = await _dataLoader.GetOsCryptAsync(cancellationToken);
        var encryptedKey = System.Convert.FromBase64String(osCrypt.EncryptedKey);

        foreach(var login in logins)
        {
            try
            {
                var passwordValue = Chloris.Chrome.Cryptor.GoogleChromePasswordValueDecrypt(
                        key: encryptedKey,
                        passwordValue: login.PasswordValue ?? throw new NullReferenceException(),
                        scope: protectionScope);

                var password = System.Text.Encoding.UTF8.GetString(passwordValue);

                items.Add(new DecryptLoginItem()
                        {
                            ClassName  = _className,
                            Id         = login.Id,
                            OriginUrl  = login.OriginUrl,
                            Username   = login.UserNameValue,
                            Password   = password,
                            CreatedAt  = login.DateCreated,
                            LastUsedAt = login.DateLastUsed,
                        });
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine($"\t{ex.GetType().FullName} {ex.Message}");
            }
        }

        return items.ToArray();
    }

    /// <summary></summary>
    public void Dispose()
    {
        TryDelete(_shadowLoginDataPath);
        TryDelete(_shadowLocalStatePath);
    }


    /// <summary></summary>
    private void TryDelete(string? path = null)
    {
        if(path == null || ! File.Exists(path))
            return;
        try
        {
            Console.Error.WriteLine($"Delete {path}");
            File.Delete(path: path);
        }
        catch(Exception ex)
        {
#if DEBUG
            Debug.WriteLine($"ERROR | {ex.GetType().FullName} {ex.Message}");
#endif
        }
    }
}
