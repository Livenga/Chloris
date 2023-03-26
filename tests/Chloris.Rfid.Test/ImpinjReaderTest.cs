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

    /// <summary></summary>
    [Theory]
    [InlineData("192.168.64.102", 5)]
    public async Task InventoryTestAsync(
            string hostname,
            int    delaySec)
    {
        using var reader = new ImpinjReader();
        reader.Config = new ()
        {
            Hostname = hostname,
            Port     = 5084,
            UseTls   = false,
        };

        reader.ReceiveTag += OnUhfReceiveTag;

        if(! reader.Open())
        {
            throw new Exception();
        }

        reader.Start();

        await Task.Delay(delaySec * 1000);

        reader.Stop();
    }

    /// <summary></summary>
    private void OnUhfReceiveTag(
            Chloris.Rfid.IUhf source,
            Chloris.Rfid.Data.Tag tag)
    {
        _outputHelper.WriteLine($"{tag.Crc ?? -1:X4} {tag.PcBits ?? -1:X4} {tag.Epc} {tag.Tid} {tag.Rssi} {tag.PhaseAngle}");
    }
}
