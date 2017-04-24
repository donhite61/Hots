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
    public partial class frm_UpdOrdSys : Form
    {
        public frm_UpdOrdSys(DataGridViewRow _selectedRow)
        {
            InitializeComponent();
            chkBox_Active.Checked = Convert.ToBoolean(_selectedRow.Cells[0].Value);
            txtBox_OrdSysName.Text = Convert.ToString(_selectedRow.Cells[1].Value);
            txtBox_WatchedFolder.Text = Convert.ToString(_selectedRow.Cells[2].Value);
            txtBox_WchdExt.Text = Convert.ToString(_selectedRow.Cells[3].Value);
            txtBox_ReadFolder.Text = Convert.ToString(_selectedRow.Cells[4].Value);
            txtBox_OutputFolder.Text = Convert.ToString(_selectedRow.Cells[5].Value);
            txtBox_ProdSubFldr.Text = Convert.ToString(_selectedRow.Cells[6].Value);
            txtBox_WaitForFile.Text = Convert.ToString(_selectedRow.Cells[7].Value);
            chkBox_WaitFileIsFldr.Checked = Convert.ToBoolean(_selectedRow.Cells[8].Value);
        }

        private void frm_UpdOrdSys_Load(object sender, EventArgs e)
        {

        }

        private void but_Update_Click(object sender, EventArgs e)
        {
            OrderSystem ordSysUpdate = new OrderSystem();
            ordSysUpdate.Active = chkBox_Active.Checked;
            ordSysUpdate.Name = txtBox_OrdSysName.Text;
            ordSysUpdate.WatchFldr = txtBox_WatchedFolder.Text;
            ordSysUpdate.Ext = txtBox_WchdExt.Text;
            ordSysUpdate.ReadFld = txtBox_ReadFolder.Text;
            ordSysUpdate.OutFldr = txtBox_OutputFolder.Text;
            ordSysUpdate.PrdSubFldr = txtBox_ProdSubFldr.Text;
            ordSysUpdate.WaitFile = txtBox_WaitForFile.Text;
            ordSysUpdate.WaitIsFldr = chkBox_WaitFileIsFldr.Checked;
            OrderSysList.UpdateOrdSysInOrdSysList(ordSysUpdate);
            Close();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
