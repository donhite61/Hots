namespace Hots
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.but_StartWatch = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_NewOrders = new System.Windows.Forms.TabPage();
            this.tab_OrdSys = new System.Windows.Forms.TabPage();
            this.Gridview_OS = new System.Windows.Forms.DataGridView();
            this.but_SetWchGen = new System.Windows.Forms.Button();
            this.txtBox_WchRoot = new System.Windows.Forms.TextBox();
            this.led_RoesOn = new System.Windows.Forms.PictureBox();
            this.led_RoesOff = new System.Windows.Forms.PictureBox();
            this.led_RoesErr = new System.Windows.Forms.PictureBox();
            this.led_DakisOff = new System.Windows.Forms.PictureBox();
            this.led_DakisOn = new System.Windows.Forms.PictureBox();
            this.led_dakisErr = new System.Windows.Forms.PictureBox();
            this.led_DGiftOff = new System.Windows.Forms.PictureBox();
            this.led_DGiftOn = new System.Windows.Forms.PictureBox();
            this.led_DGiftErr = new System.Windows.Forms.PictureBox();
            this.led_PrtWzdOff = new System.Windows.Forms.PictureBox();
            this.led_PrtWzdOn = new System.Windows.Forms.PictureBox();
            this.led_PrtWzdErr = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tab_OrdSys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gridview_OS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_RoesOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_RoesOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_RoesErr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_DakisOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_DakisOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_dakisErr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_DGiftOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_DGiftOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_DGiftErr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_PrtWzdOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_PrtWzdOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_PrtWzdErr)).BeginInit();
            this.SuspendLayout();
            // 
            // but_StartWatch
            // 
            this.but_StartWatch.Location = new System.Drawing.Point(383, 450);
            this.but_StartWatch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.but_StartWatch.Name = "but_StartWatch";
            this.but_StartWatch.Size = new System.Drawing.Size(123, 28);
            this.but_StartWatch.TabIndex = 0;
            this.but_StartWatch.Text = "Start Watch";
            this.but_StartWatch.UseVisualStyleBackColor = true;
            this.but_StartWatch.Click += new System.EventHandler(this.but_StartWatch_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_NewOrders);
            this.tabControl1.Controls.Add(this.tab_OrdSys);
            this.tabControl1.Location = new System.Drawing.Point(11, 39);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1291, 389);
            this.tabControl1.TabIndex = 1;
            // 
            // tab_NewOrders
            // 
            this.tab_NewOrders.Location = new System.Drawing.Point(4, 25);
            this.tab_NewOrders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tab_NewOrders.Name = "tab_NewOrders";
            this.tab_NewOrders.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tab_NewOrders.Size = new System.Drawing.Size(1283, 360);
            this.tab_NewOrders.TabIndex = 0;
            this.tab_NewOrders.Text = "New Orders";
            this.tab_NewOrders.UseVisualStyleBackColor = true;
            // 
            // tab_OrdSys
            // 
            this.tab_OrdSys.Controls.Add(this.Gridview_OS);
            this.tab_OrdSys.Controls.Add(this.but_SetWchGen);
            this.tab_OrdSys.Controls.Add(this.txtBox_WchRoot);
            this.tab_OrdSys.Location = new System.Drawing.Point(4, 25);
            this.tab_OrdSys.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tab_OrdSys.Name = "tab_OrdSys";
            this.tab_OrdSys.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tab_OrdSys.Size = new System.Drawing.Size(1283, 360);
            this.tab_OrdSys.TabIndex = 6;
            this.tab_OrdSys.Text = "Order Systems";
            this.tab_OrdSys.UseVisualStyleBackColor = true;
            // 
            // Gridview_OS
            // 
            this.Gridview_OS.AllowUserToAddRows = false;
            this.Gridview_OS.AllowUserToDeleteRows = false;
            this.Gridview_OS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gridview_OS.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Gridview_OS.Location = new System.Drawing.Point(11, 69);
            this.Gridview_OS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Gridview_OS.Name = "Gridview_OS";
            this.Gridview_OS.ReadOnly = true;
            this.Gridview_OS.ShowEditingIcon = false;
            this.Gridview_OS.Size = new System.Drawing.Size(1259, 226);
            this.Gridview_OS.TabIndex = 20;
            this.Gridview_OS.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrdSysGrid_DblClicked);
            // 
            // but_SetWchGen
            // 
            this.but_SetWchGen.Location = new System.Drawing.Point(21, 33);
            this.but_SetWchGen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.but_SetWchGen.Name = "but_SetWchGen";
            this.but_SetWchGen.Size = new System.Drawing.Size(139, 30);
            this.but_SetWchGen.TabIndex = 18;
            this.but_SetWchGen.Text = "Watched Root";
            this.but_SetWchGen.UseVisualStyleBackColor = true;
            this.but_SetWchGen.Click += new System.EventHandler(this.but_SetWchGen_Click);
            // 
            // txtBox_WchRoot
            // 
            this.txtBox_WchRoot.Location = new System.Drawing.Point(172, 33);
            this.txtBox_WchRoot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBox_WchRoot.Name = "txtBox_WchRoot";
            this.txtBox_WchRoot.Size = new System.Drawing.Size(649, 22);
            this.txtBox_WchRoot.TabIndex = 19;
            // 
            // led_RoesOn
            // 
            this.led_RoesOn.Image = ((System.Drawing.Image)(resources.GetObject("led_RoesOn.Image")));
            this.led_RoesOn.Location = new System.Drawing.Point(128, 10);
            this.led_RoesOn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.led_RoesOn.Name = "led_RoesOn";
            this.led_RoesOn.Size = new System.Drawing.Size(14, 14);
            this.led_RoesOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.led_RoesOn.TabIndex = 2;
            this.led_RoesOn.TabStop = false;
            this.led_RoesOn.Visible = false;
            // 
            // led_RoesOff
            // 
            this.led_RoesOff.Image = ((System.Drawing.Image)(resources.GetObject("led_RoesOff.Image")));
            this.led_RoesOff.Location = new System.Drawing.Point(128, 10);
            this.led_RoesOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.led_RoesOff.Name = "led_RoesOff";
            this.led_RoesOff.Size = new System.Drawing.Size(14, 14);
            this.led_RoesOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.led_RoesOff.TabIndex = 3;
            this.led_RoesOff.TabStop = false;
            // 
            // led_RoesErr
            // 
            this.led_RoesErr.Image = ((System.Drawing.Image)(resources.GetObject("led_RoesErr.Image")));
            this.led_RoesErr.Location = new System.Drawing.Point(128, 10);
            this.led_RoesErr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.led_RoesErr.Name = "led_RoesErr";
            this.led_RoesErr.Size = new System.Drawing.Size(14, 14);
            this.led_RoesErr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.led_RoesErr.TabIndex = 2;
            this.led_RoesErr.TabStop = false;
            this.led_RoesErr.Visible = false;
            // 
            // led_DakisOff
            // 
            this.led_DakisOff.Image = ((System.Drawing.Image)(resources.GetObject("led_DakisOff.Image")));
            this.led_DakisOff.Location = new System.Drawing.Point(192, 10);
            this.led_DakisOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.led_DakisOff.Name = "led_DakisOff";
            this.led_DakisOff.Size = new System.Drawing.Size(14, 14);
            this.led_DakisOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.led_DakisOff.TabIndex = 3;
            this.led_DakisOff.TabStop = false;
            // 
            // led_DakisOn
            // 
            this.led_DakisOn.Image = ((System.Drawing.Image)(resources.GetObject("led_DakisOn.Image")));
            this.led_DakisOn.Location = new System.Drawing.Point(192, 10);
            this.led_DakisOn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.led_DakisOn.Name = "led_DakisOn";
            this.led_DakisOn.Size = new System.Drawing.Size(14, 14);
            this.led_DakisOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.led_DakisOn.TabIndex = 2;
            this.led_DakisOn.TabStop = false;
            this.led_DakisOn.Visible = false;
            // 
            // led_dakisErr
            // 
            this.led_dakisErr.Image = ((System.Drawing.Image)(resources.GetObject("led_dakisErr.Image")));
            this.led_dakisErr.Location = new System.Drawing.Point(192, 10);
            this.led_dakisErr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.led_dakisErr.Name = "led_dakisErr";
            this.led_dakisErr.Size = new System.Drawing.Size(14, 14);
            this.led_dakisErr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.led_dakisErr.TabIndex = 2;
            this.led_dakisErr.TabStop = false;
            this.led_dakisErr.Visible = false;
            // 
            // led_DGiftOff
            // 
            this.led_DGiftOff.Image = ((System.Drawing.Image)(resources.GetObject("led_DGiftOff.Image")));
            this.led_DGiftOff.Location = new System.Drawing.Point(267, 10);
            this.led_DGiftOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.led_DGiftOff.Name = "led_DGiftOff";
            this.led_DGiftOff.Size = new System.Drawing.Size(14, 14);
            this.led_DGiftOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.led_DGiftOff.TabIndex = 3;
            this.led_DGiftOff.TabStop = false;
            // 
            // led_DGiftOn
            // 
            this.led_DGiftOn.Image = ((System.Drawing.Image)(resources.GetObject("led_DGiftOn.Image")));
            this.led_DGiftOn.Location = new System.Drawing.Point(267, 10);
            this.led_DGiftOn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.led_DGiftOn.Name = "led_DGiftOn";
            this.led_DGiftOn.Size = new System.Drawing.Size(14, 14);
            this.led_DGiftOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.led_DGiftOn.TabIndex = 2;
            this.led_DGiftOn.TabStop = false;
            this.led_DGiftOn.Visible = false;
            // 
            // led_DGiftErr
            // 
            this.led_DGiftErr.Image = ((System.Drawing.Image)(resources.GetObject("led_DGiftErr.Image")));
            this.led_DGiftErr.Location = new System.Drawing.Point(267, 10);
            this.led_DGiftErr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.led_DGiftErr.Name = "led_DGiftErr";
            this.led_DGiftErr.Size = new System.Drawing.Size(14, 14);
            this.led_DGiftErr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.led_DGiftErr.TabIndex = 2;
            this.led_DGiftErr.TabStop = false;
            this.led_DGiftErr.Visible = false;
            // 
            // led_PrtWzdOff
            // 
            this.led_PrtWzdOff.Image = ((System.Drawing.Image)(resources.GetObject("led_PrtWzdOff.Image")));
            this.led_PrtWzdOff.Location = new System.Drawing.Point(352, 10);
            this.led_PrtWzdOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.led_PrtWzdOff.Name = "led_PrtWzdOff";
            this.led_PrtWzdOff.Size = new System.Drawing.Size(14, 14);
            this.led_PrtWzdOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.led_PrtWzdOff.TabIndex = 3;
            this.led_PrtWzdOff.TabStop = false;
            // 
            // led_PrtWzdOn
            // 
            this.led_PrtWzdOn.Image = ((System.Drawing.Image)(resources.GetObject("led_PrtWzdOn.Image")));
            this.led_PrtWzdOn.Location = new System.Drawing.Point(352, 10);
            this.led_PrtWzdOn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.led_PrtWzdOn.Name = "led_PrtWzdOn";
            this.led_PrtWzdOn.Size = new System.Drawing.Size(14, 14);
            this.led_PrtWzdOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.led_PrtWzdOn.TabIndex = 2;
            this.led_PrtWzdOn.TabStop = false;
            this.led_PrtWzdOn.Visible = false;
            // 
            // led_PrtWzdErr
            // 
            this.led_PrtWzdErr.Image = ((System.Drawing.Image)(resources.GetObject("led_PrtWzdErr.Image")));
            this.led_PrtWzdErr.Location = new System.Drawing.Point(352, 10);
            this.led_PrtWzdErr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.led_PrtWzdErr.Name = "led_PrtWzdErr";
            this.led_PrtWzdErr.Size = new System.Drawing.Size(14, 14);
            this.led_PrtWzdErr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.led_PrtWzdErr.TabIndex = 2;
            this.led_PrtWzdErr.TabStop = false;
            this.led_PrtWzdErr.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 489);
            this.Controls.Add(this.led_PrtWzdErr);
            this.Controls.Add(this.led_DGiftErr);
            this.Controls.Add(this.led_dakisErr);
            this.Controls.Add(this.led_RoesErr);
            this.Controls.Add(this.led_PrtWzdOn);
            this.Controls.Add(this.led_DGiftOn);
            this.Controls.Add(this.led_DakisOn);
            this.Controls.Add(this.led_RoesOn);
            this.Controls.Add(this.led_PrtWzdOff);
            this.Controls.Add(this.led_DGiftOff);
            this.Controls.Add(this.led_DakisOff);
            this.Controls.Add(this.led_RoesOff);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.but_StartWatch);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_OrdSys.ResumeLayout(false);
            this.tab_OrdSys.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gridview_OS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_RoesOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_RoesOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_RoesErr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_DakisOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_DakisOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_dakisErr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_DGiftOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_DGiftOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_DGiftErr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_PrtWzdOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_PrtWzdOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_PrtWzdErr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_StartWatch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_NewOrders;
        private System.Windows.Forms.TabPage tab_OrdSys;
        private System.Windows.Forms.Button but_SetWchGen;
        private System.Windows.Forms.TextBox txtBox_WchRoot;
        private System.Windows.Forms.PictureBox led_RoesOn;
        private System.Windows.Forms.PictureBox led_RoesOff;
        private System.Windows.Forms.PictureBox led_RoesErr;
        private System.Windows.Forms.PictureBox led_DakisOff;
        private System.Windows.Forms.PictureBox led_DakisOn;
        private System.Windows.Forms.PictureBox led_dakisErr;
        private System.Windows.Forms.PictureBox led_DGiftOff;
        private System.Windows.Forms.PictureBox led_DGiftOn;
        private System.Windows.Forms.PictureBox led_DGiftErr;
        private System.Windows.Forms.PictureBox led_PrtWzdOff;
        private System.Windows.Forms.PictureBox led_PrtWzdOn;
        private System.Windows.Forms.PictureBox led_PrtWzdErr;
        private System.Windows.Forms.DataGridView Gridview_OS;
    }
}

