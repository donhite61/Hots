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
            this.but_StartWatch = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_NewOrders = new System.Windows.Forms.TabPage();
            this.tab_OrdSys = new System.Windows.Forms.TabPage();
            this.but_SetWchGen = new System.Windows.Forms.Button();
            this.txtBox_WchRoot = new System.Windows.Forms.TextBox();
            this.lbl_RcvOrder = new System.Windows.Forms.Label();
            this.Gridview_OS = new System.Windows.Forms.DataGridView();
            this.txtBox_Log = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tab_NewOrders.SuspendLayout();
            this.tab_OrdSys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gridview_OS)).BeginInit();
            this.SuspendLayout();
            // 
            // but_StartWatch
            // 
            this.but_StartWatch.Location = new System.Drawing.Point(1152, 443);
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
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1291, 389);
            this.tabControl1.TabIndex = 1;
            // 
            // tab_NewOrders
            // 
            this.tab_NewOrders.Controls.Add(this.txtBox_Log);
            this.tab_NewOrders.Location = new System.Drawing.Point(4, 25);
            this.tab_NewOrders.Margin = new System.Windows.Forms.Padding(4);
            this.tab_NewOrders.Name = "tab_NewOrders";
            this.tab_NewOrders.Padding = new System.Windows.Forms.Padding(4);
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
            // but_SetWchGen
            // 
            this.but_SetWchGen.Location = new System.Drawing.Point(21, 30);
            this.but_SetWchGen.Margin = new System.Windows.Forms.Padding(4);
            this.but_SetWchGen.Name = "but_SetWchGen";
            this.but_SetWchGen.Size = new System.Drawing.Size(139, 33);
            this.but_SetWchGen.TabIndex = 18;
            this.but_SetWchGen.Text = "Watched Root";
            this.but_SetWchGen.UseVisualStyleBackColor = true;
            this.but_SetWchGen.Click += new System.EventHandler(this.but_SetWchRoot_Click);
            // 
            // txtBox_WchRoot
            // 
            this.txtBox_WchRoot.Location = new System.Drawing.Point(172, 33);
            this.txtBox_WchRoot.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_WchRoot.Name = "txtBox_WchRoot";
            this.txtBox_WchRoot.ReadOnly = true;
            this.txtBox_WchRoot.Size = new System.Drawing.Size(649, 22);
            this.txtBox_WchRoot.TabIndex = 19;
            // 
            // lbl_RcvOrder
            // 
            this.lbl_RcvOrder.AutoSize = true;
            this.lbl_RcvOrder.ForeColor = System.Drawing.Color.Red;
            this.lbl_RcvOrder.Location = new System.Drawing.Point(21, 10);
            this.lbl_RcvOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_RcvOrder.Name = "lbl_RcvOrder";
            this.lbl_RcvOrder.Size = new System.Drawing.Size(73, 17);
            this.lbl_RcvOrder.TabIndex = 2;
            this.lbl_RcvOrder.Text = "Rcv Order";
            this.lbl_RcvOrder.Visible = false;
            // 
            // Gridview_OS
            // 
            this.Gridview_OS.AllowUserToAddRows = false;
            this.Gridview_OS.AllowUserToDeleteRows = false;
            this.Gridview_OS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gridview_OS.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Gridview_OS.Location = new System.Drawing.Point(11, 69);
            this.Gridview_OS.Margin = new System.Windows.Forms.Padding(4);
            this.Gridview_OS.Name = "Gridview_OS";
            this.Gridview_OS.ReadOnly = true;
            this.Gridview_OS.ShowEditingIcon = false;
            this.Gridview_OS.Size = new System.Drawing.Size(1259, 226);
            this.Gridview_OS.TabIndex = 20;
            this.Gridview_OS.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ordSysGrid_DblClicked);
            // 
            // txtBox_Log
            // 
            this.txtBox_Log.Location = new System.Drawing.Point(15, 16);
            this.txtBox_Log.Multiline = true;
            this.txtBox_Log.Name = "txtBox_Log";
            this.txtBox_Log.ReadOnly = true;
            this.txtBox_Log.Size = new System.Drawing.Size(549, 333);
            this.txtBox_Log.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 489);
            this.Controls.Add(this.lbl_RcvOrder);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.but_StartWatch);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Hots ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_NewOrders.ResumeLayout(false);
            this.tab_NewOrders.PerformLayout();
            this.tab_OrdSys.ResumeLayout(false);
            this.tab_OrdSys.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gridview_OS)).EndInit();
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
        private System.Windows.Forms.Label lbl_RcvOrder;
        private System.Windows.Forms.TextBox txtBox_Log;
        private System.Windows.Forms.DataGridView Gridview_OS;
    }
}

