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
    public partial class EditStoreForm : Form
    {
        protected Database LdataW = new Database(Clock.DataLocation);
        protected DataGridViewRow sRow;
        protected bool newStore;
        protected int storeId;

        public EditStoreForm(DataGridViewRow _selectedRow)
        {
            InitializeComponent();

            if (_selectedRow == null)
            {
                newStore = true;
                but_StoreDelete.Visible = false;
                but_StoreUpdate.Visible = false;
            }
            else
            {
                this.sRow = _selectedRow;
                but_StoreAdd.Visible = false;
            }
        }

        private void EditStoreForm_Load(object sender, EventArgs e)
        {
            if(!newStore)
                fillFields();
        }

        private void fillFields()
        {
            storeId = Convert.ToInt32(sRow.Cells["Id"].Value);
            txtBox_StoreNicName.Text = Convert.ToString(sRow.Cells["NicName"].Value);
            txtBox_StoreName.Text = Convert.ToString(sRow.Cells["Name"].Value);
            txtBox_StoreAddress.Text = Convert.ToString(sRow.Cells["Address"].Value);
            txtBox_StoreCity.Text = Convert.ToString(sRow.Cells["City"].Value);
            txtBox_StoreState.Text = Convert.ToString(sRow.Cells["State"].Value);
            txtBox_StoreZip.Text = Convert.ToString(sRow.Cells["Zip"].Value);
            txtBox_StorePhone.Text = Convert.ToString(sRow.Cells["Phone"].Value);
            if (Convert.ToInt32(sRow.Cells["Inactive"].Value) == 1)
                ChkBox_StoreInactive.Checked = true;
        }

        private void but_StoreAdd_Click(object sender, EventArgs e)
        {
            processStoreUpdateForm("INSERT");
        }

        private void but_StoreUpdate_Click(object sender, EventArgs e)
        {
            processStoreUpdateForm("REPLACE");
        }

        private void but_StoreDelete_Click(object sender, EventArgs e)
        {
            if (LdataW.CheckForDependants("stores", storeId))
            {
                MessageBox.Show("You cannot delete this store because it has \r\n" +
                    "been used by users, employees or punch records. \r\n"+
                    "Mark inactive instead.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Are you sure you want \r\n to delete this store?", "Delete Store?",
                     MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    processStoreUpdateForm("DELETE");
                }
            }
        }

        private void processStoreUpdateForm(string cmd = "DEFAULT")
        {
            if (cmd == "DEFAULT")
                cmd = but_StoreAdd.Visible == true ? "INSERT" : "UPDATE";

            var sNicName = txtBox_StoreNicName.Text;
            var existingNicNameId = LdataW.GetIdFromNicName("stores", sNicName); // -1 if nicname not found
            if (existingNicNameId != -1 & existingNicNameId != storeId)// if nicname found and not this emp
            {
                MessageBox.Show("NicName is already taken, please choose another");
                return;
            }

            var sName = txtBox_StoreName.Text;
            var sAdd = txtBox_StoreAddress.Text;
            var sCity = txtBox_StoreCity.Text;
            var sSt = txtBox_StoreState.Text;
            var sZip = txtBox_StoreZip.Text;
            var sPhone = txtBox_StorePhone.Text;
            var sIa = ChkBox_StoreInactive.Checked == true ? 1 : 0;

            if (LdataW.UpdateStore(cmd, storeId, sNicName, sName, sAdd, sCity, sSt, sZip, sPhone, sIa))
            {
                Close();
            }
            else
            {
                MessageBox.Show("Failed to update store");
            }
        }

        private void EditStoreForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                processStoreUpdateForm();
            }
        }
    }
}
