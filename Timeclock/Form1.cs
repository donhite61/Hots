using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timeclock
{
    public partial class Form1 : Form
    {
        public Database LdataR = new Database(Clock.DataLocation);
        public EditStoreForm editStoreForm;
        public EditEmpForm editEmpForm;
        public EditPunchForm editPunchForm;
        public DataTable storeTable;
        public DataTable empTable;
        public DataTable punchTable;
        public ClkScreen buttonMaker;
        public Report report;

        public Form1()
        {
            InitializeComponent();
            buttonMaker = new ClkScreen(tab_Clock);
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            FillStores(0);
            Clock.GetMacAddress();
            Clock.StoreId = LdataR.GetStoreId();
            SetStorSetOrUnSet();
            tabControl1.SelectedIndex = 3;
        }

        private void SetStorSetOrUnSet()
        {
            DataRow choosenStoreRow = null;
            if (Clock.StoreId != -1)
                choosenStoreRow = storeTable.Rows.Find(Clock.StoreId); //Is user store valid
            if (choosenStoreRow == null)
            {
                SetForNoStoreChosen();
            }
            else
            {
                if (Convert.ToInt32(choosenStoreRow["Inactive"]) == 1)
                {
                    SetForNoStoreChosen();
                }
                else
                {
                    SetStoreInfo(choosenStoreRow);
                    var index = storeTable.Rows.IndexOf(choosenStoreRow);
                }
            }
        }
        private void SetForNoStoreChosen()
        {
            {
                lbl_StoreName.Text = "Please choose a store";
                lbl_StoreAddress.Text = "";
                lbl_CityStZip.Text = "";
                lbl_Phone.Text = "";

                chkBox_ShowEmpInactive.Enabled = false;
                chkBox_ShowOtherStoreEmp.Enabled = false;
                btn_Add_Emp.Enabled = false;

                cmbBox_Pch_Str_Filter.Enabled = false;
                cmbBox_Pch_Time_Filter.Enabled = false;
                cmbBox_Pch_Emp_Filter.Enabled = false;
                btn_Add_Punch.Enabled = false;

                tabControl1.SelectedIndex = 3;
            }
        }
        private void FillStores(int inactive)
        {
            storeTable = LdataR.GetStores(-1, inactive);
            dgv_Stores.DataSource = storeTable;
            dgv_Stores.Columns["Id"].Visible = false;
        }
        private void SetStoreInfo(DataRow choosenStoreRow)
        {
            lbl_StoreName.Text = Convert.ToString(choosenStoreRow["Name"]);
            lbl_StoreAddress.Text = Convert.ToString(choosenStoreRow["Address"]);
            var city = Convert.ToString(choosenStoreRow["City"]);
            var State = Convert.ToString(choosenStoreRow["State"]);
            var zip = Convert.ToString(choosenStoreRow["Zip"]);
            lbl_CityStZip.Text = city + ", " + State + "  " + zip;
            lbl_Phone.Text = Convert.ToString(choosenStoreRow["Phone"]);

            chkBox_ShowEmpInactive.Enabled = true;
            chkBox_ShowOtherStoreEmp.Enabled = true;
            btn_Add_Emp.Enabled = true;

            cmbBox_Pch_Str_Filter.Enabled = true;
            cmbBox_Pch_Time_Filter.Enabled = true;
            cmbBox_Pch_Emp_Filter.Enabled = true;
            btn_Add_Punch.Enabled = true;
        }
        private void chkBox_ShowStoreInactive_CheckedChanged(object sender, EventArgs e)
        {
            int inactive = chkBox_ShowStoreInactive.Checked ? 1 : 0;
            FillStores(inactive);
        }
        private void but_UpdateStore_Click(object sender, EventArgs e)
        {
            if (dgv_Stores.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgv_Stores.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgv_Stores.Rows[selectedrowindex];
                if (Convert.ToInt32(selectedRow.Cells["Inactive"].Value) == 1)
                {
                    MessageBox.Show("Cannot use an Inactive store");
                }
                else
                {
                    var storeId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                    if (storeId == Clock.StoreId)
                    {
                        MessageBox.Show("This store is already the selected store");
                    }
                    else
                    {
                        if (LdataR.UpdateUser(Clock.MacAddress, storeId))
                        {
                            Clock.StoreId = storeId;
                            SetStorSetOrUnSet();
                        }
                        else
                        {
                            MessageBox.Show("Error: User information could not be saved");
                        }
                    }

                }
            }
        }
        private void StoreCellDoubleClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Stores.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgv_Stores.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgv_Stores.Rows[selectedrowindex];
                editStoreForm = new EditStoreForm(selectedRow);
                editStoreForm.FormClosed += editStoreForm_FormClosed;

                if (Convert.ToString(selectedRow.Cells["Name"].Value) == " Double click to add store")
                {
                    editStoreForm.but_StoreDelete.Visible = false;
                    editStoreForm.but_StoreUpdate.Visible = false;
                }
                else
                {
                    editStoreForm.but_StoreAdd.Visible = false;
                }

                editStoreForm.Show();
            }
        }
        private void editStoreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            chkBox_ShowStoreInactive_CheckedChanged(tabControl1, new EventArgs());
            SetStorSetOrUnSet();

        }
        private void but_AddStore_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = null;
            editStoreForm = new EditStoreForm(selectedRow);
            editStoreForm.FormClosed += editStoreForm_FormClosed;
            editStoreForm.Show();
        }

        private void FillEmployees(int storeId, int inactive)
        {
            var empTable = LdataR.GetJoinEmployees(storeId, inactive);
            dgv_Employees.DataSource = empTable;
            dgv_Employees.Columns["StoreId"].Visible = false;
            dgv_Employees.Columns["Id"].Visible = false;
        }
        private void chkBox_EmployeesChanged(object sender, EventArgs e)
        {
            if (chkBox_ShowOtherStoreEmp.Checked)
            {
                if (chkBox_ShowEmpInactive.Checked)
                {
                    FillEmployees(-1, 1);
                }
                else
                {
                    FillEmployees(-1, 0);
                }
            }
            else
            {
                if (chkBox_ShowEmpInactive.Checked)
                {
                    FillEmployees(Clock.StoreId, 1);
                }
                else
                {
                    FillEmployees(Clock.StoreId, 0);
                }
            }
        }
        private void dgv_Employees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Employees.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgv_Employees.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgv_Employees.Rows[selectedrowindex];
                editEmpForm = new EditEmpForm(selectedRow);
                editEmpForm.FormClosed += editEmpForm_FormClosed;
                editEmpForm.Show();
            }
        }
        private void editEmpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TabControl1_SelectedIndexChanged(tabControl1, new EventArgs());
        }
        private void btn_Add_Emp_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = null;
            editEmpForm = new EditEmpForm(selectedRow);
            editEmpForm.FormClosed += editEmpForm_FormClosed;
            editEmpForm.Show();
        }

        private void FillPunches(int empId, int storeId, int numWeeks)
        {
            var dayOfWeek = Convert.ToInt32(DateTime.Now.DayOfWeek);
            var sDate = DateTime.Now.Date.AddDays(Convert.ToDouble(-(numWeeks * 7 + Convert.ToInt32(DateTime.Now.DayOfWeek))));
            var eDate = numWeeks == 0 ? DateTime.Now.Date.AddDays(1) : DateTime.Now.Date.AddDays(-dayOfWeek);
            var punchTable = LdataR.GetJoinPunches(empId, storeId, sDate, eDate);

            dgv_Punches.DataSource = punchTable;
            dgv_Punches.Columns["Id"].Visible = false;
            dgv_Punches.Columns["Emp Id"].Visible = false;
            dgv_Punches.Columns["Time In"].DefaultCellStyle.Format = "M/dd  ddd  h:mm tt";
            dgv_Punches.Columns["Time Out"].DefaultCellStyle.Format = "M/dd  ddd  h:mm tt";
            dgv_Punches.Columns["Store Id"].Visible = false;
            dgv_Punches.Columns["Org TimeIn"].Visible = false;
            dgv_Punches.Columns["Org TimeOut"].Visible = false;
            dgv_Punches.Columns["Hrs Worked"].ReadOnly = true;
            dgv_Punches.Columns["Hrs Worked"].DisplayIndex = 4;


        }
        private void fillPchTImeFilterCmbBox(int weeks)
        {
            cmbBox_Pch_Time_Filter.DisplayMember = "Text";
            cmbBox_Pch_Time_Filter.ValueMember = "Value";
            var PtFilterCmbItems = new[]
            {
            new { Text = "This Week", Value = "0" },
            new { Text = "2 Prev Weeks", Value = "2" },
            new { Text = "4 Prev Weeks", Value = "4" },
            new { Text = "52 Prev Weeks", Value = "52" },
            new { Text = "100 Years", Value = "5200" }
        };
            cmbBox_Pch_Time_Filter.DataSource = PtFilterCmbItems;
            cmbBox_Pch_Time_Filter.SelectedValue = weeks.ToString();
        }
        private void newfillPchEmpCmbBox(int storeId)
        {
            var empCmbList = LdataR.GetList("employees", storeId); // get this stores active emp
            empCmbList.Insert(0, new KeyValuePair<int, string>(-1, "All Employees"));
            cmbBox_Pch_Emp_Filter.DataSource = new BindingSource(empCmbList, null);
            cmbBox_Pch_Emp_Filter.SelectedItem = 0;
            cmbBox_Pch_Emp_Filter.DisplayMember = "Value";
            cmbBox_Pch_Emp_Filter.ValueMember = "Key";
        }
        private void newfillPchStoreCmbBox(int storeId)
        {
            var strCmbList = LdataR.GetList("stores"); // get all activve stores
            strCmbList.Insert(0, new KeyValuePair<int, string>(-1, "ALL Stores"));
            cmbBox_Pch_Str_Filter.DataSource = new BindingSource(strCmbList, null);
            cmbBox_Pch_Str_Filter.DisplayMember = "Value";
            cmbBox_Pch_Str_Filter.ValueMember = "Key";
            cmbBox_Pch_Str_Filter.SelectedValue = storeId;
        }
        private void dgv_Punches_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Punches.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgv_Punches.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgv_Punches.Rows[selectedrowindex];
                editPunchForm = new EditPunchForm(selectedRow);
                editPunchForm.FormClosed += editPunchForm_FormClosed;
                editPunchForm.Show();
            }
        }
        private void editPunchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cmbBox_Pch_Filter_Changed(tabControl1, new EventArgs());
        }
        private void cmbBox_Pch_Filter_Changed(object sender, EventArgs e)
        {
            var flt_StrId = ((KeyValuePair<int, string>)cmbBox_Pch_Str_Filter.SelectedItem).Key;
            var flt_NumWeeks = Convert.ToInt32(cmbBox_Pch_Time_Filter.SelectedValue);
            var flt_EmpId = ((KeyValuePair<int, string>)cmbBox_Pch_Emp_Filter.SelectedItem).Key;
            FillPunches(flt_EmpId, flt_StrId, flt_NumWeeks);
        }
        private void cmbBox_Pch_Str_Filter_Changed(object sender, EventArgs e)
        {
            var flt_StrId = ((KeyValuePair<int, string>)cmbBox_Pch_Str_Filter.SelectedItem).Key;
            newfillPchEmpCmbBox(flt_StrId);
            cmbBox_Pch_Emp_Filter.SelectedItem = 0;
            cmbBox_Pch_Filter_Changed(new object(), new EventArgs());
        }
        private void btn_Add_Punch_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = null;
            editPunchForm = new EditPunchForm(selectedRow);
            editPunchForm.FormClosed += editPunchForm_FormClosed;
            editPunchForm.Show();
        }
        private void btn_PunchPrint_Click(object sender, EventArgs e)
        {

        }

        private void TabControl1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (Clock.StoreId != -1)
            {
                switch (tabControl1.SelectedIndex)
                {
                    case 0:// clock tab
                        buttonMaker.SetupClockScreen();
                        break;

                    case 1:// punches tab
                        fillPchTImeFilterCmbBox(0);
                        newfillPchStoreCmbBox(Clock.StoreId);
                        cmbBox_Pch_Str_Filter_Changed(tabControl1, new EventArgs());
                        break;

                    case 2:// employee tab
                        chkBox_EmployeesChanged(tabControl1, new EventArgs());
                        break;

                    case 3://store tab
                        chkBox_ShowStoreInactive_CheckedChanged(tabControl1, new EventArgs());
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
