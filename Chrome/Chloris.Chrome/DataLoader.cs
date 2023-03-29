namespace Chloris.Chrome;

using Chloris.Chrome.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;


/// <summary></summary>
public sealed class DataLoader : IDisposable
{
    /// <summary></summary>
    public string LocalStatePath => _localStatePath;

    /// <summary></summary>
    public string DataSource => _dataSource;


    private readonly Db _db;
    private readonly string _localStatePath;
    private readonly string _dataSource;
    private readonly string _shadowLocalStatePath;
    private readonly string _shadowDataSource;


    /// <summary></summary>
    public DataLoader(
            string dataSource,
            string localStatePath)
    {
        _shadowLocalStatePath = CreateShadowFile(localStatePath, "ls");
        _shadowDataSource     = CreateShadowFile(dataSource, "ds");

        _dataSource     = dataSource;
        _localStatePath = localStatePath;

        _db = new Db(_shadowDataSource);
    }

    /// <summary></summary>
    private string CreateShadowFile(
            string src,
            string symbol)
    {
        var dst = $"{symbol}_{Guid.NewGuid().ToString()}";
#if DEBUG
        Debug.WriteLine($"DEBUG | {nameof(CreateShadowFile)} Copy {src} => {dst}");
#endif

        File.Copy(
                sourceFileName: src,
                destFileName:   dst,
                overwrite:      true);

        return dst;
    }

    /// <summary></summary>
    private bool TryDeleteFile(string path)
    {
        if(! File.Exists(path))
            return false;

#if DEBUG
        Debug.WriteLine($"DEBUG | {nameof(TryDeleteFile)} {path}");
#endif
        try
        {
            File.Delete(path: path);
            return true;
        }
        catch
        {
            return false;
        }
    }


    /// <summary></summary>
    public async Task<Data.OsCrypt> GetOsCryptAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        using var stream = File.Open(
                _shadowLocalStatePath,
                FileMode.Open,
                FileAccess.Read);

        var jdoc = await JsonDocument.ParseAsync(
                utf8Json: stream,
                cancellationToken: cancellationToken);

        return jdoc.RootElement
            .GetProperty(propertyName: "os_crypt")
            .Deserialize<Data.OsCrypt>(options: null) ?? throw new NullReferenceException();
    }

    /// <summary>指定したテーブルのカラム名を取得</summary>
    public async Task<string[]> GetColumnNamesAsync(
            string tableName,
            bool hasPropertyType = false,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _db.QueryAsync(
                cancellationToken: cancellationToken,
                func: async (conn, trans) => await GetColumnNamesAsync(
                    conn, trans, tableName, hasPropertyType, cancellationToken));
    }

    /// <summary></summary>
    public async Task<IEnumerable<TableInfo>> GetTableInfosAsync(
            string tableName,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _db.QueryAsync(
                cancellationToken: cancellationToken,
                func: async (conn, trans) => await conn.QueryAsync<TableInfo>(
                    command: new CommandDefinition(
                        commandText:
                            @"select
                                *
                            from sqlite_master
                            where
                                tbl_name = @TableName",
                        transaction: trans,
                        parameters: new { TableName = tableName },
                        cancellationToken: cancellationToken)));
    }

    /// <summary></summary>
    public async Task<IEnumerable<string>> GetTableNamesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _db.QueryAsync(
                cancellationToken: cancellationToken,
                func: async (conn, trans) => await conn.QueryAsync<string>(
                    command: new CommandDefinition(
                        commandText:
                            @"select
                                --type || ' ' || tbl_name
                                tbl_name
                            from sqlite_master
                            where
                                type = :Type",
                        transaction: trans,
                        parameters: new { Type = "table" },
                        cancellationToken: cancellationToken)));
    }

    /// <summary></summary>
    public async Task<IEnumerable<Login>> GetLoginsAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _db.QueryAsync(
                cancellationToken: cancellationToken,
                func: async (conn, trans) => await conn.QueryAsync<Data.Login>(
                    command: new CommandDefinition(
                        commandText: @"select * from logins",
                        transaction: trans,
                        parameters: null,
                        cancellationToken: cancellationToken)));
    }

    /// <summary></summary>
    public void Dispose()
    {
        // 複製ファイルの削除
        TryDeleteFile(path: _shadowLocalStatePath);
        TryDeleteFile(path: _shadowDataSource);
    }

    /// <summary></summary>
    private async Task<string[]> GetColumnNamesAsync(
            IDbConnection connection,
            IDbTransaction transaction,
            string tableName,
            bool hasPropertyType = false,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        using var reader = await connection.ExecuteReaderAsync(
                command: new CommandDefinition(
                    commandText: $"select * from {tableName}",
                    transaction: transaction,
                    parameters: null,
                    cancellationToken: cancellationToken));

        var count = reader.FieldCount;

        string[] names = new string[count];
        for(var i = 0; i < count; ++i)
        {
            names[i] = reader.GetName(i: i);
        }

        if(! hasPropertyType)
            return names;

        var maxLength = names.Max(name => name.Length);
        var format = $"{{0,-{maxLength}}} {{1}}";

        return Enumerable.Range(0, count)
            .Select(idx => string.Format(
                        format,
                        names[idx],
                        reader.GetFieldType(i: idx).FullName))
            .ToArray();
    }
}
