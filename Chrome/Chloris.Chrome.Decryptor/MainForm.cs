namespace Chloris.Chrome.Decryptor;

using Chloris.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary></summary>
public partial class MainForm : Form
{
    private DataLoader? _dataLoader = null;
    private ListViewItem[]? _loginListViewItems = null;
    private Chloris.Chrome.Data.OsCrypt? _osCrypt = null;


    /// <summary></summary>
    public MainForm()
    {
        InitializeComponent();
    }

#region private Events
    /// <summary></summary>
    private void OnLoad(object source, EventArgs e)
    {
        var productVersion = FileVersionInfo
            .GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;

        Text += $" v{productVersion}";
        protectionScopeSelector.Items.AddRange(Enum
                .GetValues(typeof(DataProtectionScope))
                .Cast<object>()
                .ToArray());
        protectionScopeSelector.SelectedIndex = 0;
    }

    /// <summary></summary>
    private void OnShown(object source, EventArgs e)
    {
    }

    /// <summary></summary>
    private void OnFileSaveToCsvMenuClick(object source, EventArgs e)
    {
        throw new NotImplementedException();
    }

    /// <summary></summary>
    private async void OnFileSearchLoginDataMenuClick(object source, EventArgs e)
    {
        var chromeAppDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Google",
                "Chrome");

        var loginDataPaths = Directory.GetFiles(
                path: chromeAppDirectory,
                searchPattern: "Login Data",
                searchOption: SearchOption.AllDirectories);

        var localStatePaths = Directory.GetFiles(
                path: chromeAppDirectory,
                searchPattern: "Local State",
                searchOption: SearchOption.AllDirectories);

        if(loginDataPaths.Length == 1 && localStatePaths.Length == 1)
        {
            databasePathText.Text = loginDataPaths[0];
            statePathText.Text = localStatePaths[0];

            _dataLoader = await GetDataLoaderAsync(
                    dataSource:     loginDataPaths[0],
                    localStatePath: localStatePaths[0]);
        }
        else
        {
            /*
            MessageBox.Show(
                    caption: "警告",
                    text: "複数の \"Login Data\", \"Local State\" が見つかりました.(選択できるように修正します.多分)",
                    icon: MessageBoxIcon.Warning,
                    buttons: MessageBoxButtons.OK);
                    */

            using(var dlg = new Forms.LocalDataSelectorForm())
            {
                dlg.LoginDataPaths  = loginDataPaths;
                dlg.LocalStatePaths = localStatePaths;

                if(DialogResult.OK == dlg.ShowDialog(this))
                {
                    databasePathText.Text = dlg.SelectedLoginDataPath ?? string.Empty;
                    statePathText.Text    = dlg.SelectedLocalStatePath ?? string.Empty;

                    // TODO 安全性の検証
                    _dataLoader = await GetDataLoaderAsync(
                            dataSource:     databasePathText.Text,
                            localStatePath: statePathText.Text);
                }
            }
        }
#if DEBUG
        foreach(var loginDataPath in loginDataPaths)
        {
            Debug.WriteLine(loginDataPath);
        }
        foreach(var localStatePath in localStatePaths)
        {
            Debug.WriteLine(localStatePath);
        }
#endif
    }

    /// <summary></summary>
    private void OnFileExitMenuClick(object source, EventArgs e)
    {
        Close();
    }

    /// <summary></summary>
    private async void OnChooseDatabaseClick(object source, EventArgs e)
    {
        var path = ChooseFile(filter: "データベースファイル(*.db)|*.db|全てのファイル(*.*)|*.*");
        if(path != null)
        {
            databasePathText.Text = path;
        }

        _dataLoader = await GetDataLoaderAsync(databasePathText.Text, statePathText.Text);
    }

    /// <summary></summary>
    private async void OnChooseStateClick(object source, EventArgs e)
    {
        var path = ChooseFile(filter: "JSONファイル(*.json)|*.json|全てのファイル(*.*)|*.*");
        if(path != null)
        {
            statePathText.Text = path;
        }

        _dataLoader = await GetDataLoaderAsync(databasePathText.Text, statePathText.Text);
    }

    /// <summary></summary>
    private void OnLoginRetrieveVirtualItem(object source, RetrieveVirtualItemEventArgs e)
    {
        if(_loginListViewItems != null && _loginListViewItems.Length > e.ItemIndex)
        {
            e.Item = _loginListViewItems[e.ItemIndex];
        }
    }

    /// <summary></summary>
    private void OnLoginSelectedIndexChanged(object source, EventArgs e)
    {
        if(loginList.SelectedIndices.Count == 0
                || _osCrypt == null
                || _loginListViewItems == null
                || ! _loginListViewItems.Any())
        {
            // TODO View 初期化
            return;
        }

        var index = loginList.SelectedIndices[0];
        if(_loginListViewItems.Length > index
                && _loginListViewItems[index].Tag != null
                && _loginListViewItems[index].Tag is Chloris.Chrome.Data.Login login)
        {
            // 取得
            try
            {
                DataProtectionScope scope = DataProtectionScope.CurrentUser;
                if(protectionScopeSelector.SelectedItem != null
                        && protectionScopeSelector.SelectedItem is DataProtectionScope _scope)
                    scope = _scope;

                var passwordValue = DoDecrypt(
                        key: System.Convert.FromBase64String(_osCrypt.EncryptedKey),
                        login: login,
                        protectionScope: scope);

                loginUrlText.Text      = login.OriginUrl;
                loginUsernameText.Text = login.UserNameValue ?? string.Empty;
                loginPasswordText.Text = System.Text.Encoding.UTF8.GetString(passwordValue);

            }
            catch(Exception ex)
            {
                MessageBox.Show(
                        caption: "エラー",
                        text: $"パスワードの複合化に失敗.\r\n{ex.GetType().FullName} {ex.Message}",
                        icon: MessageBoxIcon.Error,
                        buttons: MessageBoxButtons.OK);
            }

        }
    }
#endregion private Events
    /// <summary></summary>
    private string? ChooseFile(string filter)
    {
        using var dlg = new OpenFileDialog();
        dlg.Filter = filter;
        dlg.FilterIndex = 1;
        dlg.RestoreDirectory = true;
        dlg.Multiselect = false;

        if(DialogResult.OK == dlg.ShowDialog(this))
        {
            return dlg.FileName;
        }

        return null;
    }

    /// <summary></summary>
    private async Task<DataLoader?> GetDataLoaderAsync(
            string dataSource,
            string localStatePath,
            CancellationToken cancellationToken = default(CancellationToken))
    {
        if(string.IsNullOrEmpty(dataSource)
                || string.IsNullOrEmpty(localStatePath)
                || ! File.Exists(dataSource)
                || ! File.Exists(localStatePath))
            return null;

        var dataLoader = new DataLoader(
                dataSource: dataSource,
                localStatePath: localStatePath);

        try
        {
            _osCrypt = await dataLoader.GetOsCryptAsync(cancellationToken);
            encryptedKeyText.Text = _osCrypt.EncryptedKey;
        }
        catch
        {
            _osCrypt = null;
            encryptedKeyText.Tag = null;
        }
        try
        {
            Func<byte[]?, string> nBytesToString = (bytes) => (bytes != null)
                ? string.Join("-", bytes.Select(b => $"{b:X2}"))
                : string.Empty;

            var logins = await dataLoader.GetLoginsAsync(CancellationToken.None);
            _loginListViewItems = logins.Select(l => new ListViewItem(new string[]
                        {
                            $"{l.Id}",
                            l.OriginUrl,
                            l.UserNameValue ?? string.Empty,
                            nBytesToString(l.PasswordValue),
                            l.PasswordType.ToString(),
                            l.DateCreated.ToString(),
                        }) { Tag = l })
                .ToArray();
        }
        catch(Exception ex)
        {
#if DEBUG
            Debug.WriteLine($"ERROR | {ex.GetType().FullName} {ex.Message}");
            Debug.WriteLine(ex.StackTrace);
#endif
            _loginListViewItems = null;
        }
        finally
        {
            loginList.VirtualListSize = _loginListViewItems?.Length ?? 0;
            loginList.Refresh();
        }
        return dataLoader;
    }

    /// <summary></summary>
    private byte[] DoDecrypt(
            byte[] key,
            Chloris.Chrome.Data.Login login,
            DataProtectionScope protectionScope = DataProtectionScope.CurrentUser)
    {
        return Chloris.Chrome.Cryptor.GoogleChromePasswordValueDecrypt(
                key,
                login.PasswordValue ?? throw new NullReferenceException(),
                protectionScope);
    }
}
