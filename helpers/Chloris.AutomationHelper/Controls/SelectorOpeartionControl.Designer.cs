namespace Chloris.AutomationHelper.Controls
{
    partial class SelectorOpeartionControl
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.itemList = new System.Windows.Forms.ListView();
            this.itemIdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemTextHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectionLabel = new System.Windows.Forms.Label();
            this.selectionText = new System.Windows.Forms.TextBox();
            this.focusLabel = new System.Windows.Forms.Label();
            this.getSelectionButton = new System.Windows.Forms.Button();
            this.setSelectionButton = new System.Windows.Forms.Button();
            this.notifySetFocusButton = new System.Windows.Forms.Button();
            this.notifyKillFocusButton = new System.Windows.Forms.Button();
            this.notifySelChangeButton = new System.Windows.Forms.Button();
            this.notifySelEndOkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // itemList
            // 
            this.itemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemIdHeader,
            this.itemTextHeader});
            this.itemList.FullRowSelect = true;
            this.itemList.GridLines = true;
            this.itemList.HideSelection = false;
            this.itemList.Location = new System.Drawing.Point(3, 3);
            this.itemList.Name = "itemList";
            this.itemList.Size = new System.Drawing.Size(465, 474);
            this.itemList.TabIndex = 0;
            this.itemList.UseCompatibleStateImageBehavior = false;
            this.itemList.View = System.Windows.Forms.View.Details;
            this.itemList.VirtualMode = true;
            this.itemList.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.OnItemListRetrieveVirtualItem);
            this.itemList.SelectedIndexChanged += new System.EventHandler(this.OnItemListSelectedIndexChanged);
            // 
            // itemIdHeader
            // 
            this.itemIdHeader.Text = "ID";
            this.itemIdHeader.Width = 75;
            // 
            // itemTextHeader
            // 
            this.itemTextHeader.Text = "Text";
            this.itemTextHeader.Width = 420;
            // 
            // selectionLabel
            // 
            this.selectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectionLabel.AutoSize = true;
            this.selectionLabel.Location = new System.Drawing.Point(474, 6);
            this.selectionLabel.Name = "selectionLabel";
            this.selectionLabel.Size = new System.Drawing.Size(61, 18);
            this.selectionLabel.TabIndex = 1;
            this.selectionLabel.Text = "&Selection";
            this.selectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // selectionText
            // 
            this.selectionText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectionText.BackColor = System.Drawing.SystemColors.Control;
            this.selectionText.ForeColor = System.Drawing.Color.Blue;
            this.selectionText.Location = new System.Drawing.Point(541, 3);
            this.selectionText.Name = "selectionText";
            this.selectionText.ReadOnly = true;
            this.selectionText.Size = new System.Drawing.Size(139, 25);
            this.selectionText.TabIndex = 2;
            this.selectionText.Text = "#";
            // 
            // focusLabel
            // 
            this.focusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.focusLabel.AutoSize = true;
            this.focusLabel.Location = new System.Drawing.Point(474, 78);
            this.focusLabel.Name = "focusLabel";
            this.focusLabel.Size = new System.Drawing.Size(41, 18);
            this.focusLabel.TabIndex = 5;
            this.focusLabel.Text = "Focus";
            // 
            // getSelectionButton
            // 
            this.getSelectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.getSelectionButton.Location = new System.Drawing.Point(474, 34);
            this.getSelectionButton.Name = "getSelectionButton";
            this.getSelectionButton.Size = new System.Drawing.Size(100, 28);
            this.getSelectionButton.TabIndex = 3;
            this.getSelectionButton.Text = "Get";
            this.getSelectionButton.UseVisualStyleBackColor = true;
            this.getSelectionButton.Click += new System.EventHandler(this.OnGetCurrentSelectionClick);
            // 
            // setSelectionButton
            // 
            this.setSelectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setSelectionButton.Location = new System.Drawing.Point(580, 34);
            this.setSelectionButton.Name = "setSelectionButton";
            this.setSelectionButton.Size = new System.Drawing.Size(100, 28);
            this.setSelectionButton.TabIndex = 4;
            this.setSelectionButton.Text = "Set";
            this.setSelectionButton.UseVisualStyleBackColor = true;
            this.setSelectionButton.Click += new System.EventHandler(this.OnSetCurrentSelectionClick);
            // 
            // notifySetFocusButton
            // 
            this.notifySetFocusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notifySetFocusButton.Location = new System.Drawing.Point(474, 99);
            this.notifySetFocusButton.Name = "notifySetFocusButton";
            this.notifySetFocusButton.Size = new System.Drawing.Size(100, 28);
            this.notifySetFocusButton.TabIndex = 6;
            this.notifySetFocusButton.Text = "Set";
            this.notifySetFocusButton.UseVisualStyleBackColor = true;
            this.notifySetFocusButton.Click += new System.EventHandler(this.OnSendNotifyClick);
            // 
            // notifyKillFocusButton
            // 
            this.notifyKillFocusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notifyKillFocusButton.Location = new System.Drawing.Point(580, 99);
            this.notifyKillFocusButton.Name = "notifyKillFocusButton";
            this.notifyKillFocusButton.Size = new System.Drawing.Size(100, 28);
            this.notifyKillFocusButton.TabIndex = 7;
            this.notifyKillFocusButton.Text = "Kill";
            this.notifyKillFocusButton.UseVisualStyleBackColor = true;
            this.notifyKillFocusButton.Click += new System.EventHandler(this.OnSendNotifyClick);
            // 
            // notifySelChangeButton
            // 
            this.notifySelChangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notifySelChangeButton.Location = new System.Drawing.Point(506, 147);
            this.notifySelChangeButton.Name = "notifySelChangeButton";
            this.notifySelChangeButton.Size = new System.Drawing.Size(140, 28);
            this.notifySelChangeButton.TabIndex = 8;
            this.notifySelChangeButton.Text = "CBN_SELCHANGE";
            this.notifySelChangeButton.UseVisualStyleBackColor = true;
            this.notifySelChangeButton.Click += new System.EventHandler(this.OnSendNotifyClick);
            // 
            // notifySelEndOkButton
            // 
            this.notifySelEndOkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notifySelEndOkButton.Location = new System.Drawing.Point(506, 181);
            this.notifySelEndOkButton.Name = "notifySelEndOkButton";
            this.notifySelEndOkButton.Size = new System.Drawing.Size(140, 28);
            this.notifySelEndOkButton.TabIndex = 9;
            this.notifySelEndOkButton.Text = "CBN_SELENDOK";
            this.notifySelEndOkButton.UseVisualStyleBackColor = true;
            this.notifySelEndOkButton.Click += new System.EventHandler(this.OnSendNotifyClick);
            // 
            // SelectorOpeartionControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.notifySelEndOkButton);
            this.Controls.Add(this.notifySelChangeButton);
            this.Controls.Add(this.notifyKillFocusButton);
            this.Controls.Add(this.notifySetFocusButton);
            this.Controls.Add(this.setSelectionButton);
            this.Controls.Add(this.getSelectionButton);
            this.Controls.Add(this.focusLabel);
            this.Controls.Add(this.selectionText);
            this.Controls.Add(this.selectionLabel);
            this.Controls.Add(this.itemList);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "SelectorOpeartionControl";
            this.Size = new System.Drawing.Size(683, 480);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView itemList;
        private System.Windows.Forms.ColumnHeader itemIdHeader;
        private System.Windows.Forms.ColumnHeader itemTextHeader;
        private System.Windows.Forms.Label selectionLabel;
        private System.Windows.Forms.TextBox selectionText;
        private System.Windows.Forms.Label focusLabel;
        private System.Windows.Forms.Button getSelectionButton;
        private System.Windows.Forms.Button setSelectionButton;
        private System.Windows.Forms.Button notifySetFocusButton;
        private System.Windows.Forms.Button notifyKillFocusButton;
        private System.Windows.Forms.Button notifySelChangeButton;
        private System.Windows.Forms.Button notifySelEndOkButton;
    }
}
