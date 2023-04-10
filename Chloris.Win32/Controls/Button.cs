namespace Chloris.Win32.Controls;

using Chloris.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;


/// <summary></summary>
public static partial class Button
{
    /// <summary></summary>
    private const uint BM_GETCHECK = 0x00f0;

    /// <summary></summary>
    private const uint BM_SETCHECK = 0x00f1;

    /// <summary></summary>
    private const uint BST_CHECKED       = 0x0001;

    /// <summary></summary>
    private const uint BST_INDETERMINATE = 0x0002;

    /// <summary></summary>
    private const uint BST_UNCHECKED     = 0x0000;


    /// <summary></summary>
    public static int GetCheck(IntPtr hWnd)
    {
        return User32.SendMessage(
                hWnd,
                BM_GETCHECK,
                IntPtr.Zero,
                IntPtr.Zero)
            .ToInt32();
    }

    /// <summary></summary>
    public static int SetCheck(
            IntPtr hWnd,
            int    value)
    {
        return User32.SendMessage(hWnd, BM_SETCHECK, new IntPtr(value), IntPtr.Zero)
            .ToInt32();
    }


    /// <summary></summary>
    public static void EnumerationStyle(IntPtr hWnd)
    {
        var attr = BindingFlags.Static | BindingFlags.NonPublic;
        var styleValue = Chloris.Win32.User32.GetWindowLong(hWnd, -16);

        var fields = typeof(Button).GetFields(attr).Where(f => f.Name.Contains("BS_"));
        var maxLength = fields.Max(f => f.Name.Length);
        var format = $"\t{{0,-{maxLength}}} {{1}}";
        Debug.WriteLine($"DEBUG | {typeof(Button).FullName}.{nameof(EnumerationStyle)} {hWnd}");

        foreach(var f in fields)
        {
            var fValue = (long)(f.GetValue(null) ?? throw new NullReferenceException());
            Debug.WriteLine(string.Format(
                        format,
                        f.Name,
                        (fValue & styleValue) == fValue));
        }
    }
}


/// <summary></summary>
public static partial class Button
{
    /// <summary></summary>
    private const long BS_PUSHBUTTON = 0x00000000;

    /// <summary></summary>
    private const long BS_DEFPUSHBUTTON = 0x00000001;

    /// <summary></summary>
    private const long BS_CHECKBOX = 0x00000002;

    /// <summary></summary>
    private const long BS_AUTOCHECKBOX = 0x00000003;

    /// <summary></summary>
    private const long BS_RADIOBUTTON = 0x00000004;

    /// <summary></summary>
    private const long BS_3STATE = 0x00000005;

    /// <summary></summary>
    private const long BS_AUTO3STATE = 0x00000006;

    /// <summary></summary>
    private const long BS_GROUPBOX = 0x00000007;

    /// <summary></summary>
    private const long BS_USERBUTTON = 0x00000008;

    /// <summary></summary>
    private const long BS_AUTORADIOBUTTON = 0x00000009;

    /// <summary></summary>
    private const long BS_OWNERDRAW = 0x0000000B;

    /// <summary></summary>
    private const long BS_SPLITBUTTON = 0x0000000C;

    /// <summary></summary>
    private const long BS_DEFSPLITBUTTON = 0x0000000D;

    /// <summary></summary>
    private const long BS_COMMANDLINK = 0x0000000E;

    /// <summary></summary>
    private const long BS_DEFCOMMANDLINK = 0x0000000F;

    /// <summary></summary>
    private const long BS_TEXT = 0x00000000;

    /// <summary></summary>
    private const long BS_LEFTTEXT = 0x00000020;

    /// <summary></summary>
    private const long BS_RIGHTBUTTON = 0x00000020;

    /// <summary></summary>
    private const long BS_ICON = 0x00000040  ;

    /// <summary></summary>
    private const long BS_BITMAP = 0x00000080;

    /// <summary></summary>
    private const long BS_LEFT = 0x00000100;

    /// <summary></summary>
    private const long BS_RIGHT = 0x00000200;

    /// <summary></summary>
    private const long BS_CENTER = 0x00000300;

    /// <summary></summary>
    private const long BS_TOP = 0x00000400;

    /// <summary></summary>
    private const long BS_BOTTOM = 0x00000800;

    /// <summary></summary>
    private const long BS_VCENTER = 0x00000C00;

    /// <summary></summary>
    private const long BS_PUSHLIKE = 0x00001000;

    /// <summary></summary>
    private const long BS_MULTILINE = 0x00002000;

    /// <summary></summary>
    private const long BS_NOTIFY = 0x00004000;

    /// <summary></summary>
    private const long BS_FLAT = 0x00008000;
}
