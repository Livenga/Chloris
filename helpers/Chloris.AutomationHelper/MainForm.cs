namespace Chloris.AutomationHelper;

using Chloris.Win32;
using Chloris.Win32.Extends;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;


/// <summary></summary>
public partial class MainForm : Form
{
    private WindowInfo? _targetWindowInfo = null;


    /// <summary></summary>
    public MainForm()
    {
        InitializeComponent();
    }

#region private Events
    /// <summary></summary>
    private void OnLoad(object source, EventArgs e)
    {
        var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
        Text += $" v{versionInfo.ProductVersion}";

        statusLabel.Text = string.Empty;
        targetWindowHandleText.Text = string.Empty;
        targetWindowTextText.Text   = string.Empty;
    }

    /// <summary></summary>
    private void OnFileExitMenuClick(object source, EventArgs e)
    {
        Close();
    }

    /// <summary></summary>
    private void OnWindowSearchFromTextClick(object source, EventArgs e)
    {
        var text = windowSearchTextText.Text;
        if(string.IsNullOrEmpty(text))
            return;
#if DEBUG
        Debug.WriteLine($"DEBUG | {nameof(OnWindowSearchFromTextClick)} - {text}");
#endif

        var rgx = new Regex(text, RegexOptions.Compiled);

        var windowInfo = WindowInfo.Get()
            .Where(wi => User32.IsWindowVisible(wi.Handle))
            .FirstOrDefault(wi => wi.Text != null && rgx.IsMatch(wi.Text));
        if(windowInfo == null)
        {
            _targetWindowInfo = null;

            targetWindowHandleText.Text = string.Empty;
            targetWindowTextText.Text   = string.Empty;
            statusLabel.Text = string.Empty;

            // TODO Message
            return;
        }

        _targetWindowInfo = windowInfo;

        User32.EnumChildWindows(windowInfo.Handle, OnEnumChildWindowProc, windowInfo.Handle);

        targetWindowHandleText.Text = $"{windowInfo.Handle.ToInt():X}";
        targetWindowTextText.Text   = windowInfo.Text ?? string.Empty;
        statusLabel.Text = $"{windowInfo.Handle.ToInt():X} {windowInfo.Text ?? "null"}";
    }
#endregion private Events


    /// <summary></summary>
    private bool OnEnumChildWindowProc(IntPtr hWnd, IntPtr lParam)
    {
        if(lParam != IntPtr.Zero && User32.IsChild(lParam, hWnd))
        {
            Debug.WriteLine($"{User32.GetDlgCtrlID(hWnd):X}\t{User32.GetWindowText(hWnd)}");
        }

        return true;
    }
}
