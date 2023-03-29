namespace Chloris.Chrome.IO;

using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/// <summary></summary>
public static class Csv
{
    /// <summary></summary>
    public static async Task WriteAsync<T>(
            Stream            stream,
            IEnumerable<T>    records,
            Encoding?         encoding = null,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        using var writer = new StreamWriter(stream, encoding ?? Encoding.UTF8);

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Encoding = encoding ?? Encoding.UTF8,
        };

        using var csv = new CsvWriter(writer, config);

        await csv.WriteRecordsAsync(records, cancellationToken);
    }

    /// <summary></summary>
    public static async Task WriteAsync<T>(
            string            path,
            IEnumerable<T>    records,
            Encoding?         encoding = null,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        using var stream = File.Open(
                path,
                File.Exists(path) ? FileMode.Truncate : FileMode.CreateNew,
                FileAccess.Write);

        await WriteAsync<T>(stream, records, encoding, cancellationToken);
    }
}
