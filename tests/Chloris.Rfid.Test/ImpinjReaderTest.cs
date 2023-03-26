namespace Chloris.Rfid.Test;

using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;


/// <summary></summary>
public sealed class ImpinjReaderTest
{
    private readonly ITestOutputHelper _outputHelper;

    /// <summary></summary>
    public ImpinjReaderTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }


    /// <summary></summary>
    [Theory]
    [InlineData("192.168.64.102", 5)]
    public async Task OpenTestAsync(
            string hostname,
            int    delaySec)
    {
        using var reader = new ImpinjReader();
        reader.Config = new ()
        {
            Hostname = hostname,
            Port = 5084,
            UseTls = false,
        };

        if(! reader.Open())
        {
            throw new Exception();
        }

        await Task.Delay(delaySec * 1000, CancellationToken.None);
    }
}
