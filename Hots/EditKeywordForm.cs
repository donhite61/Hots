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
    public partial class EditKeywordForm : Form
    {
        protected UInt32 ordSysId;
        protected PickupKeyword puk;

        public EditKeywordForm(UInt32 _ordSysId, PickupKeyword _puk)
        {
            InitializeComponent();
            puk = _puk;
            ordSysId = _ordSysId;
        }

        private void KeywordForm_Load(object sender, EventArgs e)
        {
            if(puk != null)
                fillFields();

            fillStoreCmbBox();
        }

        private void fillStoreCmbBox()
        {
            var listkvPair = Hots.Locations.GetLocDropdownList();
            cmbbox_KeyWord_Stores.DataSource = listkvPair;
            cmbbox_KeyWord_Stores.DisplayMember = "Value";
            cmbbox_KeyWord_Stores.ValueMember = "Key";
        }

        private void fillFields()
        {
            txtbox_KeyWord_Id.Text = puk.Id.ToString();
            txtbox_KeyWord_OrdSys.Text = puk.OrdSysId.ToString();
            txtbox_KeyWord_Key.Text = puk.Keyword;
        }

        private void but_KeyWordSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtbox_KeyWord_Key.ToString()))
            {
                if (puk == null)
                {
                    puk = new PickupKeyword();
                    puk.OrdSysId = ordSysId;
                }
                puk.Keyword = txtbox_KeyWord_Key.Text;
                puk.LocId = Convert.ToUInt32(cmbbox_KeyWord_Stores.SelectedValue);
               
               
                if (PickupKeyword.UpdateKeywords(puk))
                    this.Close();
            }
        }

        private void but_KeyWordDel_Click(object sender, EventArgs e)
        {
            PickupKeyword.DelKeyWord(puk);
            Close();
        }

        private void cmbbox_KeyWord_Stores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
