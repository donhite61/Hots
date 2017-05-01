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
    public partial class EditEmpForm : Form
    {
        public Database LdataW = new Database(Clock.DataLocation);
        public DataGridViewRow sRow;
        public bool newEmp;
        protected int orgEmpId;
        protected string orgEmpNicName;
        protected int orgEmpStoreId;
        protected string orgEmpFname;
        protected string orgEmpLname;
        protected string orgEmpPhone;
        protected string orgEmpEmail;
        protected bool inactiveCheckedChanged;

        public EditEmpForm(DataGridViewRow _selectedRow)
        {
            InitializeComponent();

            if (_selectedRow == null)
            {
                newEmp = true;
                but_EmpDelete.Visible = false;
                but_EmpUpdate.Visible = false;
            }
            else
            {
                this.sRow = _selectedRow;
                orgEmpId = Convert.ToInt32(sRow.Cells["Id"].Value);
                orgEmpNicName = Convert.ToString(sRow.Cells["NicName"].Value);
                orgEmpStoreId = Convert.ToInt32(sRow.Cells["StoreId"].Value);
                orgEmpFname = Convert.ToString(sRow.Cells["First Name"].Value);
                orgEmpLname = Convert.ToString(sRow.Cells["Last Name"].Value);
                orgEmpPhone = Convert.ToString(sRow.Cells["Phone"].Value);
                orgEmpEmail = Convert.ToString(sRow.Cells["Email"].Value);
                but_EmpAdd.Visible = false;
            }
        }

        private void EditEmpForm_Load(object sender, EventArgs e)
        {
            fillStoreCmbBox();
            if (!newEmp)
                fillFields();
        }

        private void fillStoreCmbBox()
        {
            var strCmbList = LdataW.GetList("stores"); // get all active stores
            cmbBox_EmpStoreName.DataSource = new BindingSource(strCmbList, null);
            cmbBox_EmpStoreName.DisplayMember = "Value";
            cmbBox_EmpStoreName.ValueMember = "Key";
            cmbBox_EmpStoreName.SelectedValue = Clock.StoreId;
        }

        private void fillFields()
        {
            txtBox_EmpNicName.Text = orgEmpNicName;
            cmbBox_EmpStoreName.SelectedValue = orgEmpStoreId;
            txtBox_EmpFname.Text = orgEmpFname;
            txtBox_EmpLname.Text = orgEmpLname;
            txtBox_EmpPhone.Text = orgEmpPhone;
            txtBox_EmpEmail.Text = orgEmpEmail;
            if (Convert.ToInt32(sRow.Cells["Inactive"].Value) == 1)
                    ChkBox_EmpInactive.Checked = true;
        }

        private void but_EmpAdd_Click(object sender, EventArgs e)
        {
            processEmpUpdateForm("INSERT");
        }

        private void but_EmpUpdate_Click(object sender, EventArgs e)
        {
            processEmpUpdateForm("REPLACE");
        }

        private void but_EmpDelete_Click(object sender, EventArgs e)
        {
            if (LdataW.CheckForDependants("employees", orgEmpId))
            {
                MessageBox.Show("You cannot delete this Employee \r\n" +
                                "because it has punch records. \r\n" +
                                "Mark inactive instead.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Are you sure you want \r\n to delete this Emp?", "Delete Employee?",
                     MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    processEmpUpdateForm("DELETE");
                }
            }
        }

        private void processEmpUpdateForm(string cmd = "DEFAULT")
        {
            if (cmd == "DEFAULT")
                cmd = but_EmpAdd.Visible == true ? "INSERT" : "UPDATE";

            var eNicName = txtBox_EmpNicName.Text;
            var existingNicNameId = LdataW.GetIdFromNicName("employees", eNicName); // -1 if nicname not found
            if(existingNicNameId != -1 & existingNicNameId != orgEmpId)// if nicname found and not this emp
            {
                MessageBox.Show("NicName is already taken, please choose another");
                return;
            }
            var eStoreId = cmbBox_EmpStoreName.SelectedItem == null ? orgEmpStoreId :
                ((KeyValuePair<int, string>)cmbBox_EmpStoreName.SelectedItem).Key;

            var efName = txtBox_EmpFname.Text;
            var elName = txtBox_EmpLname.Text;
            var ePhone = txtBox_EmpPhone.Text;
            var eEmail = txtBox_EmpEmail.Text;
            var eIa = ChkBox_EmpInactive.Checked == true ? 1 : 0;

            if (LdataW.UpdateEmployee(cmd, orgEmpId, eNicName, eStoreId, efName, elName, ePhone, eEmail, eIa))
            {
                if (inactiveCheckedChanged == true)// if emp inactive changed, change all their punches too
                {
                    var inactive = ChkBox_EmpInactive.Checked ? 1 : 0;
                        LdataW.ChangeEmpPunchesActiveState(orgEmpId, inactive);
                }
                Close();
            }
            else
            {
                MessageBox.Show("Failed to update Emp");
            }
        }

        private void ChkBox_EmpInactive_CheckedChanged(object sender, EventArgs e)
        {
            inactiveCheckedChanged = true;
        }

        private void EditEmpForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                processEmpUpdateForm();
            }
        }
    }
}
