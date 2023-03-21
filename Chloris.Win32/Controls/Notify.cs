namespace Chloris.Win32.Controls;

using Chloris.Win32;
using Chloris.Win32.Extends;
using System;
using System.Diagnostics;


/// <summary></summary>
public static class Notify
{
    /// <summary></summary>
    private const uint WM_COMMAND = 0x0111;


    /// <summary></summary>
    public static int Send(
            IntPtr hWndParent,
            IntPtr hWnd,
            int    code)
    {
        var cid = User32.GetDlgCtrlID(hWnd);
#if DEBUG
        Debug.WriteLine($"DEBUG | {nameof(Send)}({hWndParent.ToInt():X}, {hWnd.ToInt():X}, {code} {cid})");
#endif

        return User32.SendMessage(
                (hWndParent != IntPtr.Zero) ? hWndParent : User32.GetParent(hWnd),
                WM_COMMAND/* WM_COMMAND */,
                new IntPtr((code << 16) | (cid & 0xffff)),
                hWnd)
            .ToInt32();
    }


    /// <summary></summary>
    public static int Send(
            IntPtr hWnd,
            int    code)
    {
        return Send(
                User32.GetParent(hWnd),
                hWnd,
                code);
    }
}
