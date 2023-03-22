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
            this.components = new System.ComponentModel.Container();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorCursorWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.windowSearchGroup = new System.Windows.Forms.GroupBox();
            this.windowChildTree = new System.Windows.Forms.TreeView();
            this.targetWindowLayout = new System.Windows.Forms.TableLayoutPanel();
            this.targetWindowHandleLabel = new System.Windows.Forms.Label();
            this.targetWindowHandleText = new System.Windows.Forms.TextBox();
            this.targetWindowText = new System.Windows.Forms.Label();
            this.targetWindowTextText = new System.Windows.Forms.TextBox();
            this.windowSearchButton = new System.Windows.Forms.Button();
            this.windowSearchTextText = new System.Windows.Forms.TextBox();
            this.searchTextLabel = new System.Windows.Forms.Label();
            this.windowChildTreeMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.targetNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setNotifyWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTargetWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursorMonitorGroup = new System.Windows.Forms.GroupBox();
            this.monitorLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.monitorHandleLabel = new System.Windows.Forms.Label();
            this.monitorHandleText = new System.Windows.Forms.TextBox();
            this.monitorTextLabel = new System.Windows.Forms.Label();
            this.monitorTextText = new System.Windows.Forms.TextBox();
            this.monitorLocationLabel = new System.Windows.Forms.Label();
            this.monitorLocationText = new System.Windows.Forms.TextBox();
            this.monitorIdLabel = new System.Windows.Forms.Label();
            this.monitorIdText = new System.Windows.Forms.TextBox();
            this.notifyGroup = new System.Windows.Forms.GroupBox();
            this.notifyLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.notifyHandleLabel = new System.Windows.Forms.Label();
            this.notifyHandleText = new System.Windows.Forms.TextBox();
            this.notifyTextLabel = new System.Windows.Forms.Label();
            this.notifyTextText = new System.Windows.Forms.TextBox();
            this.targetGroup = new System.Windows.Forms.GroupBox();
            this.controlOperationTab = new System.Windows.Forms.TabControl();
            this.comboBoxPage = new System.Windows.Forms.TabPage();
            this.textPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.targetTypeLabel = new System.Windows.Forms.Label();
            this.windowSetFocusButton = new System.Windows.Forms.Button();
            this.windowKillFocusButton = new System.Windows.Forms.Button();
            this.selectorOperator = new Chloris.AutomationHelper.Controls.SelectorOpeartionControl();
            this.textOperator = new Chloris.AutomationHelper.Controls.TextBoxOperationControl();
            this.mainMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.windowSearchGroup.SuspendLayout();
            this.targetWindowLayout.SuspendLayout();
            this.windowChildTreeMenuStrip.SuspendLayout();
            this.cursorMonitorGroup.SuspendLayout();
            this.monitorLayoutPanel.SuspendLayout();
            this.notifyGroup.SuspendLayout();
            this.notifyLayoutPanel.SuspendLayout();
            this.targetGroup.SuspendLayout();
            this.controlOperationTab.SuspendLayout();
            this.comboBoxPage.SuspendLayout();
            this.textPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.monitorMenu});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1264, 24);
            this.mainMenuStrip.TabIndex = 0;
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.fileExitMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "&File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // fileExitMenuItem
            // 
            this.fileExitMenuItem.Name = "fileExitMenuItem";
            this.fileExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.fileExitMenuItem.Size = new System.Drawing.Size(133, 22);
            this.fileExitMenuItem.Text = "E&xit";
            this.fileExitMenuItem.Click += new System.EventHandler(this.OnFileExitMenuClick);
            // 
            // monitorMenu
            // 
            this.monitorMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitorCursorWindowMenuItem});
            this.monitorMenu.Name = "monitorMenu";
            this.monitorMenu.Size = new System.Drawing.Size(62, 20);
            this.monitorMenu.Text = "&Monitor";
            // 
            // monitorCursorWindowMenuItem
            // 
            this.monitorCursorWindowMenuItem.Name = "monitorCursorWindowMenuItem";
            this.monitorCursorWindowMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.monitorCursorWindowMenuItem.Size = new System.Drawing.Size(231, 22);
            this.monitorCursorWindowMenuItem.Text = "Cursor &Window";
            this.monitorCursorWindowMenuItem.Click += new System.EventHandler(this.OnMonitorCursorWindowMenuClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 899);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // statusLabel
            // 
            this.statusLabel.ForeColor = System.Drawing.Color.Blue;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(14, 17);
            this.statusLabel.Text = "#";
            // 
            // windowSearchGroup
            // 
            this.windowSearchGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.windowSearchGroup.Controls.Add(this.windowChildTree);
            this.windowSearchGroup.Controls.Add(this.targetWindowLayout);
            this.windowSearchGroup.Controls.Add(this.windowSearchButton);
            this.windowSearchGroup.Controls.Add(this.windowSearchTextText);
            this.windowSearchGroup.Controls.Add(this.searchTextLabel);
            this.windowSearchGroup.Location = new System.Drawing.Point(12, 27);
            this.windowSearchGroup.Name = "windowSearchGroup";
            this.windowSearchGroup.Size = new System.Drawing.Size(450, 869);
            this.windowSearchGroup.TabIndex = 2;
            this.windowSearchGroup.TabStop = false;
            this.windowSearchGroup.Text = "&Search Window";
            // 
            // windowChildTree
            // 
            this.windowChildTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.windowChildTree.Location = new System.Drawing.Point(6, 123);
            this.windowChildTree.Name = "windowChildTree";
            this.windowChildTree.Size = new System.Drawing.Size(438, 740);
            this.windowChildTree.TabIndex = 4;
            this.windowChildTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.OnWindowChildTreeBeforeExpand);
            this.windowChildTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnWindowChildTreeNodeMouseClick);
            // 
            // targetWindowLayout
            // 
            this.targetWindowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.targetWindowLayout.Size = new System.Drawing.Size(435, 64);
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
            this.targetWindowHandleText.Size = new System.Drawing.Size(365, 25);
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
            this.targetWindowTextText.Size = new System.Drawing.Size(365, 25);
            this.targetWindowTextText.TabIndex = 3;
            this.targetWindowTextText.Text = "#";
            // 
            // windowSearchButton
            // 
            this.windowSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.windowSearchButton.Location = new System.Drawing.Point(348, 20);
            this.windowSearchButton.Name = "windowSearchButton";
            this.windowSearchButton.Size = new System.Drawing.Size(96, 27);
            this.windowSearchButton.TabIndex = 2;
            this.windowSearchButton.Text = "&Search";
            this.windowSearchButton.UseVisualStyleBackColor = true;
            this.windowSearchButton.Click += new System.EventHandler(this.OnWindowSearchFromTextClick);
            // 
            // windowSearchTextText
            // 
            this.windowSearchTextText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.windowSearchTextText.Location = new System.Drawing.Point(58, 21);
            this.windowSearchTextText.Name = "windowSearchTextText";
            this.windowSearchTextText.Size = new System.Drawing.Size(284, 25);
            this.windowSearchTextText.TabIndex = 1;
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
            // windowChildTreeMenuStrip
            // 
            this.windowChildTreeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.targetNodeMenuItem});
            this.windowChildTreeMenuStrip.Name = "windowChildTreeMenuStrip";
            this.windowChildTreeMenuStrip.Size = new System.Drawing.Size(96, 26);
            this.windowChildTreeMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.OnWindowChildTreeMenuOpening);
            // 
            // targetNodeMenuItem
            // 
            this.targetNodeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setNotifyWindowMenuItem,
            this.setTargetWindowMenuItem});
            this.targetNodeMenuItem.Name = "targetNodeMenuItem";
            this.targetNodeMenuItem.Size = new System.Drawing.Size(95, 22);
            this.targetNodeMenuItem.Text = "###";
            // 
            // setNotifyWindowMenuItem
            // 
            this.setNotifyWindowMenuItem.Name = "setNotifyWindowMenuItem";
            this.setNotifyWindowMenuItem.Size = new System.Drawing.Size(173, 22);
            this.setNotifyWindowMenuItem.Text = "Set &Notify Window";
            this.setNotifyWindowMenuItem.Click += new System.EventHandler(this.OnSetNotifyWindowMenuClick);
            // 
            // setTargetWindowMenuItem
            // 
            this.setTargetWindowMenuItem.Name = "setTargetWindowMenuItem";
            this.setTargetWindowMenuItem.Size = new System.Drawing.Size(173, 22);
            this.setTargetWindowMenuItem.Text = "Set &Target Window";
            this.setTargetWindowMenuItem.Click += new System.EventHandler(this.OnSetTargetWindowMenuClick);
            // 
            // cursorMonitorGroup
            // 
            this.cursorMonitorGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cursorMonitorGroup.Controls.Add(this.monitorLayoutPanel);
            this.cursorMonitorGroup.Enabled = false;
            this.cursorMonitorGroup.Location = new System.Drawing.Point(842, 737);
            this.cursorMonitorGroup.Name = "cursorMonitorGroup";
            this.cursorMonitorGroup.Size = new System.Drawing.Size(410, 159);
            this.cursorMonitorGroup.TabIndex = 5;
            this.cursorMonitorGroup.TabStop = false;
            this.cursorMonitorGroup.Text = "Monitor";
            // 
            // monitorLayoutPanel
            // 
            this.monitorLayoutPanel.ColumnCount = 2;
            this.monitorLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.monitorLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.monitorLayoutPanel.Controls.Add(this.monitorHandleLabel, 0, 0);
            this.monitorLayoutPanel.Controls.Add(this.monitorHandleText, 1, 0);
            this.monitorLayoutPanel.Controls.Add(this.monitorTextLabel, 0, 3);
            this.monitorLayoutPanel.Controls.Add(this.monitorTextText, 1, 3);
            this.monitorLayoutPanel.Controls.Add(this.monitorLocationLabel, 0, 2);
            this.monitorLayoutPanel.Controls.Add(this.monitorLocationText, 1, 2);
            this.monitorLayoutPanel.Controls.Add(this.monitorIdLabel, 0, 1);
            this.monitorLayoutPanel.Controls.Add(this.monitorIdText, 1, 1);
            this.monitorLayoutPanel.Location = new System.Drawing.Point(6, 24);
            this.monitorLayoutPanel.Name = "monitorLayoutPanel";
            this.monitorLayoutPanel.RowCount = 4;
            this.monitorLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.monitorLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.monitorLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.monitorLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.monitorLayoutPanel.Size = new System.Drawing.Size(398, 128);
            this.monitorLayoutPanel.TabIndex = 0;
            // 
            // monitorHandleLabel
            // 
            this.monitorHandleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monitorHandleLabel.AutoSize = true;
            this.monitorHandleLabel.Location = new System.Drawing.Point(3, 0);
            this.monitorHandleLabel.Name = "monitorHandleLabel";
            this.monitorHandleLabel.Size = new System.Drawing.Size(94, 32);
            this.monitorHandleLabel.TabIndex = 0;
            this.monitorHandleLabel.Text = "Handle";
            this.monitorHandleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // monitorHandleText
            // 
            this.monitorHandleText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monitorHandleText.BackColor = System.Drawing.SystemColors.Control;
            this.monitorHandleText.ForeColor = System.Drawing.Color.Blue;
            this.monitorHandleText.Location = new System.Drawing.Point(103, 3);
            this.monitorHandleText.Name = "monitorHandleText";
            this.monitorHandleText.ReadOnly = true;
            this.monitorHandleText.Size = new System.Drawing.Size(292, 25);
            this.monitorHandleText.TabIndex = 1;
            this.monitorHandleText.Text = "#";
            // 
            // monitorTextLabel
            // 
            this.monitorTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monitorTextLabel.AutoSize = true;
            this.monitorTextLabel.Location = new System.Drawing.Point(3, 96);
            this.monitorTextLabel.Name = "monitorTextLabel";
            this.monitorTextLabel.Size = new System.Drawing.Size(94, 32);
            this.monitorTextLabel.TabIndex = 6;
            this.monitorTextLabel.Text = "Text";
            this.monitorTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // monitorTextText
            // 
            this.monitorTextText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monitorTextText.BackColor = System.Drawing.SystemColors.Control;
            this.monitorTextText.ForeColor = System.Drawing.Color.Blue;
            this.monitorTextText.Location = new System.Drawing.Point(103, 99);
            this.monitorTextText.Name = "monitorTextText";
            this.monitorTextText.ReadOnly = true;
            this.monitorTextText.Size = new System.Drawing.Size(292, 25);
            this.monitorTextText.TabIndex = 7;
            this.monitorTextText.Text = "#";
            // 
            // monitorLocationLabel
            // 
            this.monitorLocationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monitorLocationLabel.AutoSize = true;
            this.monitorLocationLabel.Location = new System.Drawing.Point(3, 64);
            this.monitorLocationLabel.Name = "monitorLocationLabel";
            this.monitorLocationLabel.Size = new System.Drawing.Size(94, 32);
            this.monitorLocationLabel.TabIndex = 4;
            this.monitorLocationLabel.Text = "Location";
            this.monitorLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // monitorLocationText
            // 
            this.monitorLocationText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monitorLocationText.BackColor = System.Drawing.SystemColors.Control;
            this.monitorLocationText.ForeColor = System.Drawing.Color.Blue;
            this.monitorLocationText.Location = new System.Drawing.Point(103, 67);
            this.monitorLocationText.Name = "monitorLocationText";
            this.monitorLocationText.ReadOnly = true;
            this.monitorLocationText.Size = new System.Drawing.Size(292, 25);
            this.monitorLocationText.TabIndex = 5;
            this.monitorLocationText.Text = "#";
            // 
            // monitorIdLabel
            // 
            this.monitorIdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monitorIdLabel.AutoSize = true;
            this.monitorIdLabel.Location = new System.Drawing.Point(3, 32);
            this.monitorIdLabel.Name = "monitorIdLabel";
            this.monitorIdLabel.Size = new System.Drawing.Size(94, 32);
            this.monitorIdLabel.TabIndex = 2;
            this.monitorIdLabel.Text = "ID";
            this.monitorIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // monitorIdText
            // 
            this.monitorIdText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monitorIdText.BackColor = System.Drawing.SystemColors.Control;
            this.monitorIdText.ForeColor = System.Drawing.Color.Blue;
            this.monitorIdText.Location = new System.Drawing.Point(103, 35);
            this.monitorIdText.Name = "monitorIdText";
            this.monitorIdText.ReadOnly = true;
            this.monitorIdText.Size = new System.Drawing.Size(292, 25);
            this.monitorIdText.TabIndex = 3;
            this.monitorIdText.Text = "#";
            // 
            // notifyGroup
            // 
            this.notifyGroup.Controls.Add(this.notifyLayoutPanel);
            this.notifyGroup.Location = new System.Drawing.Point(468, 28);
            this.notifyGroup.Name = "notifyGroup";
            this.notifyGroup.Size = new System.Drawing.Size(784, 97);
            this.notifyGroup.TabIndex = 3;
            this.notifyGroup.TabStop = false;
            this.notifyGroup.Text = "Notify";
            // 
            // notifyLayoutPanel
            // 
            this.notifyLayoutPanel.ColumnCount = 2;
            this.notifyLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.notifyLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.notifyLayoutPanel.Controls.Add(this.notifyHandleLabel, 0, 0);
            this.notifyLayoutPanel.Controls.Add(this.notifyHandleText, 1, 0);
            this.notifyLayoutPanel.Controls.Add(this.notifyTextLabel, 0, 1);
            this.notifyLayoutPanel.Controls.Add(this.notifyTextText, 1, 1);
            this.notifyLayoutPanel.Location = new System.Drawing.Point(6, 24);
            this.notifyLayoutPanel.Name = "notifyLayoutPanel";
            this.notifyLayoutPanel.RowCount = 2;
            this.notifyLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.notifyLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.notifyLayoutPanel.Size = new System.Drawing.Size(769, 64);
            this.notifyLayoutPanel.TabIndex = 0;
            // 
            // notifyHandleLabel
            // 
            this.notifyHandleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notifyHandleLabel.AutoSize = true;
            this.notifyHandleLabel.Location = new System.Drawing.Point(3, 0);
            this.notifyHandleLabel.Name = "notifyHandleLabel";
            this.notifyHandleLabel.Size = new System.Drawing.Size(122, 32);
            this.notifyHandleLabel.TabIndex = 0;
            this.notifyHandleLabel.Text = "Handle";
            this.notifyHandleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notifyHandleText
            // 
            this.notifyHandleText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notifyHandleText.BackColor = System.Drawing.SystemColors.Control;
            this.notifyHandleText.ForeColor = System.Drawing.Color.Blue;
            this.notifyHandleText.Location = new System.Drawing.Point(131, 3);
            this.notifyHandleText.Name = "notifyHandleText";
            this.notifyHandleText.ReadOnly = true;
            this.notifyHandleText.Size = new System.Drawing.Size(635, 25);
            this.notifyHandleText.TabIndex = 1;
            this.notifyHandleText.Text = "#";
            // 
            // notifyTextLabel
            // 
            this.notifyTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notifyTextLabel.AutoSize = true;
            this.notifyTextLabel.Location = new System.Drawing.Point(3, 32);
            this.notifyTextLabel.Name = "notifyTextLabel";
            this.notifyTextLabel.Size = new System.Drawing.Size(122, 32);
            this.notifyTextLabel.TabIndex = 2;
            this.notifyTextLabel.Text = "Text";
            this.notifyTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notifyTextText
            // 
            this.notifyTextText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notifyTextText.BackColor = System.Drawing.SystemColors.Control;
            this.notifyTextText.ForeColor = System.Drawing.Color.Blue;
            this.notifyTextText.Location = new System.Drawing.Point(131, 35);
            this.notifyTextText.Name = "notifyTextText";
            this.notifyTextText.ReadOnly = true;
            this.notifyTextText.Size = new System.Drawing.Size(635, 25);
            this.notifyTextText.TabIndex = 3;
            this.notifyTextText.Text = "#";
            // 
            // targetGroup
            // 
            this.targetGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetGroup.Controls.Add(this.windowKillFocusButton);
            this.targetGroup.Controls.Add(this.windowSetFocusButton);
            this.targetGroup.Controls.Add(this.controlOperationTab);
            this.targetGroup.Controls.Add(this.tableLayoutPanel1);
            this.targetGroup.Controls.Add(this.targetTypeLabel);
            this.targetGroup.Location = new System.Drawing.Point(468, 131);
            this.targetGroup.Name = "targetGroup";
            this.targetGroup.Size = new System.Drawing.Size(784, 600);
            this.targetGroup.TabIndex = 4;
            this.targetGroup.TabStop = false;
            this.targetGroup.Text = "Target";
            // 
            // controlOperationTab
            // 
            this.controlOperationTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlOperationTab.Controls.Add(this.comboBoxPage);
            this.controlOperationTab.Controls.Add(this.textPage);
            this.controlOperationTab.Location = new System.Drawing.Point(12, 146);
            this.controlOperationTab.Name = "controlOperationTab";
            this.controlOperationTab.SelectedIndex = 0;
            this.controlOperationTab.Size = new System.Drawing.Size(763, 448);
            this.controlOperationTab.TabIndex = 4;
            // 
            // comboBoxPage
            // 
            this.comboBoxPage.Controls.Add(this.selectorOperator);
            this.comboBoxPage.Location = new System.Drawing.Point(4, 27);
            this.comboBoxPage.Name = "comboBoxPage";
            this.comboBoxPage.Padding = new System.Windows.Forms.Padding(3);
            this.comboBoxPage.Size = new System.Drawing.Size(755, 417);
            this.comboBoxPage.TabIndex = 0;
            this.comboBoxPage.Text = "ComboBox";
            this.comboBoxPage.UseVisualStyleBackColor = true;
            // 
            // textPage
            // 
            this.textPage.Controls.Add(this.textOperator);
            this.textPage.Location = new System.Drawing.Point(4, 22);
            this.textPage.Name = "textPage";
            this.textPage.Padding = new System.Windows.Forms.Padding(3);
            this.textPage.Size = new System.Drawing.Size(755, 422);
            this.textPage.TabIndex = 1;
            this.textPage.Text = "TextBox";
            this.textPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 42);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 64);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(119, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(638, 25);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(119, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(638, 25);
            this.textBox2.TabIndex = 3;
            // 
            // targetTypeLabel
            // 
            this.targetTypeLabel.AutoSize = true;
            this.targetTypeLabel.ForeColor = System.Drawing.Color.Blue;
            this.targetTypeLabel.Location = new System.Drawing.Point(9, 21);
            this.targetTypeLabel.Name = "targetTypeLabel";
            this.targetTypeLabel.Size = new System.Drawing.Size(18, 18);
            this.targetTypeLabel.TabIndex = 0;
            this.targetTypeLabel.Text = "#";
            // 
            // windowSetFocusButton
            // 
            this.windowSetFocusButton.Location = new System.Drawing.Point(526, 112);
            this.windowSetFocusButton.Name = "windowSetFocusButton";
            this.windowSetFocusButton.Size = new System.Drawing.Size(120, 28);
            this.windowSetFocusButton.TabIndex = 2;
            this.windowSetFocusButton.Text = "WM_SETFOCUS";
            this.windowSetFocusButton.UseVisualStyleBackColor = true;
            this.windowSetFocusButton.Click += new System.EventHandler(this.OnWindowSetFocusClick);
            // 
            // windowKillFocusButton
            // 
            this.windowKillFocusButton.Location = new System.Drawing.Point(652, 112);
            this.windowKillFocusButton.Name = "windowKillFocusButton";
            this.windowKillFocusButton.Size = new System.Drawing.Size(120, 28);
            this.windowKillFocusButton.TabIndex = 3;
            this.windowKillFocusButton.Text = "WM_KILLFOCUS";
            this.windowKillFocusButton.UseVisualStyleBackColor = true;
            this.windowKillFocusButton.Click += new System.EventHandler(this.OnWindowKillFocusClick);
            // 
            // selectorOperator
            // 
            this.selectorOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectorOperator.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.selectorOperator.Location = new System.Drawing.Point(3, 3);
            this.selectorOperator.Margin = new System.Windows.Forms.Padding(22, 364, 22, 364);
            this.selectorOperator.Name = "selectorOperator";
// TODO: 例外 '無効な Primitive 型 System.IntPtr です。CodeObjectCreateExpression を使ってください。' によって '' のコード生成が失敗しました。
            this.selectorOperator.Size = new System.Drawing.Size(749, 411);
            this.selectorOperator.TabIndex = 0;
// TODO: 例外 '無効な Primitive 型 System.IntPtr です。CodeObjectCreateExpression を使ってください。' によって '' のコード生成が失敗しました。
            // 
            // textOperator
            // 
            this.textOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textOperator.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textOperator.Location = new System.Drawing.Point(3, 3);
            this.textOperator.Name = "textOperator";
// TODO: 例外 '無効な Primitive 型 System.IntPtr です。CodeObjectCreateExpression を使ってください。' によって '' のコード生成が失敗しました。
            this.textOperator.Size = new System.Drawing.Size(749, 416);
            this.textOperator.TabIndex = 0;
// TODO: 例外 '無効な Primitive 型 System.IntPtr です。CodeObjectCreateExpression を使ってください。' によって '' のコード生成が失敗しました。
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 921);
            this.Controls.Add(this.targetGroup);
            this.Controls.Add(this.notifyGroup);
            this.Controls.Add(this.cursorMonitorGroup);
            this.Controls.Add(this.windowSearchGroup);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Chloris#Automation Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.windowSearchGroup.ResumeLayout(false);
            this.windowSearchGroup.PerformLayout();
            this.targetWindowLayout.ResumeLayout(false);
            this.targetWindowLayout.PerformLayout();
            this.windowChildTreeMenuStrip.ResumeLayout(false);
            this.cursorMonitorGroup.ResumeLayout(false);
            this.monitorLayoutPanel.ResumeLayout(false);
            this.monitorLayoutPanel.PerformLayout();
            this.notifyGroup.ResumeLayout(false);
            this.notifyLayoutPanel.ResumeLayout(false);
            this.notifyLayoutPanel.PerformLayout();
            this.targetGroup.ResumeLayout(false);
            this.targetGroup.PerformLayout();
            this.controlOperationTab.ResumeLayout(false);
            this.comboBoxPage.ResumeLayout(false);
            this.textPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem monitorMenu;
        private System.Windows.Forms.ToolStripMenuItem monitorCursorWindowMenuItem;
        private System.Windows.Forms.GroupBox cursorMonitorGroup;
        private System.Windows.Forms.TableLayoutPanel monitorLayoutPanel;
        private System.Windows.Forms.Label monitorHandleLabel;
        private System.Windows.Forms.TextBox monitorHandleText;
        private System.Windows.Forms.Label monitorLocationLabel;
        private System.Windows.Forms.TextBox monitorLocationText;
        private System.Windows.Forms.Label monitorTextLabel;
        private System.Windows.Forms.TextBox monitorTextText;
        private System.Windows.Forms.Label monitorIdLabel;
        private System.Windows.Forms.TextBox monitorIdText;
        private System.Windows.Forms.TreeView windowChildTree;
        private System.Windows.Forms.ContextMenuStrip windowChildTreeMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem targetNodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setNotifyWindowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setTargetWindowMenuItem;
        private System.Windows.Forms.GroupBox notifyGroup;
        private System.Windows.Forms.GroupBox targetGroup;
        private System.Windows.Forms.TableLayoutPanel notifyLayoutPanel;
        private System.Windows.Forms.Label notifyHandleLabel;
        private System.Windows.Forms.TextBox notifyHandleText;
        private System.Windows.Forms.Label notifyTextLabel;
        private System.Windows.Forms.TextBox notifyTextText;
        private System.Windows.Forms.Label targetTypeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl controlOperationTab;
        private System.Windows.Forms.TabPage comboBoxPage;
        private Controls.SelectorOpeartionControl selectorOperator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TabPage textPage;
        private Controls.TextBoxOperationControl textOperator;
        private System.Windows.Forms.Button windowKillFocusButton;
        private System.Windows.Forms.Button windowSetFocusButton;
    }
}

