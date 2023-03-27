namespace Chloris.Win32;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


/// <summary></summary>
public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);


/// <summary></summary>
public static class User32
{
    private const string L = "user32.dll";


    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetDesktopWindow), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern IntPtr GetDesktopWindow();


    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(EnumWindows), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(EnumChildWindows), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool EnumChildWindows(
            [In]IntPtr hWndParent,
            [In]EnumWindowsProc lpEnumFunc,
            [In]IntPtr lParam);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetWindow), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern IntPtr GetWindow([In]IntPtr hWnd, [In]uint uCmd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetAncestor), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    public static extern IntPtr GetAncestor([In]IntPtr hWnd, [In]uint gaFlags);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetParent), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    public static extern IntPtr GetParent(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(WindowFromPhysicalPoint), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    public static extern IntPtr WindowFromPhysicalPoint([In]Point point);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetCursorPos), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    public static extern bool GetCursorPos([Out]out Point lpPoint);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetWindowModuleFileNameA), SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false)]
    public static extern uint GetWindowModuleFileNameA([In]IntPtr hWnd, [Out]StringBuilder pszFileName, [In]uint cchFileNameMax);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetWindowModuleFileNameW), SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = false)]
    public static extern uint GetWindowModuleFileNameW([In]IntPtr hWnd, [Out]StringBuilder pszFileName, [In]uint cchFileNameMax);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(ShowCaret), SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false)]
    public static extern bool ShowCaret(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(DestroyCaret), SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false)]
    public static extern bool DestroyCaret();

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(IsWindow), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool IsWindow(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(IsChild), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool IsChild(IntPtr hWndParent, IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(IsWindowUnicode), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool IsWindowUnicode(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(IsWindowVisible), SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool IsWindowVisible(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(ShowWindow), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetWindowTextLengthA), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Ansi)]
    public static extern int GetWindowTextLengthA(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetWindowTextLengthW), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Unicode)]
    public static extern int GetWindowTextLengthW(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetWindowTextA), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Ansi)]
    public static extern int GetWindowTextA([In]IntPtr hWnd, [Out]StringBuilder lpString, [In]int nMaxCount);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetWindowTextW), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Unicode)]
    public static extern int GetWindowTextW([In]IntPtr hWnd, [Out]StringBuilder lpString, [In]int nMaxCount);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetWindowThreadProcessId), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int GetWindowThreadProcessId([In]IntPtr hWnd, [Out]out int lpdwProcessId);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetClassNameA), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    public static extern int GetClassNameA([In]IntPtr hWnd, [Out]StringBuilder lpClassName, [In]int nMaxCount);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetClassNameW), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    public static extern int GetClassNameW([In]IntPtr hWnd, [Out]StringBuilder lpClassName, [In]int nMaxCount);


    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetDlgCtrlID), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int GetDlgCtrlID([In]IntPtr hWnd);


    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(EnableWindow), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(IsWindowEnabled), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    public static extern bool IsWindowEnabled(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(SendMessageA), ExactSpelling = false, SetLastError = true, CharSet = CharSet.Ansi)]
    public static extern IntPtr SendMessageA(
            [In]IntPtr hWnd,
            [In]uint msg,
            [In,Out]IntPtr wParam,
            [In,Out]IntPtr lParam);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(SendMessageW), ExactSpelling = false, SetLastError = true, CharSet = CharSet.Ansi)]
    public static extern IntPtr SendMessageW(
            [In]IntPtr hWnd,
            [In]uint msg,
            [In,Out]IntPtr wParam,
            [In,Out]IntPtr lParam);


    /// <summary></summary>
    public static int GetWindowTextLength(IntPtr hWnd) => IsWindowUnicode(hWnd)
        ? GetWindowTextLengthW(hWnd)
        : GetWindowTextLengthA(hWnd);

    /// <summary></summary>
    public static string? GetWindowText(IntPtr hWnd)
    {
        var length = GetWindowTextLength(hWnd);
        if(length < 0)
            return null;

        var sb = new StringBuilder(length + 1);
        var ret = IsWindowUnicode(hWnd)
            ? GetWindowTextW(hWnd, sb, length + 1)
            : GetWindowTextA(hWnd, sb, length + 1);
#if DEBUG
        Debug.WriteLine($"DEBUG | {ret}:GetWindowText");
#endif

        if(ret < 1)
            return null;

        return sb.ToString();
    }

    /// <summary></summary>
    public static string GetClassName(
            IntPtr hWnd,
            int    size = 4096)
    {
        if(IsWindowUnicode(hWnd))
            size *= 2;

        var sb = new StringBuilder(size);
        var ret = IsWindowUnicode(hWnd)
            ? GetClassNameW(hWnd, sb, size)
            : GetClassNameA(hWnd, sb, size);

        if(ret == 0)
            throw new Win32Exception(Kernel32.GetLastError());
            //return null;

        return sb.ToString();
    }

    /// <summary></summary>
    public static IntPtr SendMessage(
            IntPtr hWnd,
            uint   msg,
            IntPtr wParam,
            IntPtr lParam) => IsWindowUnicode(hWnd)
        ? SendMessageW(hWnd, msg, wParam, lParam)
        : SendMessageA(hWnd, msg, wParam, lParam);

    /// <summary></summary>
    public static string GetWindowModuleFileName(
            IntPtr hWnd,
            int    size = 4096)
    {
        if(IsWindowUnicode(hWnd))
            size *= 2;

        var sb  = new StringBuilder(size);
        var ret = IsWindowUnicode(hWnd)
            ? GetWindowModuleFileNameW(hWnd, sb, (uint)size)
            : GetWindowModuleFileNameW(hWnd, sb, (uint)size);

        if(ret < 1)
            throw new Win32Exception(Kernel32.GetLastError());
            //return null;

        return sb.ToString();
    }
}
