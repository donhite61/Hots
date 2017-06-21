namespace Hots
{
    partial class EditKeywordForm
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
            this.txtbox_KeyWord_Id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtbox_KeyWord_OrdSys
            // 
            this.txtbox_KeyWord_OrdSys.Location = new System.Drawing.Point(288, 24);
            this.txtbox_KeyWord_OrdSys.Name = "txtbox_KeyWord_OrdSys";
            this.txtbox_KeyWord_OrdSys.ReadOnly = true;
            this.txtbox_KeyWord_OrdSys.Size = new System.Drawing.Size(88, 20);
            this.txtbox_KeyWord_OrdSys.TabIndex = 0;
            this.txtbox_KeyWord_OrdSys.TabStop = false;
            // 
            // txtbox_KeyWord_Key
            // 
            this.txtbox_KeyWord_Key.Location = new System.Drawing.Point(96, 90);
            this.txtbox_KeyWord_Key.Name = "txtbox_KeyWord_Key";
            this.txtbox_KeyWord_Key.Size = new System.Drawing.Size(280, 20);
            this.txtbox_KeyWord_Key.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Order System";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Keyword";
            // 
            // but_KeyWordSave
            // 
            this.but_KeyWordSave.Location = new System.Drawing.Point(288, 192);
            this.but_KeyWordSave.Name = "but_KeyWordSave";
            this.but_KeyWordSave.Size = new System.Drawing.Size(88, 24);
            this.but_KeyWordSave.TabIndex = 3;
            this.but_KeyWordSave.Text = "Save";
            this.but_KeyWordSave.UseVisualStyleBackColor = true;
            this.but_KeyWordSave.Click += new System.EventHandler(this.but_KeyWordSave_Click);
            // 
            // but_KeyWordDel
            // 
            this.but_KeyWordDel.Location = new System.Drawing.Point(16, 192);
            this.but_KeyWordDel.Name = "but_KeyWordDel";
            this.but_KeyWordDel.Size = new System.Drawing.Size(88, 24);
            this.but_KeyWordDel.TabIndex = 2;
            this.but_KeyWordDel.Text = "Delete";
            this.but_KeyWordDel.UseVisualStyleBackColor = true;
            this.but_KeyWordDel.Click += new System.EventHandler(this.but_KeyWordDel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stores";
            // 
            // cmbbox_KeyWord_Stores
            // 
            this.cmbbox_KeyWord_Stores.FormattingEnabled = true;
            this.cmbbox_KeyWord_Stores.Location = new System.Drawing.Point(96, 124);
            this.cmbbox_KeyWord_Stores.Name = "cmbbox_KeyWord_Stores";
            this.cmbbox_KeyWord_Stores.Size = new System.Drawing.Size(280, 21);
            this.cmbbox_KeyWord_Stores.TabIndex = 1;
            this.cmbbox_KeyWord_Stores.SelectedIndexChanged += new System.EventHandler(this.cmbbox_KeyWord_Stores_SelectedIndexChanged);
            // 
            // txtbox_KeyWord_Id
            // 
            this.txtbox_KeyWord_Id.Location = new System.Drawing.Point(95, 26);
            this.txtbox_KeyWord_Id.Name = "txtbox_KeyWord_Id";
            this.txtbox_KeyWord_Id.ReadOnly = true;
            this.txtbox_KeyWord_Id.Size = new System.Drawing.Size(84, 20);
            this.txtbox_KeyWord_Id.TabIndex = 0;
            this.txtbox_KeyWord_Id.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Keyword Id";
            // 
            // EditKeywordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 229);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.but_KeyWordDel);
            this.Controls.Add(this.but_KeyWordSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbbox_KeyWord_Stores);
            this.Controls.Add(this.txtbox_KeyWord_Key);
            this.Controls.Add(this.txtbox_KeyWord_Id);
            this.Controls.Add(this.txtbox_KeyWord_OrdSys);
            this.Name = "EditKeywordForm";
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
        private System.Windows.Forms.TextBox txtbox_KeyWord_Id;
        private System.Windows.Forms.Label label4;
    }
}