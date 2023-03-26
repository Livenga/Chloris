namespace Chloris.Chrome;

using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;


/// <summary></summary>
internal class Db
{
    /// <summary></summary>
    public string DataSource => _dataSource;

    private readonly string _dataSource;

    /// <summary></summary>
    public Db(string dataSource)
    {
        _dataSource = dataSource;
    }


    /// <summary></summary>
    public async Task<SQLiteConnection> CreateConnectionAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        var conn = new SQLiteConnection();
        var sb = new SQLiteConnectionStringBuilder();

        sb.DataSource = _dataSource;
        sb.Version = 3;
        sb.Add("Mode", "Read");
        sb.Add("Cache", "Default");

        conn.ConnectionString = sb.ToString();
#if DEBUG
        Debug.WriteLine($"DEBUG | SQLite Connection String {conn.ConnectionString}");
#endif

        await conn.OpenAsync(cancellationToken);
        return conn;
    }

    /// <summary></summary>
    public async Task<T> QueryAsync<T>(
            Func<IDbConnection, IDbTransaction, Task<T>> func,
            IsolationLevel il = IsolationLevel.ReadCommitted,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        using var conn = await CreateConnectionAsync(cancellationToken);
        using var trans = conn.BeginTransaction(il);
        try
        {
            return await func(conn, trans);
        }
        catch
        {
            trans.Rollback();
            throw;
        }
    }

    /// <summary></summary>
    public Task ExecuteAsync(
            Func<IDbConnection, IDbTransaction, Task> action,
            IsolationLevel il = IsolationLevel.ReadCommitted,
            CancellationToken cancellationToken = default(CancellationToken)) => throw new NotImplementedException();
}
