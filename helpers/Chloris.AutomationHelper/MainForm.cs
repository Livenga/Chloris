namespace Chloris.AutomationHelper;

using Chloris.Extends;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;


/// <summary></summary>
public partial class MainForm : Form
{
    private WindowInfo? _targetWindowInfo = null;
    private CancellationTokenSource? _monitorCursorWindowTokenSource = null;


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

        windowSearchTextText.Text = "テスト";
    }

    /// <summary></summary>
    private void OnFormClosing(object source, FormClosingEventArgs e)
    {
        _monitorCursorWindowTokenSource?.Cancel();
        _monitorCursorWindowTokenSource?.Dispose();
        _monitorCursorWindowTokenSource = null;
    }

    /// <summary></summary>
    private void OnFileExitMenuClick(object source, EventArgs e)
    {
        Close();
    }

    /// <summary></summary>
    private void OnMonitorCursorWindowMenuClick(object source, EventArgs e)
    {
        if(! monitorCursorWindowMenuItem.Checked)
        {
            _monitorCursorWindowTokenSource = new CancellationTokenSource();

            var task = Task.Run(OnMonitorCursorWindowAsync);
        }
        else
        {
            _monitorCursorWindowTokenSource?.Cancel();
            _monitorCursorWindowTokenSource?.Dispose();
            _monitorCursorWindowTokenSource = null;
        }

        monitorCursorWindowMenuItem.Checked = ! monitorCursorWindowMenuItem.Checked;
        cursorMonitorGroup.Enabled = monitorCursorWindowMenuItem.Checked;
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

        // 子要素ツリーのクリア
        windowChildTree.Nodes.Clear();

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

        // 子要素の取得
        windowChildTree.Nodes.AddRange(GetWindowChildNodes(windowInfo.Handle));
    }

    /// <summary></summary>
    private void OnWindowChildTreeBeforeExpand(object source, TreeViewCancelEventArgs e)
    {
#if DEBUG
        Debug.WriteLine($"DEBUG | {GetType().FullName}.{nameof(OnWindowChildTreeBeforeExpand)}");
        Debug.WriteLine($"\tNode.Tag type = {e.Node.Tag?.GetType().FullName ?? "null"}");
        Debug.WriteLine($"\t{e.Node.Text ?? string.Empty} Node Count: {e.Node.Nodes.Count}");
#endif

        if(e.Node.Nodes.Count == 1
                && e.Node.Nodes[0].Tag is IntPtr hWnd
                && hWnd == IntPtr.Zero)
        {
            e.Node.Nodes.Clear();

            // 子要素の取得
            try
            {
                var nodes = GetWindowChildNodes(e.Node.Tag is Data.ControlInfo ci ? ci.Handle : throw new NotSupportedException());
                e.Node.Nodes.AddRange(nodes);
            }
            catch(Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"ERROR | {ex.GetType().FullName} {ex.Message}");
                Debug.WriteLine(ex.StackTrace);
#endif
            }
        }
        else if(e.Node.Nodes.Count > 0)
        {
            // 正常な要素が存在する場合は何もしない.
        }
        else
        {
            // XXX 要素が存在しない場合のみここに到達するように
            e.Cancel = true;
        }
    }

    private TreeNode? _targetTreeNode = null;

    /// <summary></summary>
    private void OnWindowChildTreeNodeMouseClick(object source, TreeNodeMouseClickEventArgs e)
    {
#if DEBUG
        Debug.WriteLine($"DEBUG | {nameof(OnWindowChildTreeNodeMouseClick)}");
#endif
        _targetTreeNode = (e.Button == MouseButtons.Right)
            ? e.Node
            : null;
    }

    /// <summary></summary>
    private void OnWindowChildTreeMenuOpening(object source, CancelEventArgs e)
    {
#if DEBUG
        Debug.WriteLine($"DEBUG | {nameof(OnWindowChildTreeMenuOpening)}");
#endif
        if(_targetTreeNode != null
                && _targetTreeNode.Tag is Data.ControlInfo ci)
        {
            targetNodeMenuItem.Enabled = true;
            targetNodeMenuItem.Text = $"{_targetTreeNode.Text ?? string.Empty} ({ci.Handle.ToInt():X})";
        }
        else
        {
            targetNodeMenuItem.Enabled = false;
            targetNodeMenuItem.Text = $"(Not Selected)";
        }

        Debug.WriteLine($"DEBUG | SelectedNode: {_targetTreeNode?.Text ?? "null"}");
    }

    /// <summary></summary>
    private void OnSetNotifyWindowMenuClick(object source, EventArgs e)
    {
#if DEBUG
        Debug.WriteLine($"DEBUG | {nameof(OnSetNotifyWindowMenuClick)} {_targetTreeNode?.Tag?.ToString() ?? "null"}");
#endif

        if(_targetTreeNode?.Tag != null
            && _targetTreeNode.Tag is Data.ControlInfo ci)
        {
            notifyTextText.Text   = ci.Text ?? string.Empty;
            notifyHandleText.Text = $"{ci.Handle.ToInt():X}";

            var ae = AutomationElement.FromHandle(ci.Handle);
            Debug.WriteLine(ae.Current.ControlType.ProgrammaticName.Split('.').Last());
#if DEBUG
            ae.Current.DisplayProperties();
#endif

            selectorOperator.NotifyWindowHandle = ci.Handle;
            textOperator.NotifyWindowHandle = ci.Handle;
        }
    }

    /// <summary></summary>
    private void OnSetTargetWindowMenuClick(object source, EventArgs e)
    {
        if(_targetTreeNode?.Tag != null
                && _targetTreeNode.Tag is Data.ControlInfo ci
                && ci.Handle != IntPtr.Zero)
        {
            var ae = AutomationElement.FromHandle(ci.Handle);
            targetTypeLabel.Text = ae.Current.ControlType.ProgrammaticName.Split('.').LastOrDefault() ?? "empty";


            try
            {
                // 個々のページに遷移
                var controlId = ae.Current.ControlType.Id;
#if DEBUG
                Debug.WriteLine($"DEBUG | {controlId} {ae.Current.ControlType.ProgrammaticName}");
#endif

                if(controlId  == ControlType.ComboBox.Id)
                {
                    // ComboBox
                    selectorOperator.TargetHandle = ci.Handle;
                }
                else if(controlId == ControlType.Edit.Id)
                {
                    // TextBox
                    textOperator.TargetHandle = ci.Handle;
                }
            }
            catch(Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"ERROR | {ex.GetType().FullName} {ex.Message}");
                Debug.WriteLine(ex.StackTrace);
#endif
            }
        }
    }
#endregion private Events
    /// <summary></summary>
    private async Task OnMonitorCursorWindowAsync()
    {
        bool isContinue = true;
        var cursorPosition = new Chloris.Win32.Point();

        while(isContinue)
        {
            try
            {
                if(! User32.GetCursorPos(out cursorPosition))
                    throw new Win32Exception(Kernel32.GetLastError());

                var hWnd = User32.WindowFromPhysicalPoint(cursorPosition);
                OnApplyMonitorText(hWnd, cursorPosition);

                await Task.Delay(
                        1000,
                        _monitorCursorWindowTokenSource?.Token ?? throw new NullReferenceException());
            }
            catch(Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"ERROR | {ex.GetType().FullName} {ex.Message}");
#endif
                isContinue = false;
            }
        }
    }

    /// <summary></summary>
    private TreeNode[] GetWindowChildNodes(IntPtr hWnd)
    {
        var cis = Chloris.AutomationHelper.Data.ControlInfo.GetChilds(hWnd);
        var childCount = cis.Count();

        if(childCount == 0)
            return Array.Empty<TreeNode>();

        var nodes = new TreeNode[childCount];
        for(var i = 0; i < childCount; ++i)
        {
            var ci = cis.ElementAt(i);
            var typeName = AutomationElement.FromHandle(ci.Handle).Current.ControlType.ProgrammaticName
                .Split('.')
                .LastOrDefault() ?? string.Empty;

            nodes[i] = new TreeNode(
                    text: ! string.IsNullOrEmpty(typeName)
                        ? $"\"{ci.Text ?? string.Empty}\" {typeName}"
                        : $"\"{ci.Text ?? string.Empty}\"") { Tag = ci };
            nodes[i].ContextMenuStrip = windowChildTreeMenuStrip;

            nodes[i].Nodes.Add(new TreeNode("読み込み中") { Tag = IntPtr.Zero });
        }

        return nodes;
    }

    /// <summary></summary>
    private bool OnEnumChildWindowProc(IntPtr hWnd, IntPtr lParam)
    {
        if(lParam != IntPtr.Zero && User32.IsChild(lParam, hWnd))
        {
            Debug.WriteLine($"{User32.GetDlgCtrlID(hWnd):X}\t{User32.GetWindowText(hWnd)}");
        }

        return true;
    }


    /// <summary></summary>
    private void OnApplyMonitorText(
            IntPtr hWnd,
            Win32.Point point)
    {
        if(InvokeRequired)
        {
            Invoke(OnApplyMonitorText, hWnd, point);
            return;
        }

        var ctrlId = User32.GetDlgCtrlID(hWnd);

        monitorHandleText.Text   = $"{hWnd.ToInt():X}";
        monitorIdText.Text       = $"{ctrlId} #{ctrlId:X}";
        monitorLocationText.Text = $"{point.x}x{point.y}";
        monitorTextText.Text     = User32.GetWindowText(hWnd) ?? string.Empty;
    }
}
