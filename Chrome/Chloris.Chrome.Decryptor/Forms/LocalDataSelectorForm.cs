namespace Chloris.Chrome.Decryptor.Forms;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


/// <summary></summary>
public partial class LocalDataSelectorForm : Form
{
    /// <summary></summary>
    public IEnumerable<string>? LocalStatePaths
    {
        set
        {
            _localStatePaths = value;
            SetListViewItems(localStateList, value);
        }
        get => _localStatePaths;
    }

    /// <summary></summary>
    public IEnumerable<string>? LoginDataPaths
    {
        set
        {
            _loginDataPaths = value;
            SetListViewItems(loginDataList, value);
        }
        get => _loginDataPaths;
    }

    /// <summary></summary>
    public string? SelectedLocalStatePath { private set; get; } = null;

    /// <summary></summary>
    public string? SelectedLoginDataPath { private set; get; } = null;


    private IEnumerable<string>? _localStatePaths = null;
    private IEnumerable<string>? _loginDataPaths = null;


    /// <summary></summary>
    public LocalDataSelectorForm()
    {
        InitializeComponent();
    }

#region private Events
    /// <summary></summary>
    private void OnKeyUp(object source, KeyEventArgs e)
    {
        switch(e.KeyCode)
        {
            case Keys.Escape:
                DialogResult = DialogResult.Cancel;
                break;
        }
    }

    /// <summary></summary>
    private void OnDecideClick(object source, EventArgs e)
    {
        if(loginDataList.SelectedItems.Count > 0)
            SelectedLoginDataPath = loginDataList.SelectedItems[0].Tag as string;
        if(localStateList.SelectedItems.Count > 0)
            SelectedLocalStatePath = localStateList.SelectedItems[0].Tag as string;

        if(SelectedLoginDataPath == null
                || SelectedLocalStatePath == null)
        {
            MessageBox.Show(
                    caption: "警告",
                    text: "必要なファイルの選択が行われていません.",
                    icon: MessageBoxIcon.Warning,
                    buttons: MessageBoxButtons.OK);

            return;
        }

        DialogResult = DialogResult.OK;
    }
#endregion private Events

    /// <summary></summary>
    private void SetListViewItems(
            ListView view,
            IEnumerable<string>? items)
    {
        view.Items.Clear();

        if(items == null
                || ! items.Any())
            return;

        view.Items.AddRange(items
                .Select(item => new ListViewItem(item) { Tag = item })
                .ToArray());
    }
}
