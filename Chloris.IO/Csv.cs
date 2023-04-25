namespace Chloris.IO;

using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/// <summary></summary>
public static class Csv
{
    /// <summary></summary>
    public static async Task<IEnumerable<T>> ReadAsync<T>(
            Stream stream,
            Encoding? encoding = null,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        using var reader = new StreamReader(stream, encoding ?? Encoding.UTF8);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        return await csv.GetRecordsAsync<T>(cancellationToken)
            .ToArrayAsync(cancellationToken);
    }

    /// <summary></summary>
    public static async Task<IEnumerable<T>> ReadAsync<T>(
            string path,
            Encoding? encoding = null,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        using var stream = File.Open(path, FileMode.Open, FileAccess.Read);
        return await ReadAsync<T>(stream, encoding, cancellationToken);
    }

    /// <summary></summary>
    public static async Task WriteAsync<T>(
            Stream stream,
            IEnumerable<T> records,
            Encoding? encoding = null,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        using var writer = new StreamWriter(stream, encoding ?? Encoding.UTF8);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

        await csv.WriteRecordsAsync<T>(records, cancellationToken);
    }

    /// <summary></summary>
    public static async Task WriteAsync<T>(
            string path,
            IEnumerable<T> records,
            Encoding? encoding = null,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        using var stream = File.Open(
                path,
                File.Exists(path) ? FileMode.Truncate : FileMode.CreateNew,
                FileAccess.Write);

        await WriteAsync<T>(stream, records, encoding, cancellationToken);
    }
}
