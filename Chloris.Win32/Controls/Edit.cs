namespace Chloris.Win32.Controls;

using Chloris.Win32;
using Chloris.Win32.Extends;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;


/// <summary></summary>
public static class Edit
{
    /// <summary></summary>
    private const uint EM_GETLIMITTEXT = 0x00d5;
    /// <summary></summary>
    private const uint WM_SETTEXT = 0x000c;
    /// <summary></summary>
    private const uint WM_GETTEXT = 0x000d;
    /// <summary></summary>
    private const uint WM_GETTEXTLENGTH = 0x000e;

    /// <summary></summary>
    private const uint EM_GETMODIFY = 0x00b8;
    /// <summary></summary>
    private const uint EM_SETMODIFY = 0x00b9;

    /// <summary></summary>
    private const uint EN_SETFOCUS = 0x0100;
    /// <summary></summary>
    private const uint EN_KILLFOCUS = 0x0200;
    /// <summary></summary>
    private const uint EN_CHANGE = 0x0300;
    /// <summary></summary>
    private const uint EN_UPDATE = 0x0400;


    /// <summary>Edit 要素に設定されている最大文字列長の取得</summary>
    public static int GetLimitTextLength(IntPtr hWnd)
    {
        var ret = User32.SendMessage(
                hWnd:   hWnd,
                msg:    EM_GETLIMITTEXT, 
                wParam: IntPtr.Zero,
                lParam: IntPtr.Zero)
            .ToInt32();

        return ret;
    }

    /// <summary>テキスト長の取得</summary>
    public static int GetTextLength(IntPtr hWnd)
    {
        var ret = User32.SendMessage(
                hWnd:   hWnd,
                msg:    WM_GETTEXTLENGTH,
                wParam: IntPtr.Zero,
                lParam: IntPtr.Zero)
            .ToInt32();

        return ret;
    }

    /// <summary>文字列の取得</summary>
    public static string? GetText(IntPtr hWnd)
    {
        var isUnicode = User32.IsWindowUnicode(hWnd);
        var length = GetTextLength(hWnd);
        if(length == 0)
            return null;

        length = (length + 1) * (isUnicode ? 2 : 1);
        var h = Marshal.AllocHGlobal(cb: length);
        if(h == IntPtr.Zero)
            return null;

        var ret = User32.SendMessage(
                hWnd:   hWnd,
                msg:    WM_GETTEXT,
                wParam: new IntPtr(length),
                lParam: h)
            .ToInt32();

#if DEBUG
        Debug.WriteLine($"DEBUG | {nameof(GetText)} WM_GETTEXT {ret}");
#endif
        if(ret == 0)
        {
            Marshal.FreeHGlobal(h);
            throw new Win32Exception(Kernel32.GetLastError());
        }

        var str = isUnicode ? Marshal.PtrToStringUni(h) : Marshal.PtrToStringAnsi(h);
        Marshal.FreeHGlobal(h);

        return str;
    }

    /// <summary>文字列の設定</summary>
    public static int SetText(
            IntPtr hWnd,
            string text)
    {
        var isUnicode = User32.IsWindowUnicode(hWnd);
        var h = isUnicode
            ? Marshal.StringToHGlobalUni(text)
            : Marshal.StringToHGlobalAnsi(text);
        if(h == IntPtr.Zero)
            throw new NullReferenceException();

        var ret = User32.SendMessage(
                hWnd:   hWnd,
                msg:    WM_SETTEXT,
                wParam: IntPtr.Zero,
                lParam: h)
            .ToInt32();

        Marshal.FreeHGlobal(h);

        return ret;
    }


    /// <summary></summary>
    public static int SetModify(
            IntPtr hWnd,
            bool   state)
    {
        var ret = User32.SendMessage(
                hWnd:   hWnd,
                msg:    EM_SETMODIFY,
                wParam: state ? new IntPtr(1) : IntPtr.Zero,
                lParam: IntPtr.Zero)
            .ToInt32();

        return ret;
    }

    /// <summary></summary>
    public static bool GetModify(IntPtr hWnd)
    {
        var ret = User32.SendMessage(
                hWnd:   hWnd,
                msg:    EM_GETMODIFY,
                wParam: IntPtr.Zero,
                lParam: IntPtr.Zero)
            .ToInt32();

#if DEBUG
        Debug.WriteLine($"DEBUG | {ret} = EM_GETMODIFY({hWnd.ToInt():X})");
#endif

        return (ret == 0);
    }

    /// <summary>変更通知の送信</summary>
    public static int SendChangeNotify(
            IntPtr hDest,
            IntPtr hWnd)
    {
        return Win32.Controls.Notify.Send(
                hWndParent: hDest,
                hWnd:       hWnd,
                code:       (int)EN_CHANGE);
    }

    /// <summary>更新通知の送信</summary>
    public static int SendUpdateNotify(
            IntPtr hDest,
            IntPtr hWnd)
    {
        return Win32.Controls.Notify.Send(
                hWndParent: hDest,
                hWnd:       hWnd,
                code:       (int)EN_UPDATE);
    }

    /// <summary>フォーカス通知送信</summary>
    public static int SendSetFocusNotify(
            IntPtr hDest,
            IntPtr hWnd)
    {
        return Win32.Controls.Notify.Send(
                hWndParent: hDest,
                hWnd:       hWnd,
                code:       (int)EN_SETFOCUS);
    }

    /// <summary>フォーカス取消通知送信</summary>
    public static int SendKillFocusNotify(
            IntPtr hDest,
            IntPtr hWnd)
    {
        return Win32.Controls.Notify.Send(
                hWndParent: hDest,
                hWnd:       hWnd,
                code:       (int)EN_KILLFOCUS);
    }
}
