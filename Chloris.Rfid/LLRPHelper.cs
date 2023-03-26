namespace Chloris.Rfid;


using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using System;


/// <summary></summary>
public static class LLRPHelper
{
    /// <summary></summary>
    public static void Check(
            MSG_ERROR_MESSAGE? error,
            Message? response)
    {
        PARAM_LLRPStatus? status = error?.LLRPStatus;
        if(status == null)
        {
            status = response?.GetType()
                .GetField(name: "LLRPStatus")?
                .GetValue(response) as PARAM_LLRPStatus;
        }

        if(status == null)
            throw new NullReferenceException();

        if(status.StatusCode != ENUM_StatusCode.M_Success)
            throw new LLRPException(
                    status.StatusCode,
                    status.ErrorDescription ?? string.Empty);
    }
}
