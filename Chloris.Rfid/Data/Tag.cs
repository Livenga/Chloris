namespace Chloris.Rfid.Data;

using System;
using System.Collections.Generic;
using System.Text;


/// <summary></summary>
public sealed class Tag
{
    public ushort? Crc => _crc;
    public ushort? PcBits => _pcBits;
    public string? Tid => _tid;
    public string Epc => _epc;
    public ushort AntennaId => _antennaId;
    public double? Rssi => _rssi;
    public double? PhaseAngle => _phaseAngle;
    public DateTime PublishedAt => _publishedAt;

    private readonly ushort? _crc;
    private readonly ushort? _pcBits;
    private readonly string? _tid;
    private readonly string _epc;
    private readonly ushort _antennaId;
    private readonly double? _rssi;
    private readonly double? _phaseAngle;
    private readonly DateTime _publishedAt;


    /// <summary></summary>
    public Tag(
            ushort?  crc,
            ushort?  pcBits,
            string?  tid,
            string   epc,
            ushort   antennaId,
            double?  rssi,
            double?  phaseAngle,
            uint     roSpecId,
            uint?    accessSpecId,
            DateTime publishedAt)
    {
        _crc         = crc;
        _pcBits      = pcBits;
        _tid         = tid;
        _epc         = epc;
        _antennaId   = antennaId;
        _rssi        = rssi;
        _phaseAngle  = phaseAngle;
        _publishedAt = publishedAt;
    }
}
