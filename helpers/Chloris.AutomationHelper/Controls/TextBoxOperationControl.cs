namespace Chloris.AutomationHelper.Controls;

using Chloris.Win32;
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
        if(TargetHandle == IntPtr.Zero)
            return;

        var value = Win32.Controls.Edit.GetText(TargetHandle);
        if(! string.IsNullOrEmpty(value))
            valueText.Text = value;
    }

    /// <summary></summary>
    private void OnSendNotifyClick(object source, EventArgs e)
    {
        if(source is Button btn)
        {
            var ret = btn.Name switch
            {
                "notifyChangeButton" => Win32.Controls.Notify.Send(NotifyWindowHandle, TargetHandle, 0x0300),
                "notifyUpdateButton" => Win32.Controls.Notify.Send(NotifyWindowHandle, TargetHandle, 0x0400),
                _ => throw new NotSupportedException(),
            };

#if DEBUG
            Debug.WriteLine($"DEBUG | {btn.Name} {ret}");
#endif
        }
    }
}
