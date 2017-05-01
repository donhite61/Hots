namespace Timeclock
{
    partial class EditPunchForm
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
            this.cmbBox_Stores = new System.Windows.Forms.ComboBox();
            this.txt_Note = new System.Windows.Forms.TextBox();
            this.cmbBox_Employees = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.but_Add = new System.Windows.Forms.Button();
            this.but_Update = new System.Windows.Forms.Button();
            this.but_Delete = new System.Windows.Forms.Button();
            this.dTPickerIn = new System.Windows.Forms.DateTimePicker();
            this.dTPickerOut = new System.Windows.Forms.DateTimePicker();
            this.chkBox_EnableOutPicker = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_TimeInOrg = new System.Windows.Forms.Label();
            this.lbl_TimeOutOrg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbBox_Stores
            // 
            this.cmbBox_Stores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox_Stores.FormattingEnabled = true;
            this.cmbBox_Stores.Location = new System.Drawing.Point(32, 31);
            this.cmbBox_Stores.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBox_Stores.Name = "cmbBox_Stores";
            this.cmbBox_Stores.Size = new System.Drawing.Size(160, 24);
            this.cmbBox_Stores.TabIndex = 1;
            this.cmbBox_Stores.SelectionChangeCommitted += new System.EventHandler(this.cmbBox_Stores_SelectionChangeCommitted);
            // 
            // txt_Note
            // 
            this.txt_Note.Location = new System.Drawing.Point(35, 288);
            this.txt_Note.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Note.Name = "txt_Note";
            this.txt_Note.Size = new System.Drawing.Size(380, 22);
            this.txt_Note.TabIndex = 0;
            // 
            // cmbBox_Employees
            // 
            this.cmbBox_Employees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox_Employees.FormattingEnabled = true;
            this.cmbBox_Employees.Location = new System.Drawing.Point(252, 31);
            this.cmbBox_Employees.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBox_Employees.Name = "cmbBox_Employees";
            this.cmbBox_Employees.Size = new System.Drawing.Size(160, 24);
            this.cmbBox_Employees.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Employee Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time In";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 268);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Note";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Store";
            // 
            // but_Add
            // 
            this.but_Add.Location = new System.Drawing.Point(33, 332);
            this.but_Add.Margin = new System.Windows.Forms.Padding(4);
            this.but_Add.Name = "but_Add";
            this.but_Add.Size = new System.Drawing.Size(93, 27);
            this.but_Add.TabIndex = 3;
            this.but_Add.Text = "Add";
            this.but_Add.UseVisualStyleBackColor = true;
            this.but_Add.Click += new System.EventHandler(this.but_PunchAdd_Click);
            // 
            // but_Update
            // 
            this.but_Update.Location = new System.Drawing.Point(176, 332);
            this.but_Update.Margin = new System.Windows.Forms.Padding(4);
            this.but_Update.Name = "but_Update";
            this.but_Update.Size = new System.Drawing.Size(93, 27);
            this.but_Update.TabIndex = 3;
            this.but_Update.Text = "Update";
            this.but_Update.UseVisualStyleBackColor = true;
            this.but_Update.Click += new System.EventHandler(this.but_PunchUpdate_Click);
            // 
            // but_Delete
            // 
            this.but_Delete.Location = new System.Drawing.Point(319, 332);
            this.but_Delete.Margin = new System.Windows.Forms.Padding(4);
            this.but_Delete.Name = "but_Delete";
            this.but_Delete.Size = new System.Drawing.Size(93, 27);
            this.but_Delete.TabIndex = 3;
            this.but_Delete.Text = "Delete";
            this.but_Delete.UseVisualStyleBackColor = true;
            this.but_Delete.Click += new System.EventHandler(this.but_PunchDelete_Click);
            // 
            // dTPickerIn
            // 
            this.dTPickerIn.CustomFormat = "ddd  MM/dd/yyyy  h:mm tt";
            this.dTPickerIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPickerIn.Location = new System.Drawing.Point(32, 98);
            this.dTPickerIn.Margin = new System.Windows.Forms.Padding(4);
            this.dTPickerIn.Name = "dTPickerIn";
            this.dTPickerIn.Size = new System.Drawing.Size(237, 22);
            this.dTPickerIn.TabIndex = 4;
            this.dTPickerIn.ValueChanged += new System.EventHandler(this.dTPickerIn_ValueChanged);
            // 
            // dTPickerOut
            // 
            this.dTPickerOut.CustomFormat = "ddd  MM/dd/yyyy  h:mm tt";
            this.dTPickerOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPickerOut.Location = new System.Drawing.Point(32, 188);
            this.dTPickerOut.Margin = new System.Windows.Forms.Padding(4);
            this.dTPickerOut.Name = "dTPickerOut";
            this.dTPickerOut.Size = new System.Drawing.Size(237, 22);
            this.dTPickerOut.TabIndex = 5;
            // 
            // chkBox_EnableOutPicker
            // 
            this.chkBox_EnableOutPicker.AutoSize = true;
            this.chkBox_EnableOutPicker.Location = new System.Drawing.Point(276, 188);
            this.chkBox_EnableOutPicker.Name = "chkBox_EnableOutPicker";
            this.chkBox_EnableOutPicker.Size = new System.Drawing.Size(74, 21);
            this.chkBox_EnableOutPicker.TabIndex = 6;
            this.chkBox_EnableOutPicker.Text = "Enable";
            this.chkBox_EnableOutPicker.UseVisualStyleBackColor = true;
            this.chkBox_EnableOutPicker.CheckedChanged += new System.EventHandler(this.chkBox_EnableOutPicker_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 167);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Time Out";
            // 
            // lbl_TimeInOrg
            // 
            this.lbl_TimeInOrg.AutoSize = true;
            this.lbl_TimeInOrg.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_TimeInOrg.Location = new System.Drawing.Point(33, 129);
            this.lbl_TimeInOrg.Name = "lbl_TimeInOrg";
            this.lbl_TimeInOrg.Size = new System.Drawing.Size(0, 17);
            this.lbl_TimeInOrg.TabIndex = 7;
            // 
            // lbl_TimeOutOrg
            // 
            this.lbl_TimeOutOrg.AutoSize = true;
            this.lbl_TimeOutOrg.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_TimeOutOrg.Location = new System.Drawing.Point(33, 219);
            this.lbl_TimeOutOrg.Name = "lbl_TimeOutOrg";
            this.lbl_TimeOutOrg.Size = new System.Drawing.Size(0, 17);
            this.lbl_TimeOutOrg.TabIndex = 7;
            // 
            // EditPunchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 393);
            this.Controls.Add(this.lbl_TimeOutOrg);
            this.Controls.Add(this.lbl_TimeInOrg);
            this.Controls.Add(this.chkBox_EnableOutPicker);
            this.Controls.Add(this.dTPickerOut);
            this.Controls.Add(this.dTPickerIn);
            this.Controls.Add(this.but_Delete);
            this.Controls.Add(this.but_Update);
            this.Controls.Add(this.but_Add);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBox_Stores);
            this.Controls.Add(this.cmbBox_Employees);
            this.Controls.Add(this.txt_Note);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditPunchForm";
            this.Text = "Edit Punches";
            this.Load += new System.EventHandler(this.EditPunchForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditPunchForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbBox_Stores;
        private System.Windows.Forms.TextBox txt_Note;
        private System.Windows.Forms.ComboBox cmbBox_Employees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button but_Add;
        private System.Windows.Forms.Button but_Update;
        private System.Windows.Forms.Button but_Delete;
        private System.Windows.Forms.DateTimePicker dTPickerIn;
        private System.Windows.Forms.DateTimePicker dTPickerOut;
        private System.Windows.Forms.CheckBox chkBox_EnableOutPicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_TimeInOrg;
        private System.Windows.Forms.Label lbl_TimeOutOrg;
    }
}