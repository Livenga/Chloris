namespace Chloris.Win32.Controls;

using Chloris.Win32;
using Chloris.Win32.Extends;
using System;
using System.ComponentModel;
using System.Diagnostics;


/// <summary></summary>
public static class Window
{
    /// <summary></summary>
    private const int WM_SETFOCUS = 0x0007;
    /// <summary></summary>
    private const int WM_KILLFOCUS = 0x0008;


    /// <summary></summary>
    public static int SetFocus(IntPtr hWnd)
    {
        var ret = User32.SendMessage(hWnd, WM_SETFOCUS, IntPtr.Zero, IntPtr.Zero)
            .ToInt32();

        var errCode = Kernel32.GetLastError();
        if(errCode != 0)
            throw new Win32Exception(errCode);

        return ret;
    }

    /// <summary></summary>
    public static int KillFocus(IntPtr hWnd)
    {
        var ret = User32.SendMessage(hWnd, WM_KILLFOCUS, IntPtr.Zero, IntPtr.Zero)
            .ToInt32();

        var errCode = Kernel32.GetLastError();
        if(errCode != 0)
            throw new Win32Exception(errCode);

        return ret;
    }
}
