namespace Chloris.AutomationHelper.Controls;

using Chloris.Win32.Extends;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary></summary>
public partial class SelectorOpeartionControl : UserControl
{
    /// <summary></summary>
    public IntPtr TargetHandle
    {
        set
        {
            _targetHandle = value;
            OnTargetHandleChanged(value);
        }
        get => _targetHandle;
    }

    /// <summary></summary>
    public IntPtr NotifyWindowHandle { set; get; } = IntPtr.Zero;


    private IntPtr _targetHandle = IntPtr.Zero;
    private ListViewItem[]? _listViewItems = null;


    /// <summary></summary>
    public SelectorOpeartionControl()
    {
        InitializeComponent();
    }

#region private Events
    /// <summary></summary>
    private void OnItemListRetrieveVirtualItem(
            object source,
            RetrieveVirtualItemEventArgs e)
    {
        if(_listViewItems == null
                || e.ItemIndex > _listViewItems.Length)
        {
            return;
        }

        e.Item = _listViewItems[e.ItemIndex];
    }

    /// <summary></summary>
    private void OnTargetHandleChanged(IntPtr hWnd)
    {
        if(hWnd == IntPtr.Zero)
        {
            _listViewItems = null;
            return;
        }

        try
        {
            _listViewItems = Chloris.Win32.Controls
                .Selector
                .GetItems(hWnd)
                .Select((item, index) => new ListViewItem(new string[] { $"{index}", item }))
                .ToArray();

            itemList.VirtualListSize = _listViewItems.Length;
        }
        catch(Exception ex)
        {
#if DEBUG
            Debug.WriteLine($"ERROR | {ex.GetType().FullName} {ex.Message}");
            Debug.WriteLine(ex.StackTrace);
#endif
            itemList.VirtualListSize = 0;
        }
        finally
        {
            itemList.Refresh();
        }
    }

    /// <summary></summary>
    private void OnItemListSelectedIndexChanged(object source, EventArgs e)
    {
        if(itemList.SelectedIndices.Count == 0)
            return;
        setCurrentSelectionText.Text = $"{itemList.SelectedIndices[0]}";
    }

    /// <summary></summary>
    private void OnGetCurrentSelectionClick(object source, EventArgs e)
    {
        if(_targetHandle == IntPtr.Zero)
            return;

        try
        {
            var index = Chloris.Win32.Controls.Selector.GetCurrentSelection(_targetHandle);

            getCurrentSelectionText.ForeColor = Color.Blue;
            getCurrentSelectionText.Text = $"{index}";
        }
        catch(Exception ex)
        {
            getCurrentSelectionText.ForeColor = Color.Coral;
            getCurrentSelectionText.Text = ex.Message;
#if DEBUG
            Debug.WriteLine($"ERROR | {ex.GetType().FullName} {ex.Message}");
            Debug.WriteLine(ex.StackTrace);
#endif
        }
    }

    /// <summary></summary>
    private void OnSetCurrentSelectionClick(object source, EventArgs e)
    {

        int? index = null;
        try
        {
            index = System.Convert.ToInt32(setCurrentSelectionText.Text);
        }
        catch { }
#if DEBUG
        Debug.WriteLine($"DEBUG | {nameof(OnSetCurrentSelectionClick)} {NotifyWindowHandle.ToInt():X} {index?.ToString() ?? "null"}");
#endif

        if(index == null)
            return;

        Win32.Controls.Selector.SetCurrentSelection(_targetHandle, index.Value);

        Win32.Controls.Selector.NotifySelChange(NotifyWindowHandle, _targetHandle);
        Win32.Controls.Selector.NotifySelectOK(NotifyWindowHandle, _targetHandle);
        Win32.Controls.Selector.NotifyKillFocus(NotifyWindowHandle, _targetHandle);
    }
#endregion private Events
}
