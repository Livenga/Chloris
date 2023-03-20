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
            this.label1 = new System.Windows.Forms.Label();
            this.getCurrentSelectionText = new System.Windows.Forms.TextBox();
            this.getCurrentSelectionButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.setCurrentSelectorButton = new System.Windows.Forms.Button();
            this.setCurrentSelectionText = new System.Windows.Forms.MaskedTextBox();
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
            this.itemList.Size = new System.Drawing.Size(474, 403);
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
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // getCurrentSelectionText
            // 
            this.getCurrentSelectionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.getCurrentSelectionText.BackColor = System.Drawing.SystemColors.Control;
            this.getCurrentSelectionText.ForeColor = System.Drawing.Color.Blue;
            this.getCurrentSelectionText.Location = new System.Drawing.Point(67, 417);
            this.getCurrentSelectionText.Name = "getCurrentSelectionText";
            this.getCurrentSelectionText.ReadOnly = true;
            this.getCurrentSelectionText.Size = new System.Drawing.Size(308, 25);
            this.getCurrentSelectionText.TabIndex = 2;
            this.getCurrentSelectionText.Text = "#";
            // 
            // getCurrentSelectionButton
            // 
            this.getCurrentSelectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.getCurrentSelectionButton.Location = new System.Drawing.Point(381, 416);
            this.getCurrentSelectionButton.Name = "getCurrentSelectionButton";
            this.getCurrentSelectionButton.Size = new System.Drawing.Size(96, 28);
            this.getCurrentSelectionButton.TabIndex = 3;
            this.getCurrentSelectionButton.Text = "button1";
            this.getCurrentSelectionButton.UseVisualStyleBackColor = true;
            this.getCurrentSelectionButton.Click += new System.EventHandler(this.OnGetCurrentSelectionClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 455);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // setCurrentSelectorButton
            // 
            this.setCurrentSelectorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.setCurrentSelectorButton.Location = new System.Drawing.Point(381, 450);
            this.setCurrentSelectorButton.Name = "setCurrentSelectorButton";
            this.setCurrentSelectorButton.Size = new System.Drawing.Size(96, 28);
            this.setCurrentSelectorButton.TabIndex = 6;
            this.setCurrentSelectorButton.Text = "button2";
            this.setCurrentSelectorButton.UseVisualStyleBackColor = true;
            this.setCurrentSelectorButton.Click += new System.EventHandler(this.OnSetCurrentSelectionClick);
            // 
            // setCurrentSelectionText
            // 
            this.setCurrentSelectionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setCurrentSelectionText.Location = new System.Drawing.Point(67, 451);
            this.setCurrentSelectionText.Mask = "0";
            this.setCurrentSelectionText.Name = "setCurrentSelectionText";
            this.setCurrentSelectionText.Size = new System.Drawing.Size(308, 25);
            this.setCurrentSelectionText.TabIndex = 5;
            // 
            // SelectorOpeartionControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.setCurrentSelectionText);
            this.Controls.Add(this.getCurrentSelectionText);
            this.Controls.Add(this.getCurrentSelectionButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.itemList);
            this.Controls.Add(this.setCurrentSelectorButton);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "SelectorOpeartionControl";
            this.Size = new System.Drawing.Size(480, 480);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView itemList;
        private System.Windows.Forms.ColumnHeader itemIdHeader;
        private System.Windows.Forms.ColumnHeader itemTextHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox getCurrentSelectionText;
        private System.Windows.Forms.Button getCurrentSelectionButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button setCurrentSelectorButton;
        private System.Windows.Forms.MaskedTextBox setCurrentSelectionText;
    }
}
