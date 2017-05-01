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
            this.tab_Stores = new System.Windows.Forms.TabControl();
            this.tab_NewOrders = new System.Windows.Forms.TabPage();
            this.Gridview_OrderList = new System.Windows.Forms.DataGridView();
            this.tab_OrdSys = new System.Windows.Forms.TabPage();
            this.Gridview_OS = new System.Windows.Forms.DataGridView();
            this.but_SetWchGen = new System.Windows.Forms.Button();
            this.txtBox_WchRoot = new System.Windows.Forms.TextBox();
            this.lbl_RcvOrder = new System.Windows.Forms.Label();
            this.but_GetOrders = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridview_Stores = new System.Windows.Forms.DataGridView();
            this.btn_AddStore = new System.Windows.Forms.Button();
            this.tab_Department = new System.Windows.Forms.TabPage();
            this.lbl_StoreName = new System.Windows.Forms.Label();
            this.lbl_StoreAddress = new System.Windows.Forms.Label();
            this.lbl_StorePhone = new System.Windows.Forms.Label();
            this.but_SelectStore = new System.Windows.Forms.Button();
            this.tab_Stores.SuspendLayout();
            this.tab_NewOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gridview_OrderList)).BeginInit();
            this.tab_OrdSys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gridview_OS)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridview_Stores)).BeginInit();
            this.SuspendLayout();
            // 
            // but_StartWatch
            // 
            this.but_StartWatch.Location = new System.Drawing.Point(860, 258);
            this.but_StartWatch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.but_StartWatch.Name = "but_StartWatch";
            this.but_StartWatch.Size = new System.Drawing.Size(92, 23);
            this.but_StartWatch.TabIndex = 0;
            this.but_StartWatch.Text = "Start Watch";
            this.but_StartWatch.UseVisualStyleBackColor = true;
            this.but_StartWatch.Click += new System.EventHandler(this.but_StartWatch_Click);
            // 
            // tab_Stores
            // 
            this.tab_Stores.Controls.Add(this.tab_NewOrders);
            this.tab_Stores.Controls.Add(this.tab_OrdSys);
            this.tab_Stores.Controls.Add(this.tabPage1);
            this.tab_Stores.Controls.Add(this.tab_Department);
            this.tab_Stores.Location = new System.Drawing.Point(8, 32);
            this.tab_Stores.Name = "tab_Stores";
            this.tab_Stores.SelectedIndex = 0;
            this.tab_Stores.Size = new System.Drawing.Size(968, 316);
            this.tab_Stores.TabIndex = 1;
            // 
            // tab_NewOrders
            // 
            this.tab_NewOrders.Controls.Add(this.Gridview_OrderList);
            this.tab_NewOrders.Controls.Add(this.but_GetOrders);
            this.tab_NewOrders.Location = new System.Drawing.Point(4, 22);
            this.tab_NewOrders.Name = "tab_NewOrders";
            this.tab_NewOrders.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tab_NewOrders.Size = new System.Drawing.Size(960, 290);
            this.tab_NewOrders.TabIndex = 0;
            this.tab_NewOrders.Text = "New Orders";
            this.tab_NewOrders.UseVisualStyleBackColor = true;
            // 
            // Gridview_OrderList
            // 
            this.Gridview_OrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gridview_OrderList.Location = new System.Drawing.Point(3, 3);
            this.Gridview_OrderList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Gridview_OrderList.Name = "Gridview_OrderList";
            this.Gridview_OrderList.RowTemplate.Height = 24;
            this.Gridview_OrderList.Size = new System.Drawing.Size(956, 245);
            this.Gridview_OrderList.TabIndex = 0;
            // 
            // tab_OrdSys
            // 
            this.tab_OrdSys.Controls.Add(this.Gridview_OS);
            this.tab_OrdSys.Controls.Add(this.but_SetWchGen);
            this.tab_OrdSys.Controls.Add(this.txtBox_WchRoot);
            this.tab_OrdSys.Controls.Add(this.but_StartWatch);
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
            this.Gridview_OS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gridview_OS.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Gridview_OS.Location = new System.Drawing.Point(0, 56);
            this.Gridview_OS.Name = "Gridview_OS";
            this.Gridview_OS.ReadOnly = true;
            this.Gridview_OS.ShowEditingIcon = false;
            this.Gridview_OS.Size = new System.Drawing.Size(960, 192);
            this.Gridview_OS.TabIndex = 20;
            this.Gridview_OS.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ordSysGrid_DblClicked);
            // 
            // but_SetWchGen
            // 
            this.but_SetWchGen.Location = new System.Drawing.Point(16, 16);
            this.but_SetWchGen.Name = "but_SetWchGen";
            this.but_SetWchGen.Size = new System.Drawing.Size(104, 27);
            this.but_SetWchGen.TabIndex = 18;
            this.but_SetWchGen.Text = "Watched Root";
            this.but_SetWchGen.UseVisualStyleBackColor = true;
            this.but_SetWchGen.Click += new System.EventHandler(this.but_SetWchRoot_Click);
            // 
            // txtBox_WchRoot
            // 
            this.txtBox_WchRoot.Location = new System.Drawing.Point(128, 24);
            this.txtBox_WchRoot.Name = "txtBox_WchRoot";
            this.txtBox_WchRoot.ReadOnly = true;
            this.txtBox_WchRoot.Size = new System.Drawing.Size(808, 20);
            this.txtBox_WchRoot.TabIndex = 19;
            // 
            // lbl_RcvOrder
            // 
            this.lbl_RcvOrder.AutoSize = true;
            this.lbl_RcvOrder.ForeColor = System.Drawing.Color.Red;
            this.lbl_RcvOrder.Location = new System.Drawing.Point(16, 8);
            this.lbl_RcvOrder.Name = "lbl_RcvOrder";
            this.lbl_RcvOrder.Size = new System.Drawing.Size(56, 13);
            this.lbl_RcvOrder.TabIndex = 2;
            this.lbl_RcvOrder.Text = "Rcv Order";
            this.lbl_RcvOrder.Visible = false;
            // 
            // but_GetOrders
            // 
            this.but_GetOrders.Location = new System.Drawing.Point(856, 256);
            this.but_GetOrders.Margin = new System.Windows.Forms.Padding(2);
            this.but_GetOrders.Name = "but_GetOrders";
            this.but_GetOrders.Size = new System.Drawing.Size(92, 23);
            this.but_GetOrders.TabIndex = 0;
            this.but_GetOrders.Text = "Get Orders";
            this.but_GetOrders.UseVisualStyleBackColor = true;
            this.but_GetOrders.Click += new System.EventHandler(this.but_GetOrders_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbl_StorePhone);
            this.tabPage1.Controls.Add(this.lbl_StoreAddress);
            this.tabPage1.Controls.Add(this.lbl_StoreName);
            this.tabPage1.Controls.Add(this.but_SelectStore);
            this.tabPage1.Controls.Add(this.btn_AddStore);
            this.tabPage1.Controls.Add(this.gridview_Stores);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(960, 290);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "Stores";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridview_Stores
            // 
            this.gridview_Stores.AllowUserToAddRows = false;
            this.gridview_Stores.AllowUserToDeleteRows = false;
            this.gridview_Stores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridview_Stores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridview_Stores.Location = new System.Drawing.Point(0, 120);
            this.gridview_Stores.Name = "gridview_Stores";
            this.gridview_Stores.ReadOnly = true;
            this.gridview_Stores.ShowEditingIcon = false;
            this.gridview_Stores.Size = new System.Drawing.Size(960, 159);
            this.gridview_Stores.TabIndex = 21;
            // 
            // btn_AddStore
            // 
            this.btn_AddStore.Location = new System.Drawing.Point(840, 8);
            this.btn_AddStore.Name = "btn_AddStore";
            this.btn_AddStore.Size = new System.Drawing.Size(104, 27);
            this.btn_AddStore.TabIndex = 22;
            this.btn_AddStore.Text = "Add Store";
            this.btn_AddStore.UseVisualStyleBackColor = true;
            // 
            // tab_Department
            // 
            this.tab_Department.Location = new System.Drawing.Point(4, 22);
            this.tab_Department.Name = "tab_Department";
            this.tab_Department.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Department.Size = new System.Drawing.Size(960, 290);
            this.tab_Department.TabIndex = 8;
            this.tab_Department.Text = "Departments";
            this.tab_Department.UseVisualStyleBackColor = true;
            // 
            // lbl_StoreName
            // 
            this.lbl_StoreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_StoreName.Location = new System.Drawing.Point(16, 16);
            this.lbl_StoreName.Name = "lbl_StoreName";
            this.lbl_StoreName.Size = new System.Drawing.Size(392, 32);
            this.lbl_StoreName.TabIndex = 23;
            this.lbl_StoreName.Text = "Store Name";
            // 
            // lbl_StoreAddress
            // 
            this.lbl_StoreAddress.Location = new System.Drawing.Point(16, 56);
            this.lbl_StoreAddress.Name = "lbl_StoreAddress";
            this.lbl_StoreAddress.Size = new System.Drawing.Size(392, 24);
            this.lbl_StoreAddress.TabIndex = 23;
            this.lbl_StoreAddress.Text = "Store Address";
            // 
            // lbl_StorePhone
            // 
            this.lbl_StorePhone.Location = new System.Drawing.Point(16, 88);
            this.lbl_StorePhone.Name = "lbl_StorePhone";
            this.lbl_StorePhone.Size = new System.Drawing.Size(392, 24);
            this.lbl_StorePhone.TabIndex = 23;
            this.lbl_StorePhone.Text = "Store Phone";
            // 
            // but_SelectStore
            // 
            this.but_SelectStore.Location = new System.Drawing.Point(840, 48);
            this.but_SelectStore.Name = "but_SelectStore";
            this.but_SelectStore.Size = new System.Drawing.Size(104, 27);
            this.but_SelectStore.TabIndex = 22;
            this.but_SelectStore.Text = "Select Store";
            this.but_SelectStore.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 397);
            this.Controls.Add(this.lbl_RcvOrder);
            this.Controls.Add(this.tab_Stores);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Hots ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tab_Stores.ResumeLayout(false);
            this.tab_NewOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Gridview_OrderList)).EndInit();
            this.tab_OrdSys.ResumeLayout(false);
            this.tab_OrdSys.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gridview_OS)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridview_Stores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_StartWatch;
        private System.Windows.Forms.TabControl tab_Stores;
        private System.Windows.Forms.TabPage tab_NewOrders;
        private System.Windows.Forms.TabPage tab_OrdSys;
        private System.Windows.Forms.Button but_SetWchGen;
        private System.Windows.Forms.TextBox txtBox_WchRoot;
        private System.Windows.Forms.DataGridView Gridview_OS;
        private System.Windows.Forms.Label lbl_RcvOrder;
        private System.Windows.Forms.DataGridView Gridview_OrderList;
        private System.Windows.Forms.Button but_GetOrders;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_AddStore;
        private System.Windows.Forms.DataGridView gridview_Stores;
        private System.Windows.Forms.Label lbl_StorePhone;
        private System.Windows.Forms.Label lbl_StoreAddress;
        private System.Windows.Forms.Label lbl_StoreName;
        private System.Windows.Forms.Button but_SelectStore;
        private System.Windows.Forms.TabPage tab_Department;
    }
}

