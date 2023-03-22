namespace Chloris.Rfid;

using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using Org.LLRP.LTK.LLRPV1.Impinj;
using System;


/// <summary></summary>
public class ImpinjReader : AbsLLRPReader
{
    /// <summary></summary>
    public override bool Open()
    {
        var ret = base.Open();

        return ret;
    }
}
