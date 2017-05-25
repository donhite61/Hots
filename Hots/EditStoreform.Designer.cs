namespace Hots
{
    partial class EditStoreForm
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
            this.txtBox_StorePhone = new System.Windows.Forms.MaskedTextBox();
            this.but_StoreAdd = new System.Windows.Forms.Button();
            this.but_StoreDelete = new System.Windows.Forms.Button();
            this.but_StoreUpdate = new System.Windows.Forms.Button();
            this.ChkBox_StoreInactive = new System.Windows.Forms.CheckBox();
            this.lbl_NicName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBox_StoreCity = new System.Windows.Forms.TextBox();
            this.txtBox_StoreZip = new System.Windows.Forms.TextBox();
            this.txtBox_StoreAddress = new System.Windows.Forms.TextBox();
            this.txtBox_StoreState = new System.Windows.Forms.TextBox();
            this.txtBox_StoreNicName = new System.Windows.Forms.TextBox();
            this.txtBox_StoreName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBox_ShipCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBox_StorePhone
            // 
            this.txtBox_StorePhone.CausesValidation = false;
            this.txtBox_StorePhone.Location = new System.Drawing.Point(244, 30);
            this.txtBox_StorePhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_StorePhone.Mask = "(999) 000-0000";
            this.txtBox_StorePhone.Name = "txtBox_StorePhone";
            this.txtBox_StorePhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBox_StorePhone.Size = new System.Drawing.Size(116, 22);
            this.txtBox_StorePhone.TabIndex = 2;
            // 
            // but_StoreAdd
            // 
            this.but_StoreAdd.Location = new System.Drawing.Point(24, 260);
            this.but_StoreAdd.Margin = new System.Windows.Forms.Padding(4);
            this.but_StoreAdd.Name = "but_StoreAdd";
            this.but_StoreAdd.Size = new System.Drawing.Size(100, 28);
            this.but_StoreAdd.TabIndex = 10;
            this.but_StoreAdd.Text = "Add";
            this.but_StoreAdd.UseVisualStyleBackColor = true;
            this.but_StoreAdd.Click += new System.EventHandler(this.but_StoreAdd_Click);
            // 
            // but_StoreDelete
            // 
            this.but_StoreDelete.Location = new System.Drawing.Point(361, 260);
            this.but_StoreDelete.Margin = new System.Windows.Forms.Padding(4);
            this.but_StoreDelete.Name = "but_StoreDelete";
            this.but_StoreDelete.Size = new System.Drawing.Size(100, 28);
            this.but_StoreDelete.TabIndex = 12;
            this.but_StoreDelete.Text = "Delete";
            this.but_StoreDelete.UseVisualStyleBackColor = true;
            this.but_StoreDelete.Click += new System.EventHandler(this.but_StoreDelete_Click);
            // 
            // but_StoreUpdate
            // 
            this.but_StoreUpdate.Location = new System.Drawing.Point(196, 260);
            this.but_StoreUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.but_StoreUpdate.Name = "but_StoreUpdate";
            this.but_StoreUpdate.Size = new System.Drawing.Size(100, 28);
            this.but_StoreUpdate.TabIndex = 11;
            this.but_StoreUpdate.Text = "Update";
            this.but_StoreUpdate.UseVisualStyleBackColor = true;
            this.but_StoreUpdate.Click += new System.EventHandler(this.but_StoreUpdate_Click);
            // 
            // ChkBox_StoreInactive
            // 
            this.ChkBox_StoreInactive.AutoSize = true;
            this.ChkBox_StoreInactive.Location = new System.Drawing.Point(383, 30);
            this.ChkBox_StoreInactive.Margin = new System.Windows.Forms.Padding(4);
            this.ChkBox_StoreInactive.Name = "ChkBox_StoreInactive";
            this.ChkBox_StoreInactive.Size = new System.Drawing.Size(78, 21);
            this.ChkBox_StoreInactive.TabIndex = 3;
            this.ChkBox_StoreInactive.Text = "Inactive";
            this.ChkBox_StoreInactive.UseVisualStyleBackColor = true;
            // 
            // lbl_NicName
            // 
            this.lbl_NicName.AutoSize = true;
            this.lbl_NicName.Location = new System.Drawing.Point(31, 11);
            this.lbl_NicName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_NicName.Name = "lbl_NicName";
            this.lbl_NicName.Size = new System.Drawing.Size(69, 17);
            this.lbl_NicName.TabIndex = 19;
            this.lbl_NicName.Text = "Nic Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Store Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Store Address";
            // 
            // txtBox_StoreCity
            // 
            this.txtBox_StoreCity.Location = new System.Drawing.Point(20, 160);
            this.txtBox_StoreCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_StoreCity.Name = "txtBox_StoreCity";
            this.txtBox_StoreCity.Size = new System.Drawing.Size(276, 22);
            this.txtBox_StoreCity.TabIndex = 9;
            // 
            // txtBox_StoreZip
            // 
            this.txtBox_StoreZip.Location = new System.Drawing.Point(362, 160);
            this.txtBox_StoreZip.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_StoreZip.Name = "txtBox_StoreZip";
            this.txtBox_StoreZip.Size = new System.Drawing.Size(105, 22);
            this.txtBox_StoreZip.TabIndex = 8;
            // 
            // txtBox_StoreAddress
            // 
            this.txtBox_StoreAddress.Location = new System.Drawing.Point(20, 130);
            this.txtBox_StoreAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_StoreAddress.Name = "txtBox_StoreAddress";
            this.txtBox_StoreAddress.Size = new System.Drawing.Size(447, 22);
            this.txtBox_StoreAddress.TabIndex = 5;
            // 
            // txtBox_StoreState
            // 
            this.txtBox_StoreState.Location = new System.Drawing.Point(308, 160);
            this.txtBox_StoreState.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_StoreState.Name = "txtBox_StoreState";
            this.txtBox_StoreState.Size = new System.Drawing.Size(41, 22);
            this.txtBox_StoreState.TabIndex = 7;
            // 
            // txtBox_StoreNicName
            // 
            this.txtBox_StoreNicName.Location = new System.Drawing.Point(20, 30);
            this.txtBox_StoreNicName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_StoreNicName.Name = "txtBox_StoreNicName";
            this.txtBox_StoreNicName.Size = new System.Drawing.Size(212, 22);
            this.txtBox_StoreNicName.TabIndex = 1;
            // 
            // txtBox_StoreName
            // 
            this.txtBox_StoreName.Location = new System.Drawing.Point(20, 82);
            this.txtBox_StoreName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_StoreName.Name = "txtBox_StoreName";
            this.txtBox_StoreName.Size = new System.Drawing.Size(447, 22);
            this.txtBox_StoreName.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Store Phone";
            // 
            // txtBox_ShipCode
            // 
            this.txtBox_ShipCode.Location = new System.Drawing.Point(20, 213);
            this.txtBox_ShipCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_ShipCode.Name = "txtBox_ShipCode";
            this.txtBox_ShipCode.Size = new System.Drawing.Size(276, 22);
            this.txtBox_ShipCode.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 192);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Ship Code";
            // 
            // EditStoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 301);
            this.Controls.Add(this.txtBox_StorePhone);
            this.Controls.Add(this.but_StoreAdd);
            this.Controls.Add(this.but_StoreDelete);
            this.Controls.Add(this.but_StoreUpdate);
            this.Controls.Add(this.ChkBox_StoreInactive);
            this.Controls.Add(this.lbl_NicName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBox_ShipCode);
            this.Controls.Add(this.txtBox_StoreCity);
            this.Controls.Add(this.txtBox_StoreZip);
            this.Controls.Add(this.txtBox_StoreAddress);
            this.Controls.Add(this.txtBox_StoreState);
            this.Controls.Add(this.txtBox_StoreNicName);
            this.Controls.Add(this.txtBox_StoreName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EditStoreForm";
            this.Text = "Edit Stores";
            this.Load += new System.EventHandler(this.EditStoreForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditStoreForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MaskedTextBox txtBox_StorePhone;
        public System.Windows.Forms.Button but_StoreAdd;
        public System.Windows.Forms.Button but_StoreDelete;
        public System.Windows.Forms.Button but_StoreUpdate;
        public System.Windows.Forms.CheckBox ChkBox_StoreInactive;
        private System.Windows.Forms.Label lbl_NicName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtBox_StoreCity;
        public System.Windows.Forms.TextBox txtBox_StoreZip;
        public System.Windows.Forms.TextBox txtBox_StoreAddress;
        public System.Windows.Forms.TextBox txtBox_StoreState;
        public System.Windows.Forms.TextBox txtBox_StoreNicName;
        public System.Windows.Forms.TextBox txtBox_StoreName;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtBox_ShipCode;
        private System.Windows.Forms.Label label1;
    }
}