namespace Chloris.Win32;

using System;
using System.Collections.Generic;
using System.Linq;


/// <summary></summary>
public class WindowInfo
{
    /// <summary></summary>
    public IntPtr Handle => _handle;

    /// <summary></summary>
    public string? Text => _text;

    /// <summary></summary>
    public int ProcessId => _processId;

    /// <summary></summary>
    public int ThreadId => _threadId;


    private readonly IntPtr _handle;
    private readonly string? _text;
    private readonly int _processId;
    private readonly int _threadId;


    /// <summary></summary>
    private WindowInfo(
            IntPtr  handle,
            string? text,
            int     processId,
            int     threadId)
    {
        _handle    = handle;
        _text      = text;
        _processId = processId;
        _threadId  = threadId;
    }


    private static List<WindowInfo>? _windowInfos = null;


    /// <summary></summary>
    public static IEnumerable<WindowInfo> Get()
    {
        if(_windowInfos != null)
            throw new Exception();

        _windowInfos = new ();
        User32.EnumWindows(OnEnumWindows, IntPtr.Zero);
        var ret = _windowInfos.ToArray();

        _windowInfos.Clear();
        _windowInfos = null;

        return ret;
    }

    /// <summary></summary>
    private static bool OnEnumWindows(IntPtr hWnd, IntPtr lParam)
    {
        if(_windowInfos == null)
            return false;

        var text = User32.GetWindowText(hWnd);
        int processId = 0;
        int threadId = User32.GetWindowThreadProcessId(hWnd, out processId);

        lock(_windowInfos)
        {
            _windowInfos.Add(new WindowInfo(
                        handle:    hWnd,
                        text:      text,
                        processId: processId,
                        threadId:  threadId));
        }

        return true;
    }
}
