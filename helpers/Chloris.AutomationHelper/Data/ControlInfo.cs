namespace Chloris.AutomationHelper.Data;

using Chloris.Win32;
using Chloris.Win32.Extends;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;


/// <summary></summary>
internal sealed class ControlInfo
{
    /// <summary></summary>
    public IntPtr Handle => _handle;

    /// <summary></summary>
    public IntPtr ParentHandle => _parentHandle;

    /// <summary></summary>
    public string? Text => _text;

    /// <summary></summary>
    public string ClassName => _className;


    private readonly IntPtr _handle;
    private readonly IntPtr _parentHandle;
    private readonly string? _text;
    private readonly string _className;


    /// <summary></summary>
    private ControlInfo(
            IntPtr  handle,
            IntPtr  parentHandle,
            string? text,
            string  className)
    {
        _handle       = handle;
        _parentHandle = parentHandle;
        _text         = text;
        _className    = className;
    }


    private static List<ControlInfo>? _controlInfos = null;


    /// <summary></summary>
    public static IEnumerable<ControlInfo> GetChilds(IntPtr hWnd)
    {
        if(_controlInfos != null)
            throw new Exception();

        _controlInfos = new ();

        var state = User32.EnumChildWindows(hWnd, OnEnumChildWindows, hWnd);

        var ret = _controlInfos.ToArray();
        _controlInfos.Clear();
        _controlInfos = null;

        return state ? ret : throw new Win32Exception(Kernel32.GetLastError());
    }

    /// <summary></summary>
    private static bool OnEnumChildWindows(IntPtr hWnd, IntPtr lParam)
    {
        if(_controlInfos == null)
            return false;

        //var hParent = User32.GetParent(hWnd);
        var hParent = User32.GetAncestor(hWnd, 1);

#if DEBUG
        var hgaParent    = User32.GetAncestor(hWnd, 1);
        var hgaRoot      = User32.GetAncestor(hWnd, 2);
        var hgaRootOwner = User32.GetAncestor(hWnd, 3);

        Debug.WriteLine($"DEBUG");
        Debug.WriteLine($"\thgaParent:    {hgaParent.ToInt():X}");
        Debug.WriteLine($"\thgaRoot:      {hgaRoot.ToInt():X}");
        Debug.WriteLine($"\thgaRootOwner: {hgaRootOwner.ToInt():X}");
        Debug.WriteLine($"\t\tChild: {hWnd.ToInt():X}, hArg: {lParam.ToInt():X}, Parent: {User32.GetParent(hWnd).ToInt():X}");
#endif

        if(lParam == hParent)
        {
            lock(_controlInfos)
            {
                var className = User32.GetClassName(hWnd);
                var ci = new ControlInfo(
                        handle: hWnd,
                        parentHandle: hParent,
                        text: User32.GetWindowText(hWnd),
                        className: className);

                _controlInfos.Add(ci);
            }
        }

        return true;
    }
}
