namespace Chloris.Extends;

using System;
using System.Diagnostics;
using System.Linq;


/// <summary></summary>
public static class ExtdObject
{
    /// <summary></summary>
    public static void DisplayProperties(
            this object o,
            string defaultValue = "null")
    {
        var props = o.GetType().GetProperties();
        var maxLength = props.Max(p => p.Name.Length);
        var format = $"\t{{0,-{maxLength}}} {{1}}";

        Debug.WriteLine($"DEBUG | {o.GetType().FullName}");
        foreach(var prop in props)
        {
            try
            {
                Debug.WriteLine(string.Format(
                            format,
                            prop.Name,
                            prop.GetValue(o)?.ToString() ?? defaultValue));
            }
            catch { }
        }
    }
}
