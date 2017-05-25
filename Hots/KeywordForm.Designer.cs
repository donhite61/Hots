namespace Hots
{
    partial class KeywordForm
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
            this.txtbox_KeyWord_OrdSys = new System.Windows.Forms.TextBox();
            this.txtbox_KeyWord_Key = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.but_KeyWordSave = new System.Windows.Forms.Button();
            this.but_KeyWordDel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbbox_KeyWord_Stores = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtbox_KeyWord_OrdSys
            // 
            this.txtbox_KeyWord_OrdSys.Location = new System.Drawing.Point(128, 30);
            this.txtbox_KeyWord_OrdSys.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_KeyWord_OrdSys.Name = "txtbox_KeyWord_OrdSys";
            this.txtbox_KeyWord_OrdSys.ReadOnly = true;
            this.txtbox_KeyWord_OrdSys.Size = new System.Drawing.Size(372, 22);
            this.txtbox_KeyWord_OrdSys.TabIndex = 0;
            // 
            // txtbox_KeyWord_Key
            // 
            this.txtbox_KeyWord_Key.Location = new System.Drawing.Point(128, 73);
            this.txtbox_KeyWord_Key.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_KeyWord_Key.Name = "txtbox_KeyWord_Key";
            this.txtbox_KeyWord_Key.Size = new System.Drawing.Size(372, 22);
            this.txtbox_KeyWord_Key.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Order System";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Keyword";
            // 
            // but_KeyWordSave
            // 
            this.but_KeyWordSave.Location = new System.Drawing.Point(384, 236);
            this.but_KeyWordSave.Margin = new System.Windows.Forms.Padding(4);
            this.but_KeyWordSave.Name = "but_KeyWordSave";
            this.but_KeyWordSave.Size = new System.Drawing.Size(117, 30);
            this.but_KeyWordSave.TabIndex = 3;
            this.but_KeyWordSave.Text = "Save";
            this.but_KeyWordSave.UseVisualStyleBackColor = true;
            this.but_KeyWordSave.Click += new System.EventHandler(this.but_KeyWordSave_Click);
            // 
            // but_KeyWordDel
            // 
            this.but_KeyWordDel.Location = new System.Drawing.Point(21, 236);
            this.but_KeyWordDel.Margin = new System.Windows.Forms.Padding(4);
            this.but_KeyWordDel.Name = "but_KeyWordDel";
            this.but_KeyWordDel.Size = new System.Drawing.Size(117, 30);
            this.but_KeyWordDel.TabIndex = 3;
            this.but_KeyWordDel.Text = "Delete";
            this.but_KeyWordDel.UseVisualStyleBackColor = true;
            this.but_KeyWordDel.Click += new System.EventHandler(this.but_KeyWordDel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stores";
            // 
            // cmbbox_KeyWord_Stores
            // 
            this.cmbbox_KeyWord_Stores.FormattingEnabled = true;
            this.cmbbox_KeyWord_Stores.Location = new System.Drawing.Point(128, 113);
            this.cmbbox_KeyWord_Stores.Margin = new System.Windows.Forms.Padding(4);
            this.cmbbox_KeyWord_Stores.Name = "cmbbox_KeyWord_Stores";
            this.cmbbox_KeyWord_Stores.Size = new System.Drawing.Size(372, 24);
            this.cmbbox_KeyWord_Stores.TabIndex = 1;
            this.cmbbox_KeyWord_Stores.SelectedIndexChanged += new System.EventHandler(this.cmbbox_KeyWord_Stores_SelectedIndexChanged);
            // 
            // KeywordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 282);
            this.Controls.Add(this.but_KeyWordDel);
            this.Controls.Add(this.but_KeyWordSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbbox_KeyWord_Stores);
            this.Controls.Add(this.txtbox_KeyWord_Key);
            this.Controls.Add(this.txtbox_KeyWord_OrdSys);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KeywordForm";
            this.Text = "KeywordForm";
            this.Load += new System.EventHandler(this.KeywordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbox_KeyWord_OrdSys;
        private System.Windows.Forms.TextBox txtbox_KeyWord_Key;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button but_KeyWordSave;
        private System.Windows.Forms.Button but_KeyWordDel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbbox_KeyWord_Stores;
    }
}