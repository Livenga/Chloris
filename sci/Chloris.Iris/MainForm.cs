namespace Chloris.Iris;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary></summary>
public partial class MainForm : Form
{
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
    }

    /// <summary></summary>
    private void OnFileCloseMenuClick(object source, EventArgs e)
    {
        Close();
    }
#endregion
}
