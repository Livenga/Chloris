namespace Chloris.Chrome.Test;

using Chloris.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal static class ExtdObject
{
    /// <summary></summary>
    internal static void DisplayPropoerties(this object o)
    {
        var type = o.GetType();
        var props = type.GetProperties();

        var maxLength = props.Max(p => p.Name.Length);
        var format = $"\t{{0,-{maxLength}}} {{1}}";

        Debug.WriteLine($"{type.FullName}");
        foreach(var prop in props)
        {
            try
            {
                Debug.WriteLine(string.Format(
                            format,
                            prop.Name,
                            prop.GetValue(o)?.ToString() ?? "null"));
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"\t{prop.Name} {ex.Message}");
            }
        }
    }
}

/// <summary></summary>
[TestClass]
public class DataLoaderTest
{
    private readonly DataLoader _dataLoader;
    private readonly string _dataSource;

    /// <summary></summary>
    public DataLoaderTest()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

        var rootPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Projects",
                "Chloris",
                "Chrome");

        _dataSource = Path.Combine(rootPath, "ChromeLoginData.db");
        var localStatePath = Path.Combine(rootPath, "LocalState.json");

        _dataLoader = new DataLoader(_dataSource, localStatePath);
    }

    /// <summary></summary>
    [TestMethod]
    public async Task GetOsCryptAsync()
    {
        var osCrypt = await _dataLoader.GetOsCryptAsync(CancellationToken.None);

        Console.WriteLine($"{osCrypt.AppBoundFixedData}");
        Console.WriteLine($"{osCrypt.EncryptedKey}");
    }

    /// <summary></summary>
    [TestMethod]
    public async Task GetAllTableColumnsAsync()
    {
        var tableNames = await _dataLoader.GetTableNamesAsync();
        foreach(var tn in tableNames)
        {
            Console.WriteLine(tn);
            foreach(var columnName in await _dataLoader.GetColumnNamesAsync(tn, true))
            {
                Console.WriteLine($"\t{columnName}");
            }
            Console.WriteLine();
        }
    }

    /// <summary></summary>
    [TestMethod]
    public async Task GetTableNamesAsyncTest()
    {
        var tableNames = await _dataLoader.GetTableNamesAsync();
        foreach(var tableName in tableNames)
        {
            Console.WriteLine(tableName);
        }
    }

    /// <summary></summary>
    [TestMethod]
    [DataRow("logins")]
    [DataRow("password_notes")]
    public async Task GetTableInfosAsync(string tableName)
    {
        var columns = await _dataLoader.GetTableInfosAsync(tableName);
        Console.WriteLine(tableName);
        foreach(var column in columns)
        {
            Console.WriteLine($"\t{column.Name} {column.Type}");
        }
    }

    /// <summary></summary>
    [TestMethod]
    [DataRow("sqlite_master", true)]
    public async Task GetColumnNamesAsyncTest(string tableName, bool hasPropertyType)
    {
        var columnNames = await _dataLoader.GetColumnNamesAsync(tableName, hasPropertyType);
        Console.WriteLine(tableName);
        foreach(var columnName in columnNames)
        {
            Console.WriteLine($"\t{columnName}");
        }
    }

    /// <summary></summary>
    [TestMethod]
    public async Task GetLoginsAsyncTest()
    {
        // 253402300799999
        // 13303233478671295
        var logins = await _dataLoader.GetLoginsAsync(CancellationToken.None);
        foreach(var login in logins)
        {
            login.DisplayPropoerties();

            if(login.PasswordValue != null)
            {
                var v10 = System.Text.Encoding.UTF8.GetString(BytesTake(login.PasswordValue, 3));
                Debug.WriteLine($"DEBUG | {v10}");
            }
            //Debug.WriteLine(string.Empty);
            //var createdAt = DateTimeOffset.FromUnixTimeMilliseconds(login.DateCreated).DateTime;
            //var createdAt = new DateTime(login.DateCreated);
            //Debug.WriteLine($"\t{login.PasswordValue?.Length ?? -1}");
            //Debug.WriteLine($"\t{createdAt.ToString("yyyy-MM-ddTHH:mm:ss")}");
            //Debug.WriteLine(string.Empty);
        }
    }

    /// <summary></summary>
    private byte[] BytesTake(byte[] source, int length)
    {
        var ret = new byte[length];
        Array.Copy(source, 0, ret, 0, length);

        return ret;
    }
}
