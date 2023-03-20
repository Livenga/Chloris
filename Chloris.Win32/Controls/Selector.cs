namespace Chloris.Win32.Controls;

using Chloris.Win32;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;


/// <summary></summary>
public static class Selector
{
    private const int CB_ERR = -1;

    private const int CBN_SELCHANGE  = 1;
    private const int CBN_SETFOCUS   = 3;
    private const int CBN_KILLFOCUS  = 4;
    private const int CBN_EDITCHANGE = 5;
    private const int CBN_DROPDOWN   = 7;
    private const int CBN_CLOSEUP    = 8;
    private const int CBN_SELECTOK   = 9;
    private const int CBN_CLICKED    = 11;


    /// <summary></summary>
    public static int GetCurrentSelection(IntPtr hWnd)
    {
        var ret = User32.SendMessage(
                hWnd,
                0x0147/* CB_GETCURSEL */,
                IntPtr.Zero,
                IntPtr.Zero)
            .ToInt32();

        return (ret != CB_ERR) ? ret : throw new Win32Exception(Kernel32.GetLastError());
    }

    /// <summary></summary>
    public static int SetCurrentSelection(IntPtr hWnd, int nIndex)
    {
        var ret = User32.SendMessage(
                hWnd,
                0x014e/* CB_SETCURSEL */,
                new IntPtr(nIndex),
                IntPtr.Zero)
            .ToInt32();

        return (ret != CB_ERR) ? ret : throw new Win32Exception(Kernel32.GetLastError());
    }

    /// <summary></summary>
    public static int GetCount(IntPtr hWnd)
    {
        var ret = User32.SendMessage(
                hWnd, 
                0x0146/* CB_GETCOUNT */,
                IntPtr.Zero,
                IntPtr.Zero)
            .ToInt32();

        return (ret != CB_ERR)
            ? ret
            : throw new Win32Exception(Kernel32.GetLastError());
    }

    /// <summary></summary>
    public static string GetText(
            IntPtr hWnd,
            int nIndex)
    {
        var size = GetTextLength(hWnd, nIndex) * (User32.IsWindowUnicode(hWnd) ? 2 : 1);
        var h = Marshal.AllocHGlobal(cb: size);

        var ret = User32.SendMessage(
                hWnd,
                0x0148/* CB_GETLBTEXT */,
                new IntPtr(nIndex),
                h)
            .ToInt32();
        var errCode = Kernel32.GetLastError();

        string? value = null;
        if(ret != CB_ERR)
        {
            value = User32.IsWindowUnicode(hWnd)
                ? Marshal.PtrToStringUni(h)
                : Marshal.PtrToStringAnsi(h);
        }

        Marshal.FreeHGlobal(h);
        h = IntPtr.Zero;

        if(ret == CB_ERR)
            throw new Win32Exception(errCode);

        return value ?? throw new NullReferenceException();
    }

    /// <summary></summary>
    public static int GetTextLength(
            IntPtr hWnd,
            int    nIndex)
    {
        var ret = User32.SendMessage(
                hWnd,
                0x0149/* CB_GETLBTEXTLEN */,
                new IntPtr(nIndex),
                IntPtr.Zero)
            .ToInt32();

        return (ret != CB_ERR) ? ret + 1 : throw new Win32Exception(Kernel32.GetLastError());
    }

    /// <summary></summary>
    public static string[] GetItems(IntPtr hWnd)
    {
        var length = GetCount(hWnd);
        var items = new string[length];

        for(int i = 0; i < length; ++i)
            items[i] = GetText(hWnd, i);

        return items;
    }


    /// <summary></summary>
    public static int NotifySelChange(IntPtr hWndParent, IntPtr hWnd) =>
        Notify.Send(hWndParent, hWnd, CBN_SELCHANGE);

    /// <summary></summary>
    public static int NotifySetFocus(IntPtr hWndParent, IntPtr hWnd) =>
        Notify.Send(hWndParent, hWnd, CBN_SETFOCUS);

    /// <summary></summary>
    public static int NotifyKillFocus(IntPtr hWndParent, IntPtr hWnd) =>
        Notify.Send(hWndParent, hWnd, CBN_KILLFOCUS);

    /// <summary></summary>
    public static int NotifyEditChange(IntPtr hWndParent, IntPtr hWnd) =>
        Notify.Send(hWndParent, hWnd, CBN_EDITCHANGE);

    /// <summary></summary>
    public static int NotifySelectOK(IntPtr hWndParent, IntPtr hWnd) =>
        Notify.Send(hWndParent, hWnd, CBN_SELECTOK);
}
