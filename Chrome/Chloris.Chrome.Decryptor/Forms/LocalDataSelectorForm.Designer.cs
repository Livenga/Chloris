namespace Chloris.Chrome.Decryptor.Forms
{
    partial class LocalDataSelectorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalDataSelectorForm));
            this.loginDataLabel = new System.Windows.Forms.Label();
            this.loginDataList = new System.Windows.Forms.ListView();
            this.localStateLabel = new System.Windows.Forms.Label();
            this.localStateList = new System.Windows.Forms.ListView();
            this.decideButton = new System.Windows.Forms.Button();
            this.loginDataPathHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.localStatePathHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // loginDataLabel
            // 
            this.loginDataLabel.AutoSize = true;
            this.loginDataLabel.Location = new System.Drawing.Point(12, 9);
            this.loginDataLabel.Name = "loginDataLabel";
            this.loginDataLabel.Size = new System.Drawing.Size(71, 18);
            this.loginDataLabel.TabIndex = 0;
            this.loginDataLabel.Text = "Login Data";
            // 
            // loginDataList
            // 
            this.loginDataList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginDataList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.loginDataPathHeader});
            this.loginDataList.FullRowSelect = true;
            this.loginDataList.GridLines = true;
            this.loginDataList.HideSelection = false;
            this.loginDataList.Location = new System.Drawing.Point(15, 30);
            this.loginDataList.MultiSelect = false;
            this.loginDataList.Name = "loginDataList";
            this.loginDataList.Size = new System.Drawing.Size(780, 165);
            this.loginDataList.TabIndex = 1;
            this.loginDataList.UseCompatibleStateImageBehavior = false;
            this.loginDataList.View = System.Windows.Forms.View.Details;
            // 
            // localStateLabel
            // 
            this.localStateLabel.AutoSize = true;
            this.localStateLabel.Location = new System.Drawing.Point(9, 210);
            this.localStateLabel.Name = "localStateLabel";
            this.localStateLabel.Size = new System.Drawing.Size(74, 18);
            this.localStateLabel.TabIndex = 2;
            this.localStateLabel.Text = "Local State";
            // 
            // localStateList
            // 
            this.localStateList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localStateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.localStatePathHeader});
            this.localStateList.FullRowSelect = true;
            this.localStateList.GridLines = true;
            this.localStateList.HideSelection = false;
            this.localStateList.Location = new System.Drawing.Point(12, 231);
            this.localStateList.MultiSelect = false;
            this.localStateList.Name = "localStateList";
            this.localStateList.Size = new System.Drawing.Size(780, 165);
            this.localStateList.TabIndex = 3;
            this.localStateList.UseCompatibleStateImageBehavior = false;
            this.localStateList.View = System.Windows.Forms.View.Details;
            // 
            // decideButton
            // 
            this.decideButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.decideButton.Location = new System.Drawing.Point(697, 403);
            this.decideButton.Name = "decideButton";
            this.decideButton.Size = new System.Drawing.Size(96, 28);
            this.decideButton.TabIndex = 4;
            this.decideButton.Text = "&OK";
            this.decideButton.UseVisualStyleBackColor = true;
            this.decideButton.Click += new System.EventHandler(this.OnDecideClick);
            // 
            // loginDataPathHeader
            // 
            this.loginDataPathHeader.Text = "パス";
            this.loginDataPathHeader.Width = 680;
            // 
            // localStatePathHeader
            // 
            this.localStatePathHeader.Text = "パス";
            this.localStatePathHeader.Width = 680;
            // 
            // LocalDataSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 441);
            this.Controls.Add(this.decideButton);
            this.Controls.Add(this.localStateList);
            this.Controls.Add(this.localStateLabel);
            this.Controls.Add(this.loginDataList);
            this.Controls.Add(this.loginDataLabel);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(680, 400);
            this.Name = "LocalDataSelectorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data Selector";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginDataLabel;
        private System.Windows.Forms.ListView loginDataList;
        private System.Windows.Forms.Label localStateLabel;
        private System.Windows.Forms.ListView localStateList;
        private System.Windows.Forms.Button decideButton;
        private System.Windows.Forms.ColumnHeader loginDataPathHeader;
        private System.Windows.Forms.ColumnHeader localStatePathHeader;
    }
}