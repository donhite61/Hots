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
        int index;
        Settings Set = Settings.GetSettings();
        FolderBrowserDialog fb = new FolderBrowserDialog();

        public frm_UpdOrdSys(DataGridViewRow _selectedRow)
        {
            InitializeComponent();
            index = _selectedRow.Index;
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

            processUpdateForm();
        }

        private void processUpdateForm()
        {
            Set.ListOrdSys[index].Active = chkBox_Active.Checked;
            Set.ListOrdSys[index].WatchFldr = txtBox_WatchedFolder.Text;
            Set.ListOrdSys[index].Ext = txtBox_WchdExt.Text;
            Set.ListOrdSys[index].ReadFld = txtBox_ReadFolder.Text;
            Set.ListOrdSys[index].OutFldr = txtBox_OutputFolder.Text;
            Set.ListOrdSys[index].PrdSubFldr = txtBox_ProdSubFldr.Text;
            Set.ListOrdSys[index].WaitFile = txtBox_WaitForFile.Text;
            Set.ListOrdSys[index].WaitIsFldr = chkBox_WaitFileIsFldr.Checked;
            Settings.SaveSettings(Set);
            Close();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void but_BrowseFolder_Click(object sender, EventArgs e)
        {
            if (sender.ToString().Contains("Watched"))
            {
                fb.SelectedPath = Set.WchRoot;
            }
            else
            {
                fb.SelectedPath = "";
            }

            var result = fb.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fb.SelectedPath))
            {
                if (sender.ToString().Contains("Watched"))
                {
                    txtBox_WatchedFolder.Text = fb.SelectedPath.Substring(Set.WchRoot.Length+1);
                }
                if (sender.ToString().Contains("Read"))
                {
                    txtBox_ReadFolder.Text = fb.SelectedPath;
                }
                if (sender.ToString().Contains("Output"))
                {
                    txtBox_OutputFolder.Text = fb.SelectedPath;
                }
            }
        }

    }
}
