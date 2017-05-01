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
    public partial class EditPunchForm : Form
    {
        public Database LdataW = new Database(Clock.DataLocation);
        public DataGridViewRow sRow;
        public bool newPunch;
        protected int orgPunchId;
        protected int orgStoreId;
        protected int orgEmpId;
        protected DateTime orgTimeIn;
        protected DateTime? orgTimeOut;
        protected DateTime? orgTimeInOrg;
        protected DateTime? orgTimeOutOrg;
        protected string orgNote;

        public EditPunchForm(DataGridViewRow _selectedRow)
        {
            InitializeComponent();

            if (_selectedRow == null)
            {
                orgStoreId = Clock.StoreId;
                newPunch = true;
                but_Delete.Visible = false;
                but_Update.Visible = false;
                dTPickerOut.Enabled = false;
            }
            else
            {
                this.sRow = _selectedRow;
                orgPunchId = Convert.ToInt32(sRow.Cells["Id"].Value);
                orgStoreId = Convert.ToInt32(sRow.Cells["Store Id"].Value);
                orgEmpId = Convert.ToInt32(sRow.Cells["Emp Id"].Value);
                orgTimeIn = Convert.ToDateTime(sRow.Cells["Time In"].Value);
                orgTimeOut = sRow.Cells["Time Out"].Value as DateTime?;
                if (sRow.Cells["Time Out"].Value != System.DBNull.Value)
                {
                   orgTimeOut = Convert.ToDateTime(sRow.Cells["Time Out"].Value);
                   chkBox_EnableOutPicker.Enabled = false;
                }
                else
                {
                    orgTimeOut = null;
                    dTPickerOut.Enabled = false;
                }
                if (sRow.Cells["Org TimeIn"].Value != System.DBNull.Value)
                    orgTimeInOrg = Convert.ToDateTime(sRow.Cells["Org TimeIn"].Value);

                if (sRow.Cells["Org TimeOut"].Value != System.DBNull.Value)
                    orgTimeOutOrg = Convert.ToDateTime(sRow.Cells["Org TimeOut"].Value);

                orgNote = Convert.ToString(sRow.Cells["Note"].Value);
                but_Add.Visible = false;
            }
        }

        private void EditPunchForm_Load(object sender, EventArgs e)
        {
            fillStoreCmbBox();
            fillEmpCmbBox();
            if (!newPunch)
                fillFields();
        }

        private void fillStoreCmbBox()
        {
            var strCmbList = LdataW.GetList("stores"); // get all active stores
            cmbBox_Stores.DataSource = new BindingSource(strCmbList, null);
            cmbBox_Stores.DisplayMember = "Value";
            cmbBox_Stores.ValueMember = "Key";
            cmbBox_Stores.SelectedValue = orgStoreId;
        }

        private void fillEmpCmbBox()
        {
            var store_Id = ((KeyValuePair<int, string>)cmbBox_Stores.SelectedItem).Key;
            var empCmbList = LdataW.GetList("employees", store_Id); // get selected stores active emp
            if (newPunch)
                empCmbList.Insert(0, new KeyValuePair<int, string>(-1, "Choose Emp"));

            cmbBox_Employees.DataSource = new BindingSource(empCmbList, null);
            cmbBox_Employees.DisplayMember = "Value";
            cmbBox_Employees.ValueMember = "Key";
        }

        private void fillFields()
        {
            cmbBox_Stores.SelectedValue = orgStoreId;
            cmbBox_Employees.SelectedValue = orgEmpId;
            dTPickerIn.Value = orgTimeIn;
            if (orgTimeInOrg != null)
            {
                var oTiO = Convert.ToDateTime(orgTimeInOrg);
                lbl_TimeInOrg.Text = oTiO.ToString("ddd   MM/dd/yyyy   h:mm tt");
            }
            if (orgTimeOutOrg != null)
            {
                var oToO = Convert.ToDateTime(orgTimeOutOrg);
                lbl_TimeOutOrg.Text = oToO.ToString("ddd   MM/dd/yyyy   h:mm tt");
            }
            txt_Note.Text = orgNote;
        }

        private void cmbBox_Stores_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fillEmpCmbBox();
        }

        private void but_PunchAdd_Click(object sender, EventArgs e)
        {
            processPunchUpdateForm("INSERT");
        }

        private void but_PunchUpdate_Click(object sender, EventArgs e)
        {
            processPunchUpdateForm("UPDATE");
        }

        private void but_PunchDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                "Are you sure you want \r\n to delete this Punch?", "Delete Punch?",
                 MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                processPunchUpdateForm("DELETE");
            }
        }

        private void processPunchUpdateForm(string cmd = "DEFAULT")
        {
            if (cmd == "DEFAULT")
                cmd = but_Add.Visible == true ? "INSERT" : "UPDATE";

            //todo change emp and store form to "ENTERKEY" format

            var pEmpId = cmbBox_Employees.SelectedItem == null ? orgEmpId :
            ((KeyValuePair<int, string>)cmbBox_Employees.SelectedItem).Key;
            if (pEmpId == -1)
            {
                MessageBox.Show("Please choose an employee");
                return;
            }

            var pStoreId = cmbBox_Stores.SelectedItem == null ? orgStoreId :
                ((KeyValuePair<int, string>)cmbBox_Stores.SelectedItem).Key;
            var pTimeIn = dTPickerIn.Value;
            DateTime? pTimeOut;
            if (dTPickerOut.Enabled)
            {
                pTimeOut = Convert.ToDateTime(dTPickerOut.Value);
            }
            else
            {
                pTimeOut = null;
            }

            var pNote = txt_Note.Text;

            if (LdataW.UpdatePunch(cmd, orgPunchId, pTimeIn, pTimeOut, pNote, pEmpId, pStoreId))
            {
                Close();
            }
            else
            {
                MessageBox.Show("Failed to update Punch");
            }
        }

        private void chkBox_EnableOutPicker_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBox_EnableOutPicker.Checked)
            {
                dTPickerOut.Enabled = true;
                dTPickerOut.Value = dTPickerIn.Value;
            }
            else
            {
                dTPickerOut.Enabled = false;
            }
        }

        private void dTPickerIn_ValueChanged(object sender, EventArgs e)
        {
            if (newPunch)
                dTPickerOut.Value = dTPickerIn.Value;
        }

        private void EditPunchForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                processPunchUpdateForm();
            }
        }
    }
}
