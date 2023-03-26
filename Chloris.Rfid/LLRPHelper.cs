namespace Chloris.Rfid;


using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;


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
            // TODO Custom Exception
            throw new Exception($"{status.StatusCode} {status.ErrorDescription}");
    }
}


/// <summary></summary>
internal static class ExtdObject
{
    /// <summary></summary>
    public static void DisplayProperties(this object o)
    {
        var type = o.GetType();
        var props = type.GetProperties();
        var maxLength = props.Max(p => p.Name.Length);
        var format = $"\t{{0,-{maxLength}}} {{1}}";

        Debug.WriteLine($"DEBUG | Properties {type.FullName}");
        foreach(var prop in props)
        {
            Debug.WriteLine(string.Format(
                        format,
                        prop.Name,
                        prop.GetValue(o)?.ToString() ?? "null"));
        }
    }

    /// <summary></summary>
    public static void DisplayFields(this object o)
    {
        var type = o.GetType();
        var fields = type.GetFields();
        var maxLength = fields.Max(f => f.Name.Length);
        var format = $"\t{{0,-{maxLength}}} {{1}}";

        Debug.WriteLine($"DEBUG | Fields {type.FullName}");
        foreach(var field in fields)
        {
            Debug.WriteLine(string.Format(
                        format,
                        field.Name,
                        field.GetValue(o)?.ToString() ?? "null"));
        }
    }
}
