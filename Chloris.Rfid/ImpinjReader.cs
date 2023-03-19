namespace Chloris.Rfid;

using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using Org.LLRP.LTK.LLRPV1.Impinj;
using System;


/// <summary></summary>
public class ImpinjReader : AbsLLRPReader
{
    /// <summary></summary>
    public override bool Connect()
    {
        if(IsConnected)
            return true;

        ENUM_ConnectionAttemptStatusType status;
        var isSuccessed = LLRPClient.Open(
                llrp_reader_name: "",
                timeout: 3000,
                status: out status);

        if(! isSuccessed
                || status != ENUM_ConnectionAttemptStatusType.Success)
        {
            return false;
        }

        // TODO 初期化等々

        return true;
    }
}
