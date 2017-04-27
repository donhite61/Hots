﻿namespace Hots
{
    partial class frm_UpdOrdSys
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
            this.labelR3 = new System.Windows.Forms.Label();
            this.labelR2 = new System.Windows.Forms.Label();
            this.txtBox_WaitForFile = new System.Windows.Forms.TextBox();
            this.txtBox_ProdSubFldr = new System.Windows.Forms.TextBox();
            this.chkBox_Active = new System.Windows.Forms.CheckBox();
            this.labelR1 = new System.Windows.Forms.Label();
            this.txtBox_WchdExt = new System.Windows.Forms.TextBox();
            this.txtBox_OutputFolder = new System.Windows.Forms.TextBox();
            this.but_WatchedFolder = new System.Windows.Forms.Button();
            this.txtBox_WatchedFolder = new System.Windows.Forms.TextBox();
            this.but_OutputFolder = new System.Windows.Forms.Button();
            this.txtBox_ReadFolder = new System.Windows.Forms.TextBox();
            this.but_ReadFolder = new System.Windows.Forms.Button();
            this.but_Save = new System.Windows.Forms.Button();
            this.chkBox_WaitFileIsFldr = new System.Windows.Forms.CheckBox();
            this.txtBox_OrdSysName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.But_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelR3
            // 
            this.labelR3.AutoSize = true;
            this.labelR3.Location = new System.Drawing.Point(64, 325);
            this.labelR3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelR3.Name = "labelR3";
            this.labelR3.Size = new System.Drawing.Size(83, 17);
            this.labelR3.TabIndex = 23;
            this.labelR3.Text = "Wait for File";
            // 
            // labelR2
            // 
            this.labelR2.AutoSize = true;
            this.labelR2.Location = new System.Drawing.Point(32, 286);
            this.labelR2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelR2.Name = "labelR2";
            this.labelR2.Size = new System.Drawing.Size(122, 17);
            this.labelR2.TabIndex = 24;
            this.labelR2.Text = "Product Subfolder";
            // 
            // txtBox_WaitForFile
            // 
            this.txtBox_WaitForFile.Location = new System.Drawing.Point(171, 315);
            this.txtBox_WaitForFile.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_WaitForFile.Name = "txtBox_WaitForFile";
            this.txtBox_WaitForFile.Size = new System.Drawing.Size(264, 22);
            this.txtBox_WaitForFile.TabIndex = 21;
            // 
            // txtBox_ProdSubFldr
            // 
            this.txtBox_ProdSubFldr.Location = new System.Drawing.Point(171, 276);
            this.txtBox_ProdSubFldr.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_ProdSubFldr.Name = "txtBox_ProdSubFldr";
            this.txtBox_ProdSubFldr.Size = new System.Drawing.Size(264, 22);
            this.txtBox_ProdSubFldr.TabIndex = 22;
            // 
            // chkBox_Active
            // 
            this.chkBox_Active.AutoSize = true;
            this.chkBox_Active.Location = new System.Drawing.Point(32, 20);
            this.chkBox_Active.Margin = new System.Windows.Forms.Padding(4);
            this.chkBox_Active.Name = "chkBox_Active";
            this.chkBox_Active.Size = new System.Drawing.Size(68, 21);
            this.chkBox_Active.TabIndex = 20;
            this.chkBox_Active.Text = "Active";
            this.chkBox_Active.UseVisualStyleBackColor = true;
            // 
            // labelR1
            // 
            this.labelR1.AutoSize = true;
            this.labelR1.Location = new System.Drawing.Point(64, 148);
            this.labelR1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelR1.Name = "labelR1";
            this.labelR1.Size = new System.Drawing.Size(95, 17);
            this.labelR1.TabIndex = 19;
            this.labelR1.Text = "File Extension";
            // 
            // txtBox_WchdExt
            // 
            this.txtBox_WchdExt.Location = new System.Drawing.Point(171, 148);
            this.txtBox_WchdExt.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_WchdExt.Name = "txtBox_WchdExt";
            this.txtBox_WchdExt.Size = new System.Drawing.Size(111, 22);
            this.txtBox_WchdExt.TabIndex = 15;
            // 
            // txtBox_OutputFolder
            // 
            this.txtBox_OutputFolder.Location = new System.Drawing.Point(171, 236);
            this.txtBox_OutputFolder.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_OutputFolder.Name = "txtBox_OutputFolder";
            this.txtBox_OutputFolder.Size = new System.Drawing.Size(653, 22);
            this.txtBox_OutputFolder.TabIndex = 16;
            // 
            // but_WatchedFolder
            // 
            this.but_WatchedFolder.Location = new System.Drawing.Point(21, 108);
            this.but_WatchedFolder.Margin = new System.Windows.Forms.Padding(4);
            this.but_WatchedFolder.Name = "but_WatchedFolder";
            this.but_WatchedFolder.Size = new System.Drawing.Size(139, 30);
            this.but_WatchedFolder.TabIndex = 12;
            this.but_WatchedFolder.Text = "Watched Folder";
            this.but_WatchedFolder.UseVisualStyleBackColor = true;
            this.but_WatchedFolder.Click += new System.EventHandler(this.but_BrowseFolder_Click);
            // 
            // txtBox_WatchedFolder
            // 
            this.txtBox_WatchedFolder.Location = new System.Drawing.Point(171, 108);
            this.txtBox_WatchedFolder.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_WatchedFolder.Name = "txtBox_WatchedFolder";
            this.txtBox_WatchedFolder.Size = new System.Drawing.Size(653, 22);
            this.txtBox_WatchedFolder.TabIndex = 17;
            // 
            // but_OutputFolder
            // 
            this.but_OutputFolder.Location = new System.Drawing.Point(21, 236);
            this.but_OutputFolder.Margin = new System.Windows.Forms.Padding(4);
            this.but_OutputFolder.Name = "but_OutputFolder";
            this.but_OutputFolder.Size = new System.Drawing.Size(139, 30);
            this.but_OutputFolder.TabIndex = 13;
            this.but_OutputFolder.Text = "Output Folder";
            this.but_OutputFolder.UseVisualStyleBackColor = true;
            this.but_OutputFolder.Click += new System.EventHandler(this.but_BrowseFolder_Click);
            // 
            // txtBox_ReadFolder
            // 
            this.txtBox_ReadFolder.Location = new System.Drawing.Point(171, 187);
            this.txtBox_ReadFolder.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_ReadFolder.Name = "txtBox_ReadFolder";
            this.txtBox_ReadFolder.Size = new System.Drawing.Size(653, 22);
            this.txtBox_ReadFolder.TabIndex = 18;
            // 
            // but_ReadFolder
            // 
            this.but_ReadFolder.Location = new System.Drawing.Point(21, 187);
            this.but_ReadFolder.Margin = new System.Windows.Forms.Padding(4);
            this.but_ReadFolder.Name = "but_ReadFolder";
            this.but_ReadFolder.Size = new System.Drawing.Size(139, 30);
            this.but_ReadFolder.TabIndex = 14;
            this.but_ReadFolder.Text = "Read Folder";
            this.but_ReadFolder.UseVisualStyleBackColor = true;
            this.but_ReadFolder.Click += new System.EventHandler(this.but_BrowseFolder_Click);
            // 
            // but_Save
            // 
            this.but_Save.Location = new System.Drawing.Point(683, 404);
            this.but_Save.Margin = new System.Windows.Forms.Padding(4);
            this.but_Save.Name = "but_Save";
            this.but_Save.Size = new System.Drawing.Size(107, 30);
            this.but_Save.TabIndex = 25;
            this.but_Save.Text = "Update";
            this.but_Save.UseVisualStyleBackColor = true;
            this.but_Save.Click += new System.EventHandler(this.but_Update_Click);
            // 
            // chkBox_WaitFileIsFldr
            // 
            this.chkBox_WaitFileIsFldr.AutoSize = true;
            this.chkBox_WaitFileIsFldr.Location = new System.Drawing.Point(459, 315);
            this.chkBox_WaitFileIsFldr.Margin = new System.Windows.Forms.Padding(4);
            this.chkBox_WaitFileIsFldr.Name = "chkBox_WaitFileIsFldr";
            this.chkBox_WaitFileIsFldr.Size = new System.Drawing.Size(137, 21);
            this.chkBox_WaitFileIsFldr.TabIndex = 26;
            this.chkBox_WaitFileIsFldr.Text = "Wait for is Folder";
            this.chkBox_WaitFileIsFldr.UseVisualStyleBackColor = true;
            // 
            // txtBox_OrdSysName
            // 
            this.txtBox_OrdSysName.Location = new System.Drawing.Point(171, 69);
            this.txtBox_OrdSysName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_OrdSysName.Name = "txtBox_OrdSysName";
            this.txtBox_OrdSysName.ReadOnly = true;
            this.txtBox_OrdSysName.Size = new System.Drawing.Size(264, 22);
            this.txtBox_OrdSysName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Ord Sys Name";
            // 
            // But_Cancel
            // 
            this.But_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.But_Cancel.Location = new System.Drawing.Point(504, 404);
            this.But_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.But_Cancel.Name = "But_Cancel";
            this.But_Cancel.Size = new System.Drawing.Size(107, 30);
            this.But_Cancel.TabIndex = 25;
            this.But_Cancel.Text = "Cancel";
            this.But_Cancel.UseVisualStyleBackColor = true;
            this.But_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // frm_UpdOrdSys
            // 
            this.AcceptButton = this.but_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.But_Cancel;
            this.ClientSize = new System.Drawing.Size(844, 464);
            this.Controls.Add(this.chkBox_WaitFileIsFldr);
            this.Controls.Add(this.But_Cancel);
            this.Controls.Add(this.but_Save);
            this.Controls.Add(this.labelR3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelR2);
            this.Controls.Add(this.txtBox_WaitForFile);
            this.Controls.Add(this.txtBox_OrdSysName);
            this.Controls.Add(this.txtBox_ProdSubFldr);
            this.Controls.Add(this.chkBox_Active);
            this.Controls.Add(this.labelR1);
            this.Controls.Add(this.txtBox_WchdExt);
            this.Controls.Add(this.txtBox_OutputFolder);
            this.Controls.Add(this.but_WatchedFolder);
            this.Controls.Add(this.txtBox_WatchedFolder);
            this.Controls.Add(this.but_OutputFolder);
            this.Controls.Add(this.txtBox_ReadFolder);
            this.Controls.Add(this.but_ReadFolder);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_UpdOrdSys";
            this.Text = "Update Order System";
            this.Load += new System.EventHandler(this.frm_UpdOrdSys_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelR3;
        private System.Windows.Forms.Label labelR2;
        private System.Windows.Forms.Label labelR1;
        private System.Windows.Forms.Button but_WatchedFolder;
        private System.Windows.Forms.Button but_OutputFolder;
        private System.Windows.Forms.Button but_ReadFolder;
        private System.Windows.Forms.Button but_Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button But_Cancel;
        public System.Windows.Forms.CheckBox chkBox_Active;
        public System.Windows.Forms.TextBox txtBox_OrdSysName;
        public System.Windows.Forms.TextBox txtBox_WaitForFile;
        public System.Windows.Forms.TextBox txtBox_ProdSubFldr;
        public System.Windows.Forms.TextBox txtBox_WchdExt;
        public System.Windows.Forms.TextBox txtBox_OutputFolder;
        public System.Windows.Forms.TextBox txtBox_WatchedFolder;
        public System.Windows.Forms.TextBox txtBox_ReadFolder;
        public System.Windows.Forms.CheckBox chkBox_WaitFileIsFldr;
    }
}