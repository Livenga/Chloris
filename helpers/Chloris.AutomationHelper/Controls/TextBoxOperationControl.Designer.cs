namespace Chloris.AutomationHelper.Controls
{
    partial class TextBoxOperationControl
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
            this.components = new System.ComponentModel.Container();
            this.valueText = new System.Windows.Forms.TextBox();
            this.valueContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.limitTextValueMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTextButton = new System.Windows.Forms.Button();
            this.getTextButton = new System.Windows.Forms.Button();
            this.notifyChangeButton = new System.Windows.Forms.Button();
            this.notifyUpdateButton = new System.Windows.Forms.Button();
            this.notifySetFocusButton = new System.Windows.Forms.Button();
            this.notifyKillFocusButton = new System.Windows.Forms.Button();
            this.enableModifyButton = new System.Windows.Forms.Button();
            this.getModifyButton = new System.Windows.Forms.Button();
            this.disableModifyButton = new System.Windows.Forms.Button();
            this.modifyStateLabel = new System.Windows.Forms.Label();
            this.valueContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // valueText
            // 
            this.valueText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueText.ContextMenuStrip = this.valueContextMenu;
            this.valueText.Location = new System.Drawing.Point(3, 3);
            this.valueText.MaxLength = 1024;
            this.valueText.Name = "valueText";
            this.valueText.Size = new System.Drawing.Size(314, 25);
            this.valueText.TabIndex = 0;
            // 
            // valueContextMenu
            // 
            this.valueContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.limitTextValueMenuItem});
            this.valueContextMenu.Name = "valueContextMenu";
            this.valueContextMenu.Size = new System.Drawing.Size(125, 26);
            // 
            // limitTextValueMenuItem
            // 
            this.limitTextValueMenuItem.Name = "limitTextValueMenuItem";
            this.limitTextValueMenuItem.Size = new System.Drawing.Size(124, 22);
            this.limitTextValueMenuItem.Text = "&Limit Text";
            this.limitTextValueMenuItem.Click += new System.EventHandler(this.OnLimitTextMenuItemClick);
            // 
            // setTextButton
            // 
            this.setTextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setTextButton.Location = new System.Drawing.Point(111, 34);
            this.setTextButton.Name = "setTextButton";
            this.setTextButton.Size = new System.Drawing.Size(100, 28);
            this.setTextButton.TabIndex = 1;
            this.setTextButton.Text = "Set";
            this.setTextButton.UseVisualStyleBackColor = true;
            this.setTextButton.Click += new System.EventHandler(this.OnSetValueClick);
            // 
            // getTextButton
            // 
            this.getTextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.getTextButton.Location = new System.Drawing.Point(217, 34);
            this.getTextButton.Name = "getTextButton";
            this.getTextButton.Size = new System.Drawing.Size(100, 28);
            this.getTextButton.TabIndex = 2;
            this.getTextButton.Text = "Get";
            this.getTextButton.UseVisualStyleBackColor = true;
            this.getTextButton.Click += new System.EventHandler(this.OnGetValueClick);
            // 
            // notifyChangeButton
            // 
            this.notifyChangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notifyChangeButton.Location = new System.Drawing.Point(61, 84);
            this.notifyChangeButton.Name = "notifyChangeButton";
            this.notifyChangeButton.Size = new System.Drawing.Size(125, 28);
            this.notifyChangeButton.TabIndex = 3;
            this.notifyChangeButton.Text = "EN_CHANGE";
            this.notifyChangeButton.UseVisualStyleBackColor = true;
            this.notifyChangeButton.Click += new System.EventHandler(this.OnSendNotifyClick);
            // 
            // notifyUpdateButton
            // 
            this.notifyUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notifyUpdateButton.Location = new System.Drawing.Point(61, 118);
            this.notifyUpdateButton.Name = "notifyUpdateButton";
            this.notifyUpdateButton.Size = new System.Drawing.Size(125, 28);
            this.notifyUpdateButton.TabIndex = 4;
            this.notifyUpdateButton.Text = "EN_UPDATE";
            this.notifyUpdateButton.UseVisualStyleBackColor = true;
            this.notifyUpdateButton.Click += new System.EventHandler(this.OnSendNotifyClick);
            // 
            // notifySetFocusButton
            // 
            this.notifySetFocusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notifySetFocusButton.Location = new System.Drawing.Point(192, 84);
            this.notifySetFocusButton.Name = "notifySetFocusButton";
            this.notifySetFocusButton.Size = new System.Drawing.Size(125, 28);
            this.notifySetFocusButton.TabIndex = 5;
            this.notifySetFocusButton.Text = "EN_SETFOCUS";
            this.notifySetFocusButton.UseVisualStyleBackColor = true;
            this.notifySetFocusButton.Click += new System.EventHandler(this.OnSendNotifyClick);
            // 
            // notifyKillFocusButton
            // 
            this.notifyKillFocusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notifyKillFocusButton.Location = new System.Drawing.Point(192, 118);
            this.notifyKillFocusButton.Name = "notifyKillFocusButton";
            this.notifyKillFocusButton.Size = new System.Drawing.Size(125, 28);
            this.notifyKillFocusButton.TabIndex = 6;
            this.notifyKillFocusButton.Text = "EN_KILLFOCUS";
            this.notifyKillFocusButton.UseVisualStyleBackColor = true;
            this.notifyKillFocusButton.Click += new System.EventHandler(this.OnSendNotifyClick);
            // 
            // enableModifyButton
            // 
            this.enableModifyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.enableModifyButton.Location = new System.Drawing.Point(192, 175);
            this.enableModifyButton.Name = "enableModifyButton";
            this.enableModifyButton.Size = new System.Drawing.Size(125, 28);
            this.enableModifyButton.TabIndex = 7;
            this.enableModifyButton.Text = "Enable Modify";
            this.enableModifyButton.UseVisualStyleBackColor = true;
            this.enableModifyButton.Click += new System.EventHandler(this.OnSwitchModifyClick);
            // 
            // getModifyButton
            // 
            this.getModifyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.getModifyButton.Location = new System.Drawing.Point(192, 243);
            this.getModifyButton.Name = "getModifyButton";
            this.getModifyButton.Size = new System.Drawing.Size(125, 28);
            this.getModifyButton.TabIndex = 10;
            this.getModifyButton.Text = "Get Modify";
            this.getModifyButton.UseVisualStyleBackColor = true;
            this.getModifyButton.Click += new System.EventHandler(this.OnGetModifyClick);
            // 
            // disableModifyButton
            // 
            this.disableModifyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.disableModifyButton.Location = new System.Drawing.Point(192, 209);
            this.disableModifyButton.Name = "disableModifyButton";
            this.disableModifyButton.Size = new System.Drawing.Size(125, 28);
            this.disableModifyButton.TabIndex = 8;
            this.disableModifyButton.Text = "Disable Modify";
            this.disableModifyButton.UseVisualStyleBackColor = true;
            this.disableModifyButton.Click += new System.EventHandler(this.OnSwitchModifyClick);
            // 
            // modifyStateLabel
            // 
            this.modifyStateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modifyStateLabel.AutoSize = true;
            this.modifyStateLabel.ForeColor = System.Drawing.Color.Blue;
            this.modifyStateLabel.Location = new System.Drawing.Point(82, 248);
            this.modifyStateLabel.Name = "modifyStateLabel";
            this.modifyStateLabel.Size = new System.Drawing.Size(18, 18);
            this.modifyStateLabel.TabIndex = 9;
            this.modifyStateLabel.Text = "#";
            // 
            // TextBoxOperationControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.modifyStateLabel);
            this.Controls.Add(this.disableModifyButton);
            this.Controls.Add(this.getModifyButton);
            this.Controls.Add(this.enableModifyButton);
            this.Controls.Add(this.notifyKillFocusButton);
            this.Controls.Add(this.notifySetFocusButton);
            this.Controls.Add(this.notifyUpdateButton);
            this.Controls.Add(this.notifyChangeButton);
            this.Controls.Add(this.getTextButton);
            this.Controls.Add(this.setTextButton);
            this.Controls.Add(this.valueText);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "TextBoxOperationControl";
            this.Size = new System.Drawing.Size(320, 320);
            this.valueContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox valueText;
        private System.Windows.Forms.Button setTextButton;
        private System.Windows.Forms.Button getTextButton;
        private System.Windows.Forms.Button notifyChangeButton;
        private System.Windows.Forms.Button notifyUpdateButton;
        private System.Windows.Forms.ContextMenuStrip valueContextMenu;
        private System.Windows.Forms.ToolStripMenuItem limitTextValueMenuItem;
        private System.Windows.Forms.Button notifySetFocusButton;
        private System.Windows.Forms.Button notifyKillFocusButton;
        private System.Windows.Forms.Button enableModifyButton;
        private System.Windows.Forms.Button getModifyButton;
        private System.Windows.Forms.Button disableModifyButton;
        private System.Windows.Forms.Label modifyStateLabel;
    }
}
