using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Hots
{
    public partial class frm_UpdOrdSys : Form
    {
        int index;
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
            Set.SaveSettings();
            Close();
        }

        private void but_Update_Click(object sender, EventArgs e)
        {
            processUpdateForm();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void but_WatchFolder_Click(object sender, EventArgs e)
        {
            fb.SelectedPath = Set.WchRoot;
            var result = fb.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fb.SelectedPath))
            {
                if (fb.SelectedPath.ToUpper().Contains(Set.WchRoot.ToUpper()) && Directory.Exists(fb.SelectedPath))
                {
                    txtBox_WatchedFolder.Text = fb.SelectedPath;
                    txtBox_WatchedFolder.BackColor = Color.White;
                }
                else
                {
                    txtBox_WatchedFolder.BackColor = Color.Pink;
                    txtBox_WatchedFolder.Text = "Folder must exist inside 'watched root' folder";
                }
            }
        }

        private void but_ReadFolder_Click(object sender, EventArgs e)
        {
            fb.SelectedPath = "";
            var result = fb.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fb.SelectedPath))
                txtBox_ReadFolder.Text = fb.SelectedPath;
        }

        private void but_OutFolder_Click(object sender, EventArgs e)
        {
            fb.SelectedPath = "";
            var result = fb.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fb.SelectedPath))
                txtBox_OutputFolder.Text = fb.SelectedPath;
        }

    }
}
