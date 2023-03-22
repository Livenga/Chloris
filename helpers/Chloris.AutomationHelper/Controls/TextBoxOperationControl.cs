namespace Chloris.AutomationHelper.Controls;

using Chloris.Win32;
using Chloris.Win32.Extends;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary></summary>
public partial class TextBoxOperationControl : UserControl
{
    /// <summary></summary>
    public IntPtr NotifyWindowHandle { set; get; } = IntPtr.Zero;

    /// <summary></summary>
    public IntPtr TargetHandle { set; get; } = IntPtr.Zero;


    /// <summary></summary>
    public TextBoxOperationControl()
    {
        InitializeComponent();
    }

    /// <summary></summary>
    private void OnLimitTextMenuItemClick(object source, EventArgs e)
    {
        if(TargetHandle == IntPtr.Zero)
            return;

        var ret = Win32.Controls.Edit.GetLimitTextLength(TargetHandle);

        MessageBox.Show(
                caption: "Information",
                text: $"Limit Text Length: {ret}",
                icon: MessageBoxIcon.Information,
                buttons: MessageBoxButtons.OK);
    }

    /// <summary></summary>
    private void OnSetValueClick(object source, EventArgs e)
    {
#if DEBUG
        Debug.WriteLine($"DEBUG | {nameof(OnSetValueClick)} {TargetHandle.ToInt():X} \"{valueText.Text}\"");
#endif
        if(TargetHandle == IntPtr.Zero)
            return;

        var value = valueText.Text;

        try
        {
            var ret = Win32.Controls.Edit.SetText(TargetHandle, value);
            if(ret == 0)
            {
            }
        }
        catch(Exception ex)
        {
        }
    }

    /// <summary></summary>
    private void OnGetValueClick(object source, EventArgs e)
    {
#if DEBUG
        Debug.WriteLine($"DEBUG | {nameof(OnGetValueClick)} {TargetHandle.ToInt():X}");
#endif
        if(TargetHandle == IntPtr.Zero)
            return;

        var value = Win32.Controls.Edit.GetText(TargetHandle);
        valueText.Text = value ?? string.Empty;
    }

    /// <summary></summary>
    private void OnSendNotifyClick(object source, EventArgs e)
    {
        if(source is Button btn)
        {
            var ret = btn.Name switch
            {
                "notifyChangeButton"    => Win32.Controls.Edit.SendChangeNotify(NotifyWindowHandle, TargetHandle),
                "notifyUpdateButton"    => Win32.Controls.Edit.SendUpdateNotify(NotifyWindowHandle, TargetHandle),
                "notifySetFocusButton"  => Win32.Controls.Edit.SendSetFocusNotify(NotifyWindowHandle, TargetHandle),
                "notifyKillFocusButton" => Win32.Controls.Edit.SendKillFocusNotify(NotifyWindowHandle, TargetHandle),
                _ => throw new NotSupportedException(),
            };

#if DEBUG
            Debug.WriteLine($"DEBUG | {btn.Name} {ret}");
#endif
        }
    }

    /// <summary></summary>
    private void OnSwitchModifyClick(object source, EventArgs e)
    {
        if(TargetHandle == IntPtr.Zero)
            return;

        if(source is Button btn)
        {
            if(btn == enableModifyButton)
            {
                Win32.Controls.Edit.SetModify(TargetHandle, true);
            }
            else if(btn == disableModifyButton)
            {
                Win32.Controls.Edit.SetModify(TargetHandle, false);
            }
        }
    }

    /// <summary></summary>
    private void OnGetModifyClick(object source, EventArgs e)
    {
        if(TargetHandle == IntPtr.Zero)
            return;

        var value = Win32.Controls.Edit.GetModify(TargetHandle);
        modifyStateLabel.Text = $"Modify = {value}";
    }
}
