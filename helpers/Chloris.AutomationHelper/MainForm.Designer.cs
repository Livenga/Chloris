namespace Chloris.AutomationHelper
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.windowSearchGroup = new System.Windows.Forms.GroupBox();
            this.searchTextLabel = new System.Windows.Forms.Label();
            this.windowSearchTextText = new System.Windows.Forms.TextBox();
            this.windowSearchButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.targetWindowLayout = new System.Windows.Forms.TableLayoutPanel();
            this.targetWindowHandleLabel = new System.Windows.Forms.Label();
            this.targetWindowHandleText = new System.Windows.Forms.TextBox();
            this.targetWindowText = new System.Windows.Forms.Label();
            this.targetWindowTextText = new System.Windows.Forms.TextBox();
            this.mainMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.windowSearchGroup.SuspendLayout();
            this.targetWindowLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(954, 24);
            this.mainMenuStrip.TabIndex = 0;
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.fileExitMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(67, 20);
            this.fileMenu.Text = "ファイル(&F)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // fileExitMenuItem
            // 
            this.fileExitMenuItem.Name = "fileExitMenuItem";
            this.fileExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.fileExitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fileExitMenuItem.Text = "終了(&X)";
            this.fileExitMenuItem.Click += new System.EventHandler(this.OnFileExitMenuClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 515);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(954, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // windowSearchGroup
            // 
            this.windowSearchGroup.Controls.Add(this.targetWindowLayout);
            this.windowSearchGroup.Controls.Add(this.windowSearchButton);
            this.windowSearchGroup.Controls.Add(this.windowSearchTextText);
            this.windowSearchGroup.Controls.Add(this.searchTextLabel);
            this.windowSearchGroup.Location = new System.Drawing.Point(12, 27);
            this.windowSearchGroup.Name = "windowSearchGroup";
            this.windowSearchGroup.Size = new System.Drawing.Size(354, 123);
            this.windowSearchGroup.TabIndex = 2;
            this.windowSearchGroup.TabStop = false;
            this.windowSearchGroup.Text = "&Search Window";
            // 
            // searchTextLabel
            // 
            this.searchTextLabel.AutoSize = true;
            this.searchTextLabel.Location = new System.Drawing.Point(6, 24);
            this.searchTextLabel.Name = "searchTextLabel";
            this.searchTextLabel.Size = new System.Drawing.Size(46, 18);
            this.searchTextLabel.TabIndex = 0;
            this.searchTextLabel.Text = "Target";
            this.searchTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // windowSearchTextText
            // 
            this.windowSearchTextText.Location = new System.Drawing.Point(58, 21);
            this.windowSearchTextText.Name = "windowSearchTextText";
            this.windowSearchTextText.Size = new System.Drawing.Size(188, 25);
            this.windowSearchTextText.TabIndex = 1;
            // 
            // windowSearchButton
            // 
            this.windowSearchButton.Location = new System.Drawing.Point(252, 20);
            this.windowSearchButton.Name = "windowSearchButton";
            this.windowSearchButton.Size = new System.Drawing.Size(96, 27);
            this.windowSearchButton.TabIndex = 2;
            this.windowSearchButton.Text = "&Search";
            this.windowSearchButton.UseVisualStyleBackColor = true;
            this.windowSearchButton.Click += new System.EventHandler(this.OnWindowSearchFromTextClick);
            // 
            // statusLabel
            // 
            this.statusLabel.ForeColor = System.Drawing.Color.Blue;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(14, 17);
            this.statusLabel.Text = "#";
            // 
            // targetWindowLayout
            // 
            this.targetWindowLayout.ColumnCount = 2;
            this.targetWindowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.targetWindowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.targetWindowLayout.Controls.Add(this.targetWindowHandleLabel, 0, 0);
            this.targetWindowLayout.Controls.Add(this.targetWindowHandleText, 1, 0);
            this.targetWindowLayout.Controls.Add(this.targetWindowText, 0, 1);
            this.targetWindowLayout.Controls.Add(this.targetWindowTextText, 1, 1);
            this.targetWindowLayout.Location = new System.Drawing.Point(9, 52);
            this.targetWindowLayout.Name = "targetWindowLayout";
            this.targetWindowLayout.RowCount = 2;
            this.targetWindowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.targetWindowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.targetWindowLayout.Size = new System.Drawing.Size(339, 64);
            this.targetWindowLayout.TabIndex = 3;
            // 
            // targetWindowHandleLabel
            // 
            this.targetWindowHandleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetWindowHandleLabel.AutoSize = true;
            this.targetWindowHandleLabel.Location = new System.Drawing.Point(3, 0);
            this.targetWindowHandleLabel.Name = "targetWindowHandleLabel";
            this.targetWindowHandleLabel.Size = new System.Drawing.Size(58, 32);
            this.targetWindowHandleLabel.TabIndex = 0;
            this.targetWindowHandleLabel.Text = "Handle";
            this.targetWindowHandleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // targetWindowHandleText
            // 
            this.targetWindowHandleText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetWindowHandleText.BackColor = System.Drawing.SystemColors.Control;
            this.targetWindowHandleText.ForeColor = System.Drawing.Color.Blue;
            this.targetWindowHandleText.Location = new System.Drawing.Point(67, 3);
            this.targetWindowHandleText.Name = "targetWindowHandleText";
            this.targetWindowHandleText.ReadOnly = true;
            this.targetWindowHandleText.Size = new System.Drawing.Size(269, 25);
            this.targetWindowHandleText.TabIndex = 1;
            this.targetWindowHandleText.Text = "#";
            // 
            // targetWindowText
            // 
            this.targetWindowText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetWindowText.AutoSize = true;
            this.targetWindowText.Location = new System.Drawing.Point(3, 32);
            this.targetWindowText.Name = "targetWindowText";
            this.targetWindowText.Size = new System.Drawing.Size(58, 32);
            this.targetWindowText.TabIndex = 2;
            this.targetWindowText.Text = "Text";
            this.targetWindowText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // targetWindowTextText
            // 
            this.targetWindowTextText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetWindowTextText.BackColor = System.Drawing.SystemColors.Control;
            this.targetWindowTextText.ForeColor = System.Drawing.Color.Blue;
            this.targetWindowTextText.Location = new System.Drawing.Point(67, 35);
            this.targetWindowTextText.Name = "targetWindowTextText";
            this.targetWindowTextText.ReadOnly = true;
            this.targetWindowTextText.Size = new System.Drawing.Size(269, 25);
            this.targetWindowTextText.TabIndex = 3;
            this.targetWindowTextText.Text = "#";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(954, 537);
            this.Controls.Add(this.windowSearchGroup);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Chloris#Automation Helper";
            this.Load += new System.EventHandler(this.OnLoad);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.windowSearchGroup.ResumeLayout(false);
            this.windowSearchGroup.PerformLayout();
            this.targetWindowLayout.ResumeLayout(false);
            this.targetWindowLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenuItem;
        private System.Windows.Forms.GroupBox windowSearchGroup;
        private System.Windows.Forms.Button windowSearchButton;
        private System.Windows.Forms.TextBox windowSearchTextText;
        private System.Windows.Forms.Label searchTextLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.TableLayoutPanel targetWindowLayout;
        private System.Windows.Forms.Label targetWindowHandleLabel;
        private System.Windows.Forms.TextBox targetWindowHandleText;
        private System.Windows.Forms.Label targetWindowText;
        private System.Windows.Forms.TextBox targetWindowTextText;
    }
}

