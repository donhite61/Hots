using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hots
{
    public partial class EditStoreForm : Form
    {
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
            if (!newStore)
            {
                fillFields();
            } 
        }

        private void fillFields()
        {
            storeId = Convert.ToInt32(sRow.Cells["Store Id"].Value);
            txtBox_StoreNicName.Text = Convert.ToString(sRow.Cells["Store"].Value);
            txtBox_StoreName.Text = Convert.ToString(sRow.Cells["Full Name"].Value);
            txtBox_StoreAddress.Text = Convert.ToString(sRow.Cells["Address"].Value);
            txtBox_StoreCity.Text = Convert.ToString(sRow.Cells["City"].Value);
            txtBox_StoreState.Text = Convert.ToString(sRow.Cells["State"].Value);
            txtBox_StoreZip.Text = Convert.ToString(sRow.Cells["Zip"].Value);
            txtBox_StorePhone.Text = Convert.ToString(sRow.Cells["Phone"].Value);
            ChkBox_StoreInactive.Checked = Convert.ToBoolean(sRow.Cells["Inactive"].Value);
            txtBox_ShipCode.Text = Convert.ToString(sRow.Cells["Ship Code"].Value);
        }

        private void but_StoreAdd_Click(object sender, EventArgs e)
        {
            processStoreAdd();
        }

        private void but_StoreUpdate_Click(object sender, EventArgs e)
        {
            processStoreUpdate();
        }

        private void processStoreUpdate()
        {
            var sNicName = txtBox_StoreNicName.Text;
            var sName = txtBox_StoreName.Text;
            var sAdd = txtBox_StoreAddress.Text;
            var sCity = txtBox_StoreCity.Text;
            var sSt = txtBox_StoreState.Text;
            var sZip = txtBox_StoreZip.Text;
            var sPhone = txtBox_StorePhone.Text;
            var sIa = ChkBox_StoreInactive.Checked;
            var sSc = txtBox_ShipCode.Text;

            if (PickupLocation.UpdateStore(storeId, sNicName, sName, sAdd, sCity, sSt, sZip, sPhone, sIa, sSc))
            {
                Close();
            }
            else
            {
                MessageBox.Show("Failed to update store");
            }
        }

        private void but_StoreDelete_Click(object sender, EventArgs e)
        {
            processStoreDelete();
        }

        private void processStoreDelete()
        {
            if (PickupLocation.DeleteStore (storeId))
            {
                Close();
            }
            else
            {
                MessageBox.Show("Failed to delete store");
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
                processStoreUpdate();
            }
        }

        private void processStoreAdd()
        {
            var sNicName = txtBox_StoreNicName.Text;
            if (PickupLocation.DoesStoreExist(sNicName))
            {
                MessageBox.Show("Store Nicname already exists, choose another name");
                return;
            }
            var sName = txtBox_StoreName.Text;
            var sAdd = txtBox_StoreAddress.Text;
            var sCity = txtBox_StoreCity.Text;
            var sSt = txtBox_StoreState.Text;
            var sZip = txtBox_StoreZip.Text;
            var sPhone = txtBox_StorePhone.Text;
            var sIa = ChkBox_StoreInactive.Checked;
            var sSc = txtBox_ShipCode.Text;

            if (PickupLocation.AddStore(sNicName, sName, sAdd, sCity, sSt, sZip, sPhone, sIa, sSc))
            {
                Close();
            }
            else
            {
                MessageBox.Show("Failed to add store");
            }
        }

    }
}
