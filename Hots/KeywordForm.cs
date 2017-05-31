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
    public partial class KeywordForm : Form
    {
        protected PickupKeywords keyWord;

        public KeywordForm(DataGridViewRow _selectedRow)
        {
            InitializeComponent();
            keyWord.Id = Convert.ToUInt32(_selectedRow.Cells["Id"].Value);

            Enum.TryParse(Convert.ToString(_selectedRow.Cells["Name"]), out Set.OrdSysName _ordSysName);
            keyWord.OrdSysName = _ordSysName;
        }

        private void KeywordForm_Load(object sender, EventArgs e)
        {
            //txtbox_KeyWord_OrdSys.Text = ordSysName;
            //fillStoreCmbBox();
            //if (sRow == null)
            //{
            //    but_KeyWordDel.Visible = false;
            //}
            //else
            //{
            //    fillFields();
            //}
        }

        private void fillStoreCmbBox()
        {
            var strDTable = PickupLocation.GetStoreDataTable();
            cmbbox_KeyWord_Stores.DataSource = strDTable;
            cmbbox_KeyWord_Stores.DisplayMember = "Store";
            cmbbox_KeyWord_Stores.ValueMember = "Store";
        }

        private void fillFields()
        {
            //txtbox_KeyWord_OrdSys.Text = ordSysName;
            //txtbox_KeyWord_Key.Text = Convert.ToString(sRow.Cells["Keyword"].Value);
        }

        private void but_KeyWordSave_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrWhiteSpace(txtbox_KeyWord_Key.ToString()))
            //{
            //    PickupKeywords keyWord = new PickupKeywords();
            //    Enum.TryParse(ordSysName, out Set.OrdSysName _ordSysName);
            //    keyWord.OrdSysName = _ordSysName;
            //    keyWord.PickupLocation = cmbbox_KeyWord_Stores.SelectedValue.ToString();
            //    keyWord.Keyword = txtbox_KeyWord_Key.Text;
            //    if (PickupKeywords.SaveKeyWord(keyWord))
            //    {
            //        this.Close();
            //    }
            //}
        }

        private void but_KeyWordDel_Click(object sender, EventArgs e)
        {
            //PickupKeywords keyWord = new PickupKeywords();
            //keyWord.Id = txtbox_KeyWord_Key;
            //keyWord.DelKeyWord(keyWord.Id);
        }

        private void cmbbox_KeyWord_Stores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
