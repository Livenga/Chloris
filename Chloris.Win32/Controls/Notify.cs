namespace Chloris.Win32.Controls;

using Chloris.Win32;
using System;


/// <summary></summary>
public static class Notify
{
    /// <summary></summary>
    public static int Send(
            IntPtr hWndParent,
            IntPtr hWnd,
            int    code)
    {
        var cid = User32.GetDlgCtrlID(hWnd);

        return User32.SendMessage(
                hWndParent,
                0x0111/* WM_COMMAND */,
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
