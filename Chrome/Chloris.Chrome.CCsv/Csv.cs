namespace Chloris.Chrome.CCsv;

using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


/// <summary></summary>
internal static class Csv
{
    /// <summary></summary>
    public static async Task WriteAsync<T>(
            Stream stream,
            IEnumerable<T> records,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        using var writer = new StreamWriter(stream);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

        await csv.WriteRecordsAsync(records, cancellationToken);
    }

    /// <summary></summary>
    public static async Task WriteAsync<T>(
            string path,
            IEnumerable<T> records,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        using var stream = File.Open(
                path,
                File.Exists(path) ? FileMode.Truncate : FileMode.CreateNew,
                FileAccess.Write);

        await WriteAsync<T>(stream, records, cancellationToken);
    }
}
