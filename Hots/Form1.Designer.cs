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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Log = new System.Windows.Forms.TabPage();
            this.txtBox_Errors = new System.Windows.Forms.TextBox();
            this.txtBox_Log = new System.Windows.Forms.TextBox();
            this.tab_OrdSys = new System.Windows.Forms.TabPage();
            this.Gridview_OS = new System.Windows.Forms.DataGridView();
            this.tab_Stores = new System.Windows.Forms.TabPage();
            this.but_SetStore = new System.Windows.Forms.Button();
            this.but_AddStore = new System.Windows.Forms.Button();
            this.lbl_SelectedStore = new System.Windows.Forms.Label();
            this.Gridview_Stores = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_UpateOrders = new System.Windows.Forms.Button();
            this.Gridview_OrdHeaders = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tab_Log.SuspendLayout();
            this.tab_OrdSys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gridview_OS)).BeginInit();
            this.tab_Stores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gridview_Stores)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gridview_OrdHeaders)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_Log);
            this.tabControl1.Controls.Add(this.tab_OrdSys);
            this.tabControl1.Controls.Add(this.tab_Stores);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(8, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(968, 316);
            this.tabControl1.TabIndex = 1;
            // 
            // tab_Log
            // 
            this.tab_Log.Controls.Add(this.txtBox_Errors);
            this.tab_Log.Controls.Add(this.txtBox_Log);
            this.tab_Log.Location = new System.Drawing.Point(4, 22);
            this.tab_Log.Name = "tab_Log";
            this.tab_Log.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tab_Log.Size = new System.Drawing.Size(960, 290);
            this.tab_Log.TabIndex = 0;
            this.tab_Log.Text = "Log";
            this.tab_Log.UseVisualStyleBackColor = true;
            // 
            // txtBox_Errors
            // 
            this.txtBox_Errors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBox_Errors.Location = new System.Drawing.Point(484, 6);
            this.txtBox_Errors.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBox_Errors.Multiline = true;
            this.txtBox_Errors.Name = "txtBox_Errors";
            this.txtBox_Errors.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBox_Errors.Size = new System.Drawing.Size(475, 282);
            this.txtBox_Errors.TabIndex = 1;
            // 
            // txtBox_Log
            // 
            this.txtBox_Log.Location = new System.Drawing.Point(5, 6);
            this.txtBox_Log.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBox_Log.Multiline = true;
            this.txtBox_Log.Name = "txtBox_Log";
            this.txtBox_Log.ReadOnly = true;
            this.txtBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBox_Log.Size = new System.Drawing.Size(475, 282);
            this.txtBox_Log.TabIndex = 0;
            // 
            // tab_OrdSys
            // 
            this.tab_OrdSys.Controls.Add(this.Gridview_OS);
            this.tab_OrdSys.Location = new System.Drawing.Point(4, 22);
            this.tab_OrdSys.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tab_OrdSys.Name = "tab_OrdSys";
            this.tab_OrdSys.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tab_OrdSys.Size = new System.Drawing.Size(960, 290);
            this.tab_OrdSys.TabIndex = 6;
            this.tab_OrdSys.Text = "Order Systems";
            this.tab_OrdSys.UseVisualStyleBackColor = true;
            // 
            // Gridview_OS
            // 
            this.Gridview_OS.AllowUserToAddRows = false;
            this.Gridview_OS.AllowUserToDeleteRows = false;
            this.Gridview_OS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Gridview_OS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gridview_OS.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Gridview_OS.Location = new System.Drawing.Point(8, 56);
            this.Gridview_OS.Name = "Gridview_OS";
            this.Gridview_OS.ReadOnly = true;
            this.Gridview_OS.ShowEditingIcon = false;
            this.Gridview_OS.Size = new System.Drawing.Size(944, 232);
            this.Gridview_OS.TabIndex = 20;
            this.Gridview_OS.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ordSysGrid_DblClicked);
            // 
            // tab_Stores
            // 
            this.tab_Stores.Controls.Add(this.but_SetStore);
            this.tab_Stores.Controls.Add(this.but_AddStore);
            this.tab_Stores.Controls.Add(this.lbl_SelectedStore);
            this.tab_Stores.Controls.Add(this.Gridview_Stores);
            this.tab_Stores.Location = new System.Drawing.Point(4, 22);
            this.tab_Stores.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tab_Stores.Name = "tab_Stores";
            this.tab_Stores.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tab_Stores.Size = new System.Drawing.Size(960, 290);
            this.tab_Stores.TabIndex = 7;
            this.tab_Stores.Text = "Stores";
            this.tab_Stores.UseVisualStyleBackColor = true;
            // 
            // but_SetStore
            // 
            this.but_SetStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.but_SetStore.Location = new System.Drawing.Point(9, 15);
            this.but_SetStore.Name = "but_SetStore";
            this.but_SetStore.Size = new System.Drawing.Size(104, 27);
            this.but_SetStore.TabIndex = 24;
            this.but_SetStore.Text = "Set Store";
            this.but_SetStore.UseVisualStyleBackColor = true;
            this.but_SetStore.Click += new System.EventHandler(this.but_SetStore_Click);
            // 
            // but_AddStore
            // 
            this.but_AddStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.but_AddStore.Location = new System.Drawing.Point(848, 16);
            this.but_AddStore.Name = "but_AddStore";
            this.but_AddStore.Size = new System.Drawing.Size(104, 27);
            this.but_AddStore.TabIndex = 24;
            this.but_AddStore.Text = "Add Store";
            this.but_AddStore.UseVisualStyleBackColor = true;
            this.but_AddStore.Click += new System.EventHandler(this.but_AddStore_Click);
            // 
            // lbl_SelectedStore
            // 
            this.lbl_SelectedStore.AutoSize = true;
            this.lbl_SelectedStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SelectedStore.Location = new System.Drawing.Point(118, 18);
            this.lbl_SelectedStore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SelectedStore.Name = "lbl_SelectedStore";
            this.lbl_SelectedStore.Size = new System.Drawing.Size(108, 24);
            this.lbl_SelectedStore.TabIndex = 23;
            this.lbl_SelectedStore.Text = "Select store";
            // 
            // Gridview_Stores
            // 
            this.Gridview_Stores.AllowUserToAddRows = false;
            this.Gridview_Stores.AllowUserToDeleteRows = false;
            this.Gridview_Stores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Gridview_Stores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gridview_Stores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Gridview_Stores.Location = new System.Drawing.Point(9, 55);
            this.Gridview_Stores.Name = "Gridview_Stores";
            this.Gridview_Stores.ShowEditingIcon = false;
            this.Gridview_Stores.Size = new System.Drawing.Size(944, 232);
            this.Gridview_Stores.TabIndex = 21;
            this.Gridview_Stores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gridview_Stores_CellDoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_UpateOrders);
            this.tabPage1.Controls.Add(this.Gridview_OrdHeaders);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(960, 290);
            this.tabPage1.TabIndex = 8;
            this.tabPage1.Text = "Uploaded Orders";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_UpateOrders
            // 
            this.btn_UpateOrders.Location = new System.Drawing.Point(9, 20);
            this.btn_UpateOrders.Name = "btn_UpateOrders";
            this.btn_UpateOrders.Size = new System.Drawing.Size(104, 27);
            this.btn_UpateOrders.TabIndex = 23;
            this.btn_UpateOrders.Text = "Update";
            this.btn_UpateOrders.UseVisualStyleBackColor = true;
            this.btn_UpateOrders.Click += new System.EventHandler(this.btn_UpateOrders_Click);
            // 
            // Gridview_OrdHeaders
            // 
            this.Gridview_OrdHeaders.AllowUserToAddRows = false;
            this.Gridview_OrdHeaders.AllowUserToDeleteRows = false;
            this.Gridview_OrdHeaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Gridview_OrdHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gridview_OrdHeaders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Gridview_OrdHeaders.Location = new System.Drawing.Point(9, 55);
            this.Gridview_OrdHeaders.Name = "Gridview_OrdHeaders";
            this.Gridview_OrdHeaders.ReadOnly = true;
            this.Gridview_OrdHeaders.ShowEditingIcon = false;
            this.Gridview_OrdHeaders.Size = new System.Drawing.Size(944, 232);
            this.Gridview_OrdHeaders.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 397);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Hots Order Uploader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_Log.ResumeLayout(false);
            this.tab_Log.PerformLayout();
            this.tab_OrdSys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Gridview_OS)).EndInit();
            this.tab_Stores.ResumeLayout(false);
            this.tab_Stores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gridview_Stores)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Gridview_OrdHeaders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Log;
        private System.Windows.Forms.TabPage tab_OrdSys;
        private System.Windows.Forms.TextBox txtBox_Log;
        private System.Windows.Forms.DataGridView Gridview_OS;
        private System.Windows.Forms.TextBox txtBox_Errors;
        private System.Windows.Forms.TabPage tab_Stores;
        private System.Windows.Forms.Button but_AddStore;
        private System.Windows.Forms.Label lbl_SelectedStore;
        private System.Windows.Forms.DataGridView Gridview_Stores;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_UpateOrders;
        private System.Windows.Forms.DataGridView Gridview_OrdHeaders;
        private System.Windows.Forms.Button but_SetStore;
    }
}

