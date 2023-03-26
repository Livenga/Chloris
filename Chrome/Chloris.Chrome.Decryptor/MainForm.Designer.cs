namespace Chloris.Chrome.Decryptor
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.inputFileGroup = new System.Windows.Forms.GroupBox();
            this.chooseStateButton = new System.Windows.Forms.Button();
            this.statePathText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chooseDatabaseButton = new System.Windows.Forms.Button();
            this.databasePathText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveCsvMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSearchLoginDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.loginList = new System.Windows.Forms.ListView();
            this.loginIdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loginUrlHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loginUsernameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loginPasswordHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loginPasswordTypeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loginCreatedAtHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loginsLabel = new System.Windows.Forms.Label();
            this.encryptedKeyLabel = new System.Windows.Forms.Label();
            this.encryptedKeyText = new System.Windows.Forms.TextBox();
            this.protectionScopeLabel = new System.Windows.Forms.Label();
            this.protectionScopeSelector = new System.Windows.Forms.ComboBox();
            this.decryptGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.loginUrlLabel = new System.Windows.Forms.Label();
            this.loginUrlText = new System.Windows.Forms.TextBox();
            this.loginUsernameLabel = new System.Windows.Forms.Label();
            this.loginUsernameText = new System.Windows.Forms.TextBox();
            this.loginPasswordLabel = new System.Windows.Forms.Label();
            this.loginPasswordText = new System.Windows.Forms.TextBox();
            this.chromeNoticeLabel = new System.Windows.Forms.Label();
            this.inputFileGroup.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.decryptGroup.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputFileGroup
            // 
            this.inputFileGroup.Controls.Add(this.chooseStateButton);
            this.inputFileGroup.Controls.Add(this.statePathText);
            this.inputFileGroup.Controls.Add(this.label2);
            this.inputFileGroup.Controls.Add(this.chooseDatabaseButton);
            this.inputFileGroup.Controls.Add(this.databasePathText);
            this.inputFileGroup.Controls.Add(this.label1);
            this.inputFileGroup.Location = new System.Drawing.Point(12, 27);
            this.inputFileGroup.Name = "inputFileGroup";
            this.inputFileGroup.Size = new System.Drawing.Size(543, 91);
            this.inputFileGroup.TabIndex = 1;
            this.inputFileGroup.TabStop = false;
            this.inputFileGroup.Text = "&Input Files";
            // 
            // chooseStateButton
            // 
            this.chooseStateButton.Location = new System.Drawing.Point(437, 55);
            this.chooseStateButton.Name = "chooseStateButton";
            this.chooseStateButton.Size = new System.Drawing.Size(100, 28);
            this.chooseStateButton.TabIndex = 5;
            this.chooseStateButton.Text = "選択";
            this.chooseStateButton.UseVisualStyleBackColor = true;
            this.chooseStateButton.Click += new System.EventHandler(this.OnChooseStateClick);
            // 
            // statePathText
            // 
            this.statePathText.BackColor = System.Drawing.SystemColors.Control;
            this.statePathText.ForeColor = System.Drawing.Color.Blue;
            this.statePathText.Location = new System.Drawing.Point(75, 56);
            this.statePathText.Name = "statePathText";
            this.statePathText.ReadOnly = true;
            this.statePathText.Size = new System.Drawing.Size(356, 25);
            this.statePathText.TabIndex = 4;
            this.statePathText.Text = "#";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "State";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chooseDatabaseButton
            // 
            this.chooseDatabaseButton.Location = new System.Drawing.Point(437, 21);
            this.chooseDatabaseButton.Name = "chooseDatabaseButton";
            this.chooseDatabaseButton.Size = new System.Drawing.Size(100, 28);
            this.chooseDatabaseButton.TabIndex = 2;
            this.chooseDatabaseButton.Text = "選択";
            this.chooseDatabaseButton.UseVisualStyleBackColor = true;
            this.chooseDatabaseButton.Click += new System.EventHandler(this.OnChooseDatabaseClick);
            // 
            // databasePathText
            // 
            this.databasePathText.BackColor = System.Drawing.SystemColors.Control;
            this.databasePathText.ForeColor = System.Drawing.Color.Blue;
            this.databasePathText.Location = new System.Drawing.Point(75, 22);
            this.databasePathText.Name = "databasePathText";
            this.databasePathText.ReadOnly = true;
            this.databasePathText.Size = new System.Drawing.Size(356, 25);
            this.databasePathText.TabIndex = 1;
            this.databasePathText.Text = "#";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1025, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileSaveCsvMenuItem,
            this.fileSearchLoginDataMenuItem,
            this.toolStripSeparator1,
            this.fileExitMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(67, 20);
            this.fileMenu.Text = "ファイル(&F)";
            // 
            // fileSaveCsvMenuItem
            // 
            this.fileSaveCsvMenuItem.Enabled = false;
            this.fileSaveCsvMenuItem.Name = "fileSaveCsvMenuItem";
            this.fileSaveCsvMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.fileSaveCsvMenuItem.Size = new System.Drawing.Size(304, 22);
            this.fileSaveCsvMenuItem.Text = "複合化データをCSVファイルで保存";
            this.fileSaveCsvMenuItem.Click += new System.EventHandler(this.OnFileSaveToCsvMenuClick);
            // 
            // fileSearchLoginDataMenuItem
            // 
            this.fileSearchLoginDataMenuItem.Name = "fileSearchLoginDataMenuItem";
            this.fileSearchLoginDataMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.fileSearchLoginDataMenuItem.Size = new System.Drawing.Size(304, 22);
            this.fileSearchLoginDataMenuItem.Text = "ログインデータの自動検出";
            this.fileSearchLoginDataMenuItem.Click += new System.EventHandler(this.OnFileSearchLoginDataMenuClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(301, 6);
            // 
            // fileExitMenuItem
            // 
            this.fileExitMenuItem.Name = "fileExitMenuItem";
            this.fileExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.fileExitMenuItem.Size = new System.Drawing.Size(304, 22);
            this.fileExitMenuItem.Text = "終了(&X)";
            this.fileExitMenuItem.Click += new System.EventHandler(this.OnFileExitMenuClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 674);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1025, 22);
            this.statusStrip.TabIndex = 10;
            this.statusStrip.Text = "statusStrip1";
            // 
            // loginList
            // 
            this.loginList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.loginIdHeader,
            this.loginUrlHeader,
            this.loginUsernameHeader,
            this.loginPasswordHeader,
            this.loginPasswordTypeHeader,
            this.loginCreatedAtHeader});
            this.loginList.FullRowSelect = true;
            this.loginList.GridLines = true;
            this.loginList.HideSelection = false;
            this.loginList.Location = new System.Drawing.Point(12, 296);
            this.loginList.Name = "loginList";
            this.loginList.Size = new System.Drawing.Size(1001, 238);
            this.loginList.TabIndex = 8;
            this.loginList.UseCompatibleStateImageBehavior = false;
            this.loginList.View = System.Windows.Forms.View.Details;
            this.loginList.VirtualMode = true;
            this.loginList.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.OnLoginRetrieveVirtualItem);
            this.loginList.SelectedIndexChanged += new System.EventHandler(this.OnLoginSelectedIndexChanged);
            // 
            // loginIdHeader
            // 
            this.loginIdHeader.Text = "ID";
            // 
            // loginUrlHeader
            // 
            this.loginUrlHeader.Text = "URL";
            this.loginUrlHeader.Width = 235;
            // 
            // loginUsernameHeader
            // 
            this.loginUsernameHeader.Text = "ユーザ名";
            this.loginUsernameHeader.Width = 120;
            // 
            // loginPasswordHeader
            // 
            this.loginPasswordHeader.Text = "パスワード";
            this.loginPasswordHeader.Width = 300;
            // 
            // loginPasswordTypeHeader
            // 
            this.loginPasswordTypeHeader.Text = "パスワードタイプ";
            this.loginPasswordTypeHeader.Width = 120;
            // 
            // loginCreatedAtHeader
            // 
            this.loginCreatedAtHeader.Text = "登録日時";
            this.loginCreatedAtHeader.Width = 130;
            // 
            // loginsLabel
            // 
            this.loginsLabel.AutoSize = true;
            this.loginsLabel.Location = new System.Drawing.Point(9, 275);
            this.loginsLabel.Name = "loginsLabel";
            this.loginsLabel.Size = new System.Drawing.Size(45, 18);
            this.loginsLabel.TabIndex = 7;
            this.loginsLabel.Text = "&Logins";
            // 
            // encryptedKeyLabel
            // 
            this.encryptedKeyLabel.AutoSize = true;
            this.encryptedKeyLabel.Location = new System.Drawing.Point(9, 164);
            this.encryptedKeyLabel.Name = "encryptedKeyLabel";
            this.encryptedKeyLabel.Size = new System.Drawing.Size(68, 18);
            this.encryptedKeyLabel.TabIndex = 5;
            this.encryptedKeyLabel.Text = "暗号化キー";
            // 
            // encryptedKeyText
            // 
            this.encryptedKeyText.AcceptsReturn = true;
            this.encryptedKeyText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.encryptedKeyText.BackColor = System.Drawing.SystemColors.Control;
            this.encryptedKeyText.ForeColor = System.Drawing.Color.Blue;
            this.encryptedKeyText.Location = new System.Drawing.Point(12, 185);
            this.encryptedKeyText.Multiline = true;
            this.encryptedKeyText.Name = "encryptedKeyText";
            this.encryptedKeyText.ReadOnly = true;
            this.encryptedKeyText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.encryptedKeyText.Size = new System.Drawing.Size(1001, 77);
            this.encryptedKeyText.TabIndex = 6;
            // 
            // protectionScopeLabel
            // 
            this.protectionScopeLabel.AutoSize = true;
            this.protectionScopeLabel.Location = new System.Drawing.Point(579, 31);
            this.protectionScopeLabel.Name = "protectionScopeLabel";
            this.protectionScopeLabel.Size = new System.Drawing.Size(130, 18);
            this.protectionScopeLabel.TabIndex = 3;
            this.protectionScopeLabel.Text = "DataProtectionScope";
            // 
            // protectionScopeSelector
            // 
            this.protectionScopeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.protectionScopeSelector.FormattingEnabled = true;
            this.protectionScopeSelector.Location = new System.Drawing.Point(582, 52);
            this.protectionScopeSelector.Name = "protectionScopeSelector";
            this.protectionScopeSelector.Size = new System.Drawing.Size(259, 26);
            this.protectionScopeSelector.TabIndex = 4;
            // 
            // decryptGroup
            // 
            this.decryptGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.decryptGroup.Controls.Add(this.tableLayoutPanel1);
            this.decryptGroup.Location = new System.Drawing.Point(12, 540);
            this.decryptGroup.Name = "decryptGroup";
            this.decryptGroup.Size = new System.Drawing.Size(483, 131);
            this.decryptGroup.TabIndex = 9;
            this.decryptGroup.TabStop = false;
            this.decryptGroup.Text = "複合化";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 351F));
            this.tableLayoutPanel1.Controls.Add(this.loginUrlLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.loginUrlText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.loginUsernameLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.loginUsernameText, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.loginPasswordLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.loginPasswordText, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(468, 96);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // loginUrlLabel
            // 
            this.loginUrlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginUrlLabel.AutoSize = true;
            this.loginUrlLabel.Location = new System.Drawing.Point(3, 0);
            this.loginUrlLabel.Name = "loginUrlLabel";
            this.loginUrlLabel.Size = new System.Drawing.Size(111, 32);
            this.loginUrlLabel.TabIndex = 0;
            this.loginUrlLabel.Text = "URL";
            this.loginUrlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loginUrlText
            // 
            this.loginUrlText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginUrlText.BackColor = System.Drawing.SystemColors.Control;
            this.loginUrlText.ForeColor = System.Drawing.Color.Blue;
            this.loginUrlText.Location = new System.Drawing.Point(120, 3);
            this.loginUrlText.Name = "loginUrlText";
            this.loginUrlText.ReadOnly = true;
            this.loginUrlText.Size = new System.Drawing.Size(345, 25);
            this.loginUrlText.TabIndex = 1;
            this.loginUrlText.Text = "#";
            // 
            // loginUsernameLabel
            // 
            this.loginUsernameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginUsernameLabel.AutoSize = true;
            this.loginUsernameLabel.Location = new System.Drawing.Point(3, 32);
            this.loginUsernameLabel.Name = "loginUsernameLabel";
            this.loginUsernameLabel.Size = new System.Drawing.Size(111, 32);
            this.loginUsernameLabel.TabIndex = 2;
            this.loginUsernameLabel.Text = "ユーザ名";
            this.loginUsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loginUsernameText
            // 
            this.loginUsernameText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginUsernameText.BackColor = System.Drawing.SystemColors.Control;
            this.loginUsernameText.ForeColor = System.Drawing.Color.Blue;
            this.loginUsernameText.Location = new System.Drawing.Point(120, 35);
            this.loginUsernameText.Name = "loginUsernameText";
            this.loginUsernameText.ReadOnly = true;
            this.loginUsernameText.Size = new System.Drawing.Size(345, 25);
            this.loginUsernameText.TabIndex = 3;
            this.loginUsernameText.Text = "#";
            // 
            // loginPasswordLabel
            // 
            this.loginPasswordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginPasswordLabel.AutoSize = true;
            this.loginPasswordLabel.Location = new System.Drawing.Point(3, 64);
            this.loginPasswordLabel.Name = "loginPasswordLabel";
            this.loginPasswordLabel.Size = new System.Drawing.Size(111, 32);
            this.loginPasswordLabel.TabIndex = 4;
            this.loginPasswordLabel.Text = "パスワード";
            this.loginPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loginPasswordText
            // 
            this.loginPasswordText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginPasswordText.BackColor = System.Drawing.SystemColors.Control;
            this.loginPasswordText.ForeColor = System.Drawing.Color.Blue;
            this.loginPasswordText.Location = new System.Drawing.Point(120, 67);
            this.loginPasswordText.Name = "loginPasswordText";
            this.loginPasswordText.ReadOnly = true;
            this.loginPasswordText.Size = new System.Drawing.Size(345, 25);
            this.loginPasswordText.TabIndex = 5;
            this.loginPasswordText.Text = "#";
            // 
            // chromeNoticeLabel
            // 
            this.chromeNoticeLabel.AutoSize = true;
            this.chromeNoticeLabel.ForeColor = System.Drawing.Color.Coral;
            this.chromeNoticeLabel.Location = new System.Drawing.Point(12, 121);
            this.chromeNoticeLabel.Name = "chromeNoticeLabel";
            this.chromeNoticeLabel.Size = new System.Drawing.Size(562, 36);
            this.chromeNoticeLabel.TabIndex = 2;
            this.chromeNoticeLabel.Text = "アプリケーションデータディレクトリに存在するデータを対象に複合化を実行する際,\r\nGoogle Chrome が起動中の場合データベースにロックが掛かっているため" +
    "予期せぬ動作を起こします.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 696);
            this.Controls.Add(this.chromeNoticeLabel);
            this.Controls.Add(this.decryptGroup);
            this.Controls.Add(this.protectionScopeSelector);
            this.Controls.Add(this.protectionScopeLabel);
            this.Controls.Add(this.encryptedKeyText);
            this.Controls.Add(this.encryptedKeyLabel);
            this.Controls.Add(this.loginsLabel);
            this.Controls.Add(this.loginList);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.inputFileGroup);
            this.Controls.Add(this.mainMenuStrip);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Chloris.Chrome.Decryptor";
            this.Load += new System.EventHandler(this.OnLoad);
            this.inputFileGroup.ResumeLayout(false);
            this.inputFileGroup.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.decryptGroup.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox inputFileGroup;
        private System.Windows.Forms.Button chooseStateButton;
        private System.Windows.Forms.TextBox statePathText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button chooseDatabaseButton;
        private System.Windows.Forms.TextBox databasePathText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ListView loginList;
        private System.Windows.Forms.Label loginsLabel;
        private System.Windows.Forms.ColumnHeader loginIdHeader;
        private System.Windows.Forms.ColumnHeader loginUrlHeader;
        private System.Windows.Forms.ColumnHeader loginUsernameHeader;
        private System.Windows.Forms.ColumnHeader loginPasswordHeader;
        private System.Windows.Forms.ColumnHeader loginPasswordTypeHeader;
        private System.Windows.Forms.ColumnHeader loginCreatedAtHeader;
        private System.Windows.Forms.Label encryptedKeyLabel;
        private System.Windows.Forms.TextBox encryptedKeyText;
        private System.Windows.Forms.Label protectionScopeLabel;
        private System.Windows.Forms.ComboBox protectionScopeSelector;
        private System.Windows.Forms.GroupBox decryptGroup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label loginUrlLabel;
        private System.Windows.Forms.TextBox loginUrlText;
        private System.Windows.Forms.Label loginUsernameLabel;
        private System.Windows.Forms.TextBox loginUsernameText;
        private System.Windows.Forms.Label loginPasswordLabel;
        private System.Windows.Forms.TextBox loginPasswordText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSaveCsvMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSearchLoginDataMenuItem;
        private System.Windows.Forms.Label chromeNoticeLabel;
    }
}

