namespace Chloris.Win32.Test;

using Chloris.Win32;
using Chloris.Win32.Extends;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Diagnostics;
using System.Windows.Automation;


/// <summary></summary>
[TestClass]
public class WindowTest
{
    [TestMethod]
    public void EnumWindowsTest()
    {
        User32.EnumWindows(OnEnumWindows, IntPtr.Zero);
    }

    /// <summary></summary>
    private bool OnEnumWindows(IntPtr hWnd, IntPtr lParam)
    {
        var text = User32.GetWindowText(hWnd);
        var className = User32.GetClassName(hWnd);
        Console.Error.WriteLine($"{hWnd.ToInt():X} {text ?? "null"}({className})");

        User32.EnumChildWindows(hWnd, OnEnumChildWindows, lParam);

        return true;
    }

    /// <summary></summary>
    private bool OnEnumChildWindows(IntPtr hWnd, IntPtr lParam)
    {
        var ctrlId = User32.GetDlgCtrlID(hWnd);
        var text = User32.GetWindowText(hWnd);
        var className = User32.GetClassName(hWnd);

        Console.Error.WriteLine($"\t{ctrlId}: {text}({className})");

        return true;
    }


    /// <summary></summary>
    [TestMethod]
    public void GetTest()
    {
        var windowInfos = WindowInfo.Get();
        foreach(var wi in windowInfos)
        {
            Console.Error.WriteLine($"# {wi.ProcessId}#{wi.ThreadId} {wi.Text} {wi.Handle.ToInt():X}");
            Console.Error.WriteLine($"\t{User32.GetWindowModuleFileName(wi.Handle)}");
        }
    }
}
