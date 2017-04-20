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
        }

        private void but_Add_Click(object sender, EventArgs e)
        {
            OrderSystem ordSysNew = new OrderSystem();
            ordSysNew.Active = chkBox_Active.Checked;
            ordSysNew.Name = txtBox_OrdSysName.Text;
            ordSysNew.WatchFldr = txtBox_WatchedFolder.Text;
            ordSysNew.Ext = txtBox_WchdExt.Text;
            ordSysNew.ReadFld = txtBox_ReadFolder.Text;
            ordSysNew.OutFldr = txtBox_OutputFolder.Text;
            ordSysNew.PrdSubFldr= txtBox_ProdSubFldr.Text;
            ordSysNew.WaitFile = txtBox_WaitForFile.Text;
            ordSysNew.WaitIsFldr = chkBox_WaitFileIsFldr.Checked;

            OrderSysList.AddOrdSysToOrdSysList(ordSysNew);
            Close();
        }

        private void but_Del_Click(object sender, EventArgs e)
        {
            var ordSysName = txtBox_OrdSysName.Text;
            OrderSysList.DelOrdSysFromOrdSysList(ordSysName);
            Close();
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
    }
}
