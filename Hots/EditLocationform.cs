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
    public partial class EditLocationForm : Form
    {
        protected Location loc;

        public EditLocationForm(Location _loc)
        {
            InitializeComponent();
            loc = _loc;
        }

        private void EditStoreForm_Load(object sender, EventArgs e)
        {
            if (loc != null)
            {
                fillFields();
            }
            else
            {
                but_StoreDelete.Visible = false;
            }

        }

        private void fillFields()
        {
            txtBox_StoreNicName.Text = loc.NicName;
            txtBox_StoreName.Text = loc.Name;
            txtBox_StoreAddress.Text = loc.Address;
            txtBox_StoreCity.Text = loc.City;
            txtBox_StoreState.Text = loc.State;
            txtBox_StoreZip.Text = loc.Zip;
            txtBox_StorePhone.Text = loc.Phone;
            ChkBox_StoreInactive.Checked = loc.Inactive;
            txtBox_ShipCode.Text = loc.ShipCode;
        }

        private void but_StoreUpdate_Click(object sender, EventArgs e)
        {
            processStoreUpdate();
        }

        private void processStoreUpdate()
        {
            if (loc == null)
                loc = new Location();

            loc.NicName = txtBox_StoreNicName.Text;
            loc.Name = txtBox_StoreName.Text;
            loc.Address = txtBox_StoreAddress.Text;
            loc.City = txtBox_StoreCity.Text;
            loc.State = txtBox_StoreState.Text;
            loc.Zip = txtBox_StoreZip.Text;
            loc.Phone = txtBox_StorePhone.Text;
            loc.Inactive = ChkBox_StoreInactive.Checked;
            loc.ShipCode = txtBox_ShipCode.Text;

            if (Hots.Location.SaveLocation(loc))
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
            if (Hots.Location.DeleteLocation(loc))
            {
                Set.LocList.Remove(loc);
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

    }
}
