namespace Timeclock
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Clock = new System.Windows.Forms.TabPage();
            this.tab_Punches = new System.Windows.Forms.TabPage();
            this.btn_PunchPrint = new System.Windows.Forms.Button();
            this.btn_Add_Punch = new System.Windows.Forms.Button();
            this.cmbBox_Pch_Time_Filter = new System.Windows.Forms.ComboBox();
            this.cmbBox_Pch_Str_Filter = new System.Windows.Forms.ComboBox();
            this.cmbBox_Pch_Emp_Filter = new System.Windows.Forms.ComboBox();
            this.dgv_Punches = new System.Windows.Forms.DataGridView();
            this.tab_Employees = new System.Windows.Forms.TabPage();
            this.btn_Add_Emp = new System.Windows.Forms.Button();
            this.chkBox_ShowOtherStoreEmp = new System.Windows.Forms.CheckBox();
            this.chkBox_ShowEmpInactive = new System.Windows.Forms.CheckBox();
            this.dgv_Employees = new System.Windows.Forms.DataGridView();
            this.tab_Store = new System.Windows.Forms.TabPage();
            this.chkBox_ShowStoreInactive = new System.Windows.Forms.CheckBox();
            this.dgv_Stores = new System.Windows.Forms.DataGridView();
            this.btn_AddStore = new System.Windows.Forms.Button();
            this.but_UpdateStore = new System.Windows.Forms.Button();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.lbl_CityStZip = new System.Windows.Forms.Label();
            this.lbl_StoreAddress = new System.Windows.Forms.Label();
            this.lbl_StoreName = new System.Windows.Forms.Label();
            this.tab_Setup = new System.Windows.Forms.TabPage();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmbBox_ChooseDatabase = new System.Windows.Forms.ComboBox();
            this.but_UpdateSetup = new System.Windows.Forms.Button();
            this.but_TestDatabases = new System.Windows.Forms.Button();
            this.lbl_LocalPort = new System.Windows.Forms.Label();
            this.lbl_WebPort = new System.Windows.Forms.Label();
            this.lbl_LocalDatabase = new System.Windows.Forms.Label();
            this.lbl_WebDatabase = new System.Windows.Forms.Label();
            this.lbl_LocalUserName = new System.Windows.Forms.Label();
            this.lbl_WebUserName = new System.Windows.Forms.Label();
            this.lbl_LocalPassword = new System.Windows.Forms.Label();
            this.lbl_WebPassword = new System.Windows.Forms.Label();
            this.txtBox_LocalPort = new System.Windows.Forms.TextBox();
            this.txtBox_WebPort = new System.Windows.Forms.TextBox();
            this.lbl_LocalIP = new System.Windows.Forms.Label();
            this.lbl_WebIP = new System.Windows.Forms.Label();
            this.txtBox_LocalDatabase = new System.Windows.Forms.TextBox();
            this.txtBox_LocalPassword = new System.Windows.Forms.TextBox();
            this.txtBox_WebDatabase = new System.Windows.Forms.TextBox();
            this.txtBox_LocalUserName = new System.Windows.Forms.TextBox();
            this.txtBox_WebPassword = new System.Windows.Forms.TextBox();
            this.txtBox_LocalIp = new System.Windows.Forms.TextBox();
            this.txtBox_WebUserName = new System.Windows.Forms.TextBox();
            this.txtBox_WebIp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ReportBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tab_Punches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Punches)).BeginInit();
            this.tab_Employees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Employees)).BeginInit();
            this.tab_Store.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stores)).BeginInit();
            this.tab_Setup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReportBindingSource
            // 
            this.ReportBindingSource.DataSource = typeof(Timeclock.Report);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_Clock);
            this.tabControl1.Controls.Add(this.tab_Punches);
            this.tabControl1.Controls.Add(this.tab_Employees);
            this.tabControl1.Controls.Add(this.tab_Store);
            this.tabControl1.Controls.Add(this.tab_Setup);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(785, 586);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tab_Clock
            // 
            this.tab_Clock.Location = new System.Drawing.Point(4, 25);
            this.tab_Clock.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Clock.Name = "tab_Clock";
            this.tab_Clock.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Clock.Size = new System.Drawing.Size(777, 557);
            this.tab_Clock.TabIndex = 0;
            this.tab_Clock.Text = "Clock";
            this.tab_Clock.UseVisualStyleBackColor = true;
            // 
            // tab_Punches
            // 
            this.tab_Punches.Controls.Add(this.btn_PunchPrint);
            this.tab_Punches.Controls.Add(this.btn_Add_Punch);
            this.tab_Punches.Controls.Add(this.cmbBox_Pch_Time_Filter);
            this.tab_Punches.Controls.Add(this.cmbBox_Pch_Str_Filter);
            this.tab_Punches.Controls.Add(this.cmbBox_Pch_Emp_Filter);
            this.tab_Punches.Controls.Add(this.dgv_Punches);
            this.tab_Punches.Location = new System.Drawing.Point(4, 25);
            this.tab_Punches.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Punches.Name = "tab_Punches";
            this.tab_Punches.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Punches.Size = new System.Drawing.Size(777, 557);
            this.tab_Punches.TabIndex = 1;
            this.tab_Punches.Text = "Punches";
            this.tab_Punches.UseVisualStyleBackColor = true;
            // 
            // btn_PunchPrint
            // 
            this.btn_PunchPrint.Location = new System.Drawing.Point(292, 480);
            this.btn_PunchPrint.Name = "btn_PunchPrint";
            this.btn_PunchPrint.Size = new System.Drawing.Size(147, 26);
            this.btn_PunchPrint.TabIndex = 3;
            this.btn_PunchPrint.Text = "Print";
            this.btn_PunchPrint.UseVisualStyleBackColor = true;
            this.btn_PunchPrint.Click += new System.EventHandler(this.btn_PunchPrint_Click);
            // 
            // btn_Add_Punch
            // 
            this.btn_Add_Punch.Location = new System.Drawing.Point(649, 18);
            this.btn_Add_Punch.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Add_Punch.Name = "btn_Add_Punch";
            this.btn_Add_Punch.Size = new System.Drawing.Size(115, 28);
            this.btn_Add_Punch.TabIndex = 2;
            this.btn_Add_Punch.Text = "Add Punch";
            this.btn_Add_Punch.UseVisualStyleBackColor = true;
            this.btn_Add_Punch.Click += new System.EventHandler(this.btn_Add_Punch_Click);
            // 
            // cmbBox_Pch_Time_Filter
            // 
            this.cmbBox_Pch_Time_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox_Pch_Time_Filter.FormattingEnabled = true;
            this.cmbBox_Pch_Time_Filter.Location = new System.Drawing.Point(225, 21);
            this.cmbBox_Pch_Time_Filter.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBox_Pch_Time_Filter.Name = "cmbBox_Pch_Time_Filter";
            this.cmbBox_Pch_Time_Filter.Size = new System.Drawing.Size(168, 24);
            this.cmbBox_Pch_Time_Filter.TabIndex = 1;
            this.cmbBox_Pch_Time_Filter.SelectionChangeCommitted += new System.EventHandler(this.cmbBox_Pch_Filter_Changed);
            // 
            // cmbBox_Pch_Str_Filter
            // 
            this.cmbBox_Pch_Str_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox_Pch_Str_Filter.FormattingEnabled = true;
            this.cmbBox_Pch_Str_Filter.Location = new System.Drawing.Point(11, 21);
            this.cmbBox_Pch_Str_Filter.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBox_Pch_Str_Filter.Name = "cmbBox_Pch_Str_Filter";
            this.cmbBox_Pch_Str_Filter.Size = new System.Drawing.Size(168, 24);
            this.cmbBox_Pch_Str_Filter.TabIndex = 1;
            this.cmbBox_Pch_Str_Filter.SelectionChangeCommitted += new System.EventHandler(this.cmbBox_Pch_Str_Filter_Changed);
            // 
            // cmbBox_Pch_Emp_Filter
            // 
            this.cmbBox_Pch_Emp_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox_Pch_Emp_Filter.FormattingEnabled = true;
            this.cmbBox_Pch_Emp_Filter.Location = new System.Drawing.Point(443, 21);
            this.cmbBox_Pch_Emp_Filter.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBox_Pch_Emp_Filter.Name = "cmbBox_Pch_Emp_Filter";
            this.cmbBox_Pch_Emp_Filter.Size = new System.Drawing.Size(168, 24);
            this.cmbBox_Pch_Emp_Filter.TabIndex = 1;
            this.cmbBox_Pch_Emp_Filter.SelectionChangeCommitted += new System.EventHandler(this.cmbBox_Pch_Filter_Changed);
            // 
            // dgv_Punches
            // 
            this.dgv_Punches.AllowUserToAddRows = false;
            this.dgv_Punches.AllowUserToDeleteRows = false;
            this.dgv_Punches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Punches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Punches.Location = new System.Drawing.Point(8, 65);
            this.dgv_Punches.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Punches.Name = "dgv_Punches";
            this.dgv_Punches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Punches.Size = new System.Drawing.Size(769, 394);
            this.dgv_Punches.TabIndex = 0;
            this.dgv_Punches.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Punches_CellDoubleClick);
            // 
            // tab_Employees
            // 
            this.tab_Employees.Controls.Add(this.btn_Add_Emp);
            this.tab_Employees.Controls.Add(this.chkBox_ShowOtherStoreEmp);
            this.tab_Employees.Controls.Add(this.chkBox_ShowEmpInactive);
            this.tab_Employees.Controls.Add(this.dgv_Employees);
            this.tab_Employees.Location = new System.Drawing.Point(4, 25);
            this.tab_Employees.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Employees.Name = "tab_Employees";
            this.tab_Employees.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Employees.Size = new System.Drawing.Size(777, 557);
            this.tab_Employees.TabIndex = 2;
            this.tab_Employees.Text = "Employees";
            this.tab_Employees.UseVisualStyleBackColor = true;
            // 
            // btn_Add_Emp
            // 
            this.btn_Add_Emp.Location = new System.Drawing.Point(319, 11);
            this.btn_Add_Emp.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Add_Emp.Name = "btn_Add_Emp";
            this.btn_Add_Emp.Size = new System.Drawing.Size(171, 27);
            this.btn_Add_Emp.TabIndex = 2;
            this.btn_Add_Emp.Text = "Add Employee";
            this.btn_Add_Emp.UseVisualStyleBackColor = true;
            this.btn_Add_Emp.Click += new System.EventHandler(this.btn_Add_Emp_Click);
            // 
            // chkBox_ShowOtherStoreEmp
            // 
            this.chkBox_ShowOtherStoreEmp.AutoSize = true;
            this.chkBox_ShowOtherStoreEmp.Location = new System.Drawing.Point(11, 15);
            this.chkBox_ShowOtherStoreEmp.Margin = new System.Windows.Forms.Padding(4);
            this.chkBox_ShowOtherStoreEmp.Name = "chkBox_ShowOtherStoreEmp";
            this.chkBox_ShowOtherStoreEmp.Size = new System.Drawing.Size(222, 21);
            this.chkBox_ShowOtherStoreEmp.TabIndex = 1;
            this.chkBox_ShowOtherStoreEmp.Text = "Show Other Stores Employees";
            this.chkBox_ShowOtherStoreEmp.UseVisualStyleBackColor = true;
            this.chkBox_ShowOtherStoreEmp.CheckedChanged += new System.EventHandler(this.chkBox_EmployeesChanged);
            // 
            // chkBox_ShowEmpInactive
            // 
            this.chkBox_ShowEmpInactive.AutoSize = true;
            this.chkBox_ShowEmpInactive.Location = new System.Drawing.Point(639, 16);
            this.chkBox_ShowEmpInactive.Margin = new System.Windows.Forms.Padding(4);
            this.chkBox_ShowEmpInactive.Name = "chkBox_ShowEmpInactive";
            this.chkBox_ShowEmpInactive.Size = new System.Drawing.Size(116, 21);
            this.chkBox_ShowEmpInactive.TabIndex = 1;
            this.chkBox_ShowEmpInactive.Text = "Show Inactive";
            this.chkBox_ShowEmpInactive.UseVisualStyleBackColor = true;
            this.chkBox_ShowEmpInactive.CheckedChanged += new System.EventHandler(this.chkBox_EmployeesChanged);
            // 
            // dgv_Employees
            // 
            this.dgv_Employees.AllowUserToAddRows = false;
            this.dgv_Employees.AllowUserToDeleteRows = false;
            this.dgv_Employees.AllowUserToOrderColumns = true;
            this.dgv_Employees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Employees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Employees.Location = new System.Drawing.Point(4, 50);
            this.dgv_Employees.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Employees.Name = "dgv_Employees";
            this.dgv_Employees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Employees.Size = new System.Drawing.Size(765, 396);
            this.dgv_Employees.TabIndex = 0;
            this.dgv_Employees.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Employees_CellDoubleClick);
            // 
            // tab_Store
            // 
            this.tab_Store.Controls.Add(this.chkBox_ShowStoreInactive);
            this.tab_Store.Controls.Add(this.dgv_Stores);
            this.tab_Store.Controls.Add(this.btn_AddStore);
            this.tab_Store.Controls.Add(this.but_UpdateStore);
            this.tab_Store.Controls.Add(this.lbl_Phone);
            this.tab_Store.Controls.Add(this.lbl_CityStZip);
            this.tab_Store.Controls.Add(this.lbl_StoreAddress);
            this.tab_Store.Controls.Add(this.lbl_StoreName);
            this.tab_Store.Location = new System.Drawing.Point(4, 25);
            this.tab_Store.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Store.Name = "tab_Store";
            this.tab_Store.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Store.Size = new System.Drawing.Size(777, 557);
            this.tab_Store.TabIndex = 3;
            this.tab_Store.Text = "Store";
            this.tab_Store.UseVisualStyleBackColor = true;
            // 
            // chkBox_ShowStoreInactive
            // 
            this.chkBox_ShowStoreInactive.AutoSize = true;
            this.chkBox_ShowStoreInactive.Location = new System.Drawing.Point(631, 507);
            this.chkBox_ShowStoreInactive.Margin = new System.Windows.Forms.Padding(4);
            this.chkBox_ShowStoreInactive.Name = "chkBox_ShowStoreInactive";
            this.chkBox_ShowStoreInactive.Size = new System.Drawing.Size(116, 21);
            this.chkBox_ShowStoreInactive.TabIndex = 4;
            this.chkBox_ShowStoreInactive.Text = "Show Inactive";
            this.chkBox_ShowStoreInactive.UseVisualStyleBackColor = true;
            this.chkBox_ShowStoreInactive.CheckedChanged += new System.EventHandler(this.chkBox_ShowStoreInactive_CheckedChanged);
            // 
            // dgv_Stores
            // 
            this.dgv_Stores.AllowUserToAddRows = false;
            this.dgv_Stores.AllowUserToDeleteRows = false;
            this.dgv_Stores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Stores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Stores.Location = new System.Drawing.Point(19, 144);
            this.dgv_Stores.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Stores.MultiSelect = false;
            this.dgv_Stores.Name = "dgv_Stores";
            this.dgv_Stores.ReadOnly = true;
            this.dgv_Stores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Stores.Size = new System.Drawing.Size(745, 325);
            this.dgv_Stores.TabIndex = 3;
            this.dgv_Stores.VirtualMode = true;
            this.dgv_Stores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StoreCellDoubleClicked);
            // 
            // btn_AddStore
            // 
            this.btn_AddStore.Location = new System.Drawing.Point(24, 496);
            this.btn_AddStore.Margin = new System.Windows.Forms.Padding(4);
            this.btn_AddStore.Name = "btn_AddStore";
            this.btn_AddStore.Size = new System.Drawing.Size(151, 32);
            this.btn_AddStore.TabIndex = 2;
            this.btn_AddStore.Text = "Add Store";
            this.btn_AddStore.UseVisualStyleBackColor = true;
            this.btn_AddStore.Click += new System.EventHandler(this.but_AddStore_Click);
            // 
            // but_UpdateStore
            // 
            this.but_UpdateStore.Location = new System.Drawing.Point(316, 496);
            this.but_UpdateStore.Margin = new System.Windows.Forms.Padding(4);
            this.but_UpdateStore.Name = "but_UpdateStore";
            this.but_UpdateStore.Size = new System.Drawing.Size(151, 32);
            this.but_UpdateStore.TabIndex = 2;
            this.but_UpdateStore.Text = "Set Store";
            this.but_UpdateStore.UseVisualStyleBackColor = true;
            this.but_UpdateStore.Click += new System.EventHandler(this.but_UpdateStore_Click);
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Phone.Location = new System.Drawing.Point(32, 105);
            this.lbl_Phone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(724, 26);
            this.lbl_Phone.TabIndex = 0;
            this.lbl_Phone.Text = "Phone";
            this.lbl_Phone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_CityStZip
            // 
            this.lbl_CityStZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CityStZip.Location = new System.Drawing.Point(32, 79);
            this.lbl_CityStZip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CityStZip.Name = "lbl_CityStZip";
            this.lbl_CityStZip.Size = new System.Drawing.Size(724, 26);
            this.lbl_CityStZip.TabIndex = 0;
            this.lbl_CityStZip.Text = "City, ST, Zip";
            this.lbl_CityStZip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_StoreAddress
            // 
            this.lbl_StoreAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_StoreAddress.Location = new System.Drawing.Point(32, 53);
            this.lbl_StoreAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_StoreAddress.Name = "lbl_StoreAddress";
            this.lbl_StoreAddress.Size = new System.Drawing.Size(724, 26);
            this.lbl_StoreAddress.TabIndex = 0;
            this.lbl_StoreAddress.Text = "Address";
            this.lbl_StoreAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_StoreName
            // 
            this.lbl_StoreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_StoreName.Location = new System.Drawing.Point(32, 4);
            this.lbl_StoreName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_StoreName.Name = "lbl_StoreName";
            this.lbl_StoreName.Size = new System.Drawing.Size(724, 49);
            this.lbl_StoreName.TabIndex = 0;
            this.lbl_StoreName.Text = "Name";
            this.lbl_StoreName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tab_Setup
            // 
            this.tab_Setup.Controls.Add(this.reportViewer2);
            this.tab_Setup.Controls.Add(this.cmbBox_ChooseDatabase);
            this.tab_Setup.Controls.Add(this.but_UpdateSetup);
            this.tab_Setup.Controls.Add(this.but_TestDatabases);
            this.tab_Setup.Controls.Add(this.lbl_LocalPort);
            this.tab_Setup.Controls.Add(this.lbl_WebPort);
            this.tab_Setup.Controls.Add(this.lbl_LocalDatabase);
            this.tab_Setup.Controls.Add(this.lbl_WebDatabase);
            this.tab_Setup.Controls.Add(this.lbl_LocalUserName);
            this.tab_Setup.Controls.Add(this.lbl_WebUserName);
            this.tab_Setup.Controls.Add(this.lbl_LocalPassword);
            this.tab_Setup.Controls.Add(this.lbl_WebPassword);
            this.tab_Setup.Controls.Add(this.txtBox_LocalPort);
            this.tab_Setup.Controls.Add(this.txtBox_WebPort);
            this.tab_Setup.Controls.Add(this.lbl_LocalIP);
            this.tab_Setup.Controls.Add(this.lbl_WebIP);
            this.tab_Setup.Controls.Add(this.txtBox_LocalDatabase);
            this.tab_Setup.Controls.Add(this.txtBox_LocalPassword);
            this.tab_Setup.Controls.Add(this.txtBox_WebDatabase);
            this.tab_Setup.Controls.Add(this.txtBox_LocalUserName);
            this.tab_Setup.Controls.Add(this.txtBox_WebPassword);
            this.tab_Setup.Controls.Add(this.txtBox_LocalIp);
            this.tab_Setup.Controls.Add(this.txtBox_WebUserName);
            this.tab_Setup.Controls.Add(this.txtBox_WebIp);
            this.tab_Setup.Location = new System.Drawing.Point(4, 25);
            this.tab_Setup.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Setup.Name = "tab_Setup";
            this.tab_Setup.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Setup.Size = new System.Drawing.Size(777, 557);
            this.tab_Setup.TabIndex = 4;
            this.tab_Setup.Text = "Setup";
            this.tab_Setup.UseVisualStyleBackColor = true;
            // 
            // reportViewer2
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReportBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Timeclock.Report1.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(8, 11);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(756, 497);
            this.reportViewer2.TabIndex = 4;
            // 
            // cmbBox_ChooseDatabase
            // 
            this.cmbBox_ChooseDatabase.FormattingEnabled = true;
            this.cmbBox_ChooseDatabase.Location = new System.Drawing.Point(107, 396);
            this.cmbBox_ChooseDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBox_ChooseDatabase.Name = "cmbBox_ChooseDatabase";
            this.cmbBox_ChooseDatabase.Size = new System.Drawing.Size(159, 24);
            this.cmbBox_ChooseDatabase.TabIndex = 3;
            // 
            // but_UpdateSetup
            // 
            this.but_UpdateSetup.Location = new System.Drawing.Point(605, 396);
            this.but_UpdateSetup.Margin = new System.Windows.Forms.Padding(4);
            this.but_UpdateSetup.Name = "but_UpdateSetup";
            this.but_UpdateSetup.Size = new System.Drawing.Size(160, 26);
            this.but_UpdateSetup.TabIndex = 2;
            this.but_UpdateSetup.Text = "Update Setup";
            this.but_UpdateSetup.UseVisualStyleBackColor = true;
            // 
            // but_TestDatabases
            // 
            this.but_TestDatabases.Location = new System.Drawing.Point(356, 396);
            this.but_TestDatabases.Margin = new System.Windows.Forms.Padding(4);
            this.but_TestDatabases.Name = "but_TestDatabases";
            this.but_TestDatabases.Size = new System.Drawing.Size(160, 26);
            this.but_TestDatabases.TabIndex = 2;
            this.but_TestDatabases.Text = "Test Databases";
            this.but_TestDatabases.UseVisualStyleBackColor = true;
            // 
            // lbl_LocalPort
            // 
            this.lbl_LocalPort.AutoSize = true;
            this.lbl_LocalPort.Location = new System.Drawing.Point(544, 274);
            this.lbl_LocalPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_LocalPort.Name = "lbl_LocalPort";
            this.lbl_LocalPort.Size = new System.Drawing.Size(72, 17);
            this.lbl_LocalPort.TabIndex = 1;
            this.lbl_LocalPort.Text = "Local Port";
            // 
            // lbl_WebPort
            // 
            this.lbl_WebPort.AutoSize = true;
            this.lbl_WebPort.Location = new System.Drawing.Point(111, 274);
            this.lbl_WebPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_WebPort.Name = "lbl_WebPort";
            this.lbl_WebPort.Size = new System.Drawing.Size(67, 17);
            this.lbl_WebPort.TabIndex = 1;
            this.lbl_WebPort.Text = "Web Port";
            // 
            // lbl_LocalDatabase
            // 
            this.lbl_LocalDatabase.AutoSize = true;
            this.lbl_LocalDatabase.Location = new System.Drawing.Point(544, 215);
            this.lbl_LocalDatabase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_LocalDatabase.Name = "lbl_LocalDatabase";
            this.lbl_LocalDatabase.Size = new System.Drawing.Size(107, 17);
            this.lbl_LocalDatabase.TabIndex = 1;
            this.lbl_LocalDatabase.Text = "Local Database";
            // 
            // lbl_WebDatabase
            // 
            this.lbl_WebDatabase.AutoSize = true;
            this.lbl_WebDatabase.Location = new System.Drawing.Point(111, 215);
            this.lbl_WebDatabase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_WebDatabase.Name = "lbl_WebDatabase";
            this.lbl_WebDatabase.Size = new System.Drawing.Size(102, 17);
            this.lbl_WebDatabase.TabIndex = 1;
            this.lbl_WebDatabase.Text = "Web Database";
            // 
            // lbl_LocalUserName
            // 
            this.lbl_LocalUserName.AutoSize = true;
            this.lbl_LocalUserName.Location = new System.Drawing.Point(544, 97);
            this.lbl_LocalUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_LocalUserName.Name = "lbl_LocalUserName";
            this.lbl_LocalUserName.Size = new System.Drawing.Size(117, 17);
            this.lbl_LocalUserName.TabIndex = 1;
            this.lbl_LocalUserName.Text = "Local User Name";
            // 
            // lbl_WebUserName
            // 
            this.lbl_WebUserName.AutoSize = true;
            this.lbl_WebUserName.Location = new System.Drawing.Point(111, 97);
            this.lbl_WebUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_WebUserName.Name = "lbl_WebUserName";
            this.lbl_WebUserName.Size = new System.Drawing.Size(112, 17);
            this.lbl_WebUserName.TabIndex = 1;
            this.lbl_WebUserName.Text = "Web User Name";
            // 
            // lbl_LocalPassword
            // 
            this.lbl_LocalPassword.AutoSize = true;
            this.lbl_LocalPassword.Location = new System.Drawing.Point(544, 156);
            this.lbl_LocalPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_LocalPassword.Name = "lbl_LocalPassword";
            this.lbl_LocalPassword.Size = new System.Drawing.Size(107, 17);
            this.lbl_LocalPassword.TabIndex = 1;
            this.lbl_LocalPassword.Text = "Local Password";
            // 
            // lbl_WebPassword
            // 
            this.lbl_WebPassword.AutoSize = true;
            this.lbl_WebPassword.Location = new System.Drawing.Point(111, 156);
            this.lbl_WebPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_WebPassword.Name = "lbl_WebPassword";
            this.lbl_WebPassword.Size = new System.Drawing.Size(102, 17);
            this.lbl_WebPassword.TabIndex = 1;
            this.lbl_WebPassword.Text = "Web Password";
            // 
            // txtBox_LocalPort
            // 
            this.txtBox_LocalPort.Location = new System.Drawing.Point(540, 294);
            this.txtBox_LocalPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_LocalPort.Name = "txtBox_LocalPort";
            this.txtBox_LocalPort.Size = new System.Drawing.Size(224, 22);
            this.txtBox_LocalPort.TabIndex = 0;
            // 
            // txtBox_WebPort
            // 
            this.txtBox_WebPort.Location = new System.Drawing.Point(107, 294);
            this.txtBox_WebPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_WebPort.Name = "txtBox_WebPort";
            this.txtBox_WebPort.Size = new System.Drawing.Size(224, 22);
            this.txtBox_WebPort.TabIndex = 0;
            // 
            // lbl_LocalIP
            // 
            this.lbl_LocalIP.AutoSize = true;
            this.lbl_LocalIP.Location = new System.Drawing.Point(544, 38);
            this.lbl_LocalIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_LocalIP.Name = "lbl_LocalIP";
            this.lbl_LocalIP.Size = new System.Drawing.Size(114, 17);
            this.lbl_LocalIP.TabIndex = 1;
            this.lbl_LocalIP.Text = "Local IP Address";
            // 
            // lbl_WebIP
            // 
            this.lbl_WebIP.AutoSize = true;
            this.lbl_WebIP.Location = new System.Drawing.Point(111, 38);
            this.lbl_WebIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_WebIP.Name = "lbl_WebIP";
            this.lbl_WebIP.Size = new System.Drawing.Size(109, 17);
            this.lbl_WebIP.TabIndex = 1;
            this.lbl_WebIP.Text = "Web IP Address";
            // 
            // txtBox_LocalDatabase
            // 
            this.txtBox_LocalDatabase.Location = new System.Drawing.Point(540, 235);
            this.txtBox_LocalDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_LocalDatabase.Name = "txtBox_LocalDatabase";
            this.txtBox_LocalDatabase.Size = new System.Drawing.Size(224, 22);
            this.txtBox_LocalDatabase.TabIndex = 0;
            // 
            // txtBox_LocalPassword
            // 
            this.txtBox_LocalPassword.Location = new System.Drawing.Point(540, 176);
            this.txtBox_LocalPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_LocalPassword.Name = "txtBox_LocalPassword";
            this.txtBox_LocalPassword.Size = new System.Drawing.Size(224, 22);
            this.txtBox_LocalPassword.TabIndex = 0;
            // 
            // txtBox_WebDatabase
            // 
            this.txtBox_WebDatabase.Location = new System.Drawing.Point(107, 235);
            this.txtBox_WebDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_WebDatabase.Name = "txtBox_WebDatabase";
            this.txtBox_WebDatabase.Size = new System.Drawing.Size(224, 22);
            this.txtBox_WebDatabase.TabIndex = 0;
            // 
            // txtBox_LocalUserName
            // 
            this.txtBox_LocalUserName.Location = new System.Drawing.Point(540, 117);
            this.txtBox_LocalUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_LocalUserName.Name = "txtBox_LocalUserName";
            this.txtBox_LocalUserName.Size = new System.Drawing.Size(224, 22);
            this.txtBox_LocalUserName.TabIndex = 0;
            // 
            // txtBox_WebPassword
            // 
            this.txtBox_WebPassword.Location = new System.Drawing.Point(107, 176);
            this.txtBox_WebPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_WebPassword.Name = "txtBox_WebPassword";
            this.txtBox_WebPassword.Size = new System.Drawing.Size(224, 22);
            this.txtBox_WebPassword.TabIndex = 0;
            // 
            // txtBox_LocalIp
            // 
            this.txtBox_LocalIp.Location = new System.Drawing.Point(540, 58);
            this.txtBox_LocalIp.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_LocalIp.Name = "txtBox_LocalIp";
            this.txtBox_LocalIp.Size = new System.Drawing.Size(224, 22);
            this.txtBox_LocalIp.TabIndex = 0;
            // 
            // txtBox_WebUserName
            // 
            this.txtBox_WebUserName.Location = new System.Drawing.Point(107, 117);
            this.txtBox_WebUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_WebUserName.Name = "txtBox_WebUserName";
            this.txtBox_WebUserName.Size = new System.Drawing.Size(224, 22);
            this.txtBox_WebUserName.TabIndex = 0;
            // 
            // txtBox_WebIp
            // 
            this.txtBox_WebIp.Location = new System.Drawing.Point(107, 58);
            this.txtBox_WebIp.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_WebIp.Name = "txtBox_WebIp";
            this.txtBox_WebIp.Size = new System.Drawing.Size(224, 22);
            this.txtBox_WebIp.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 586);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tab_Punches.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Punches)).EndInit();
            this.tab_Employees.ResumeLayout(false);
            this.tab_Employees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Employees)).EndInit();
            this.tab_Store.ResumeLayout(false);
            this.tab_Store.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stores)).EndInit();
            this.tab_Setup.ResumeLayout(false);
            this.tab_Setup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Clock;
        private System.Windows.Forms.TabPage tab_Punches;
        private System.Windows.Forms.TabPage tab_Employees;
        private System.Windows.Forms.TabPage tab_Store;
        private System.Windows.Forms.TabPage tab_Setup;
        private System.Windows.Forms.Button but_UpdateSetup;
        private System.Windows.Forms.Label lbl_WebDatabase;
        private System.Windows.Forms.Label lbl_WebUserName;
        private System.Windows.Forms.Label lbl_WebPassword;
        private System.Windows.Forms.Label lbl_WebIP;
        private System.Windows.Forms.TextBox txtBox_WebDatabase;
        private System.Windows.Forms.TextBox txtBox_WebPassword;
        private System.Windows.Forms.TextBox txtBox_WebUserName;
        private System.Windows.Forms.TextBox txtBox_WebIp;
        private System.Windows.Forms.Label lbl_LocalPort;
        private System.Windows.Forms.Label lbl_WebPort;
        private System.Windows.Forms.Label lbl_LocalDatabase;
        private System.Windows.Forms.Label lbl_LocalUserName;
        private System.Windows.Forms.Label lbl_LocalPassword;
        private System.Windows.Forms.TextBox txtBox_LocalPort;
        private System.Windows.Forms.TextBox txtBox_WebPort;
        private System.Windows.Forms.Label lbl_LocalIP;
        private System.Windows.Forms.TextBox txtBox_LocalDatabase;
        private System.Windows.Forms.TextBox txtBox_LocalPassword;
        private System.Windows.Forms.TextBox txtBox_LocalUserName;
        private System.Windows.Forms.TextBox txtBox_LocalIp;
        private System.Windows.Forms.ComboBox cmbBox_ChooseDatabase;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.Label lbl_CityStZip;
        private System.Windows.Forms.Label lbl_StoreAddress;
        private System.Windows.Forms.Label lbl_StoreName;
        private System.Windows.Forms.Button but_UpdateStore;
        private System.Windows.Forms.DataGridView dgv_Punches;
        private System.Windows.Forms.DataGridView dgv_Employees;
        private System.Windows.Forms.Button but_TestDatabases;
        private System.Windows.Forms.DataGridView dgv_Stores;
        private System.Windows.Forms.CheckBox chkBox_ShowStoreInactive;
        private System.Windows.Forms.CheckBox chkBox_ShowEmpInactive;
        private System.Windows.Forms.CheckBox chkBox_ShowOtherStoreEmp;
        private System.Windows.Forms.ComboBox cmbBox_Pch_Str_Filter;
        private System.Windows.Forms.ComboBox cmbBox_Pch_Emp_Filter;
        private System.Windows.Forms.ComboBox cmbBox_Pch_Time_Filter;
        private System.Windows.Forms.Button btn_Add_Punch;
        private System.Windows.Forms.Button btn_Add_Emp;
        private System.Windows.Forms.Button btn_AddStore;
        private System.Windows.Forms.BindingSource ReportBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.Button btn_PunchPrint;
    }
}

