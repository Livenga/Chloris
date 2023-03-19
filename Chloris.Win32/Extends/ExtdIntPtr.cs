namespace Chloris.Win32.Extends;

using System;


/// <summary></summary>
public static class ExtdIntPtr
{
    /// <summary></summary>
    public static long ToInt(this IntPtr p) => IntPtr.Size switch
    {
        8 => p.ToInt64(),
        _ => p.ToInt32(),
    };
}
