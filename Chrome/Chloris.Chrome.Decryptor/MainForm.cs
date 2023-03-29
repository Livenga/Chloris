namespace Chloris.Chrome.Decryptor;

using Chloris.Chrome;
using System;
using System.Data;
using System.Diagnostics;
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
    /// <summary></summary>
    public bool IsDbOpened
    {
        set
        {
            _isDbOpened = value;

            fileSearchLoginDataMenuItem.Enabled = ! value;
            inputFileGroup.Enabled              = ! value;
            fileSaveCsvMenuItem.Enabled         = value;

            dbConnectButton.Text = value ? "切断(&D)" : "接続(&C)";

            if(! value)
            {
                loginUrlText.Text      = string.Empty;
                loginUsernameText.Text = string.Empty;
                loginPasswordText.Text = string.Empty;

                encryptedKeyText.Text = string.Empty;
                _loginListViewItems = null;
                loginList.VirtualListSize = 0;
                loginList.Refresh();
            }
        }
        get => _isDbOpened;
    }

    private DataLoader? _dataLoader = null;
    private ListViewItem[]? _loginListViewItems = null;
    private Chloris.Chrome.Data.OsCrypt? _osCrypt = null;
    private bool _isDbOpened = false;


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

        databasePathText.Text  = string.Empty;
        statePathText.Text     = string.Empty;
        loginUrlText.Text      = string.Empty;
        loginUsernameText.Text = string.Empty;
        loginPasswordText.Text = string.Empty;
    }

    /// <summary></summary>
    private void OnShown(object source, EventArgs e) { }

    /// <summary></summary>
    private void OnFormClosing(object source, FormClosingEventArgs e)
    {
        _dataLoader?.Dispose();
        _dataLoader = null;
    }

    /// <summary></summary>
    private async void OnFileSaveToCsvMenuClick(object source, EventArgs e)
    {
        if(_loginListViewItems == null
                || _loginListViewItems.Length == 0)
        {
            // TODO Message
            return;
        }

        if(_osCrypt == null)
        {
            // TODO Message
            return;
        }

        var protectionScope = (protectionScopeSelector.SelectedItem != null
                && protectionScopeSelector.SelectedItem is DataProtectionScope)
            ? (DataProtectionScope)protectionScopeSelector.SelectedItem
            : DataProtectionScope.CurrentUser;

        string? csvPath = null;
        try
        {
            using var dlg = new SaveFileDialog();
            dlg.FilterIndex      = 1;
            dlg.Filter           = "Csvファイル(*.csv)|*.csv|全てのファイル(*.*)|*.*";
            dlg.RestoreDirectory = true;
            dlg.FileName         = $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.csv";

            if(DialogResult.OK == dlg.ShowDialog(this))
            {
                csvPath = dlg.FileName;

                var encryptedKey = System.Convert.FromBase64String(_osCrypt.EncryptedKey);
                var encryptedLogins = _loginListViewItems
                    .Where(item => item.Tag != null && item.Tag is Chloris.Chrome.Data.Login)
                    .Select(item => (Chloris.Chrome.Data.Login)item.Tag)
                    .Select(item => new Chloris.Chrome.Data.DecryptLogin(
                                id:         item.Id,
                                originUrl:  item.OriginUrl,
                                username:   item.UserNameValue,
                                password:   ((item.PasswordValue != null)
                                    ? Encoding.UTF8.GetString(Chloris.Chrome
                                        .Cryptor
                                        .GoogleChromePasswordValueDecrypt(encryptedKey, item.PasswordValue, protectionScope))
                                    : string.Empty),
                                createdAt:  item.DateCreated,
                                lastUsedAt: item.DateLastUsed));

#if DEBUG
                Debug.WriteLine($"DEBUG | {encryptedLogins.Count()}");
                foreach(var eLogin in encryptedLogins)
                {
                    Debug.WriteLine($"\t{eLogin.OriginUrl} {eLogin.Password}");
                }
#endif
                await Chloris.Chrome.IO.Csv.WriteAsync(
                        path:              csvPath,
                        records:           encryptedLogins,
                        encoding:          Encoding.UTF8/*Encoding.GetEncoding(932)*/,
                        cancellationToken: CancellationToken.None);

                MessageBox.Show(
                        caption: "成功",
                        text:    $"複合化データを \"{csvPath}\" に保存しました.",
                        icon:    MessageBoxIcon.Information,
                        buttons: MessageBoxButtons.OK);
            }
        }
        catch(Exception ex)
        {
            if(csvPath != null && File.Exists(csvPath))
            {
                // 何かしらの理由で Csv の保存に失敗した場合は途中のファイルを破棄する.
                try
                {
                    File.Delete(path: csvPath);
                } catch { }
            }

#if DEBUG
            Debug.WriteLine($"ERROR | {ex.GetType().FullName}");
            Debug.WriteLine(ex.StackTrace);
#endif

            MessageBox.Show(
                    caption: "エラー",
                    text:    "複合化ファイルの保存に失敗しました.\r\n" + $"{ex.GetType().Name} {ex.Message}",
                    icon:    MessageBoxIcon.Error,
                    buttons: MessageBoxButtons.OK);
        }
    }

    /// <summary></summary>
    private void OnFileSearchLoginDataMenuClick(object source, EventArgs e)
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
            statePathText.Text    = localStatePaths[0];
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
                    databasePathText.Text = dlg.SelectedLoginDataPath  ?? string.Empty;
                    statePathText.Text    = dlg.SelectedLocalStatePath ?? string.Empty;
                }
            }
        }
    }

    /// <summary></summary>
    private void OnFileExitMenuClick(object source, EventArgs e)
    {
        Close();
    }

    /// <summary></summary>
    private void OnChooseDatabaseClick(object source, EventArgs e)
    {
        var path = ChooseFile(filter: "データベースファイル(*.db)|*.db|全てのファイル(*.*)|*.*");
        if(path != null)
        {
            databasePathText.Text = path;
        }
    }

    /// <summary></summary>
    private void OnChooseStateClick(object source, EventArgs e)
    {
        var path = ChooseFile(filter: "JSONファイル(*.json)|*.json|全てのファイル(*.*)|*.*");
        if(path != null)
        {
            statePathText.Text = path;
        }
    }

    /// <summary></summary>
    private async void OnDbConnectClick(object source, EventArgs e)
    {
        if(! IsDbOpened)
        {
            // 接続
            try
            {
                var dataSourcePath = databasePathText.Text;
                var localStatePath = statePathText.Text;

                _dataLoader?.Dispose();
                _dataLoader = await GetDataLoaderAsync(
                        dataSourcePath,
                        localStatePath,
                        CancellationToken.None);

                IsDbOpened = true;
            }
            catch(Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"ERROR | {ex.GetType().FullName} {ex.Message}");
                Debug.WriteLine(ex.StackTrace);
#endif

                // TODO Message
                IsDbOpened = false;
            }
        }
        else
        {
            // 切断
            _dataLoader?.Dispose();
            _dataLoader = null;

            IsDbOpened = false;
        }
    }

    /// <summary></summary>
    private void OnLoginRetrieveVirtualItem(object source, RetrieveVirtualItemEventArgs e)
    {
        if(_loginListViewItems != null
                && _loginListViewItems.Length > e.ItemIndex)
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
        if(! File.Exists(dataSource)
                || ! File.Exists(localStatePath))
            return null;

        var dataLoader = new DataLoader(
                dataSource:     dataSource,
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
