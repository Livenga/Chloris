namespace Chloris.Win32.Controls;

using Chloris.Win32;
using System;


/// <summary></summary>
public static class Button
{
    /// <summary></summary>
    private const uint BM_GETCHECK = 0x00f0;
    /// <summary></summary>
    private const uint BM_SETCHECK = 0x00f1;

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
}
