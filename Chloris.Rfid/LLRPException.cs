namespace Chloris.Rfid;

using Org.LLRP.LTK.LLRPV1;
using System;


/// <summary></summary>
public sealed class LLRPException : Exception
{
    /// <summary></summary>
    public ENUM_StatusCode StatusCode => _statusCode;


    private readonly ENUM_StatusCode _statusCode;


    /// <summary></summary>
    public LLRPException(
            ENUM_StatusCode statusCode,
            string errorDescription) : base(errorDescription)
    {
        _statusCode = statusCode;
    }
}
