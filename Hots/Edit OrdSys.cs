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
        Form editKeyWordForm;
        protected OrderSystem ordSys;

        public frm_UpdOrdSys(OrderSystem _ordSys)
        {
            ordSys = _ordSys;
            InitializeComponent();
        }

        private void frm_UpdOrdSys_Load(object sender, EventArgs e)
        {
            fillTextBoxesFromOrdSys(ordSys);
            fillKeywordGrid(ordSys);
        }

        private void fillKeywordGrid(OrderSystem ordSys)
        {
            Gridview_PukKeyWords.DataSource = ordSys.PuKeyWordList;
            Gridview_PukKeyWords.Columns[0].Visible = false;
            Gridview_PukKeyWords.Columns[1].Visible = false;
        }

        private void fillTextBoxesFromOrdSys(OrderSystem ordSys)
        {
            txtBox_OrdSysName.Text = ordSys.Name.ToString();
            chkBox_Active.Checked = ordSys.Active;
            txtBox_WatchedFolder.Text = ordSys.WatchedFolder;
            txtBox_WchdExt.Text = ordSys.Ext;
            txtBox_OutputFolder.Text = ordSys.OutputFolder;
            txtBox_LabInFolder.Text = ordSys.LabInFldr;
            txtBox_ProdSubFldr.Text = ordSys.ProductSubFolder;
            txtBox_WaitForFile.Text = ordSys.WaitFile;
            chkBox_WaitFileIsFldr.Checked = ordSys.WaitIsFolder;
            Gridview_PukKeyWords.DataSource = ordSys.PuKeyWordList;
        }

        private void but_WatchFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.SelectedPath = ordSys.WatchedFolder;
            var result = fb.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fb.SelectedPath))
                    txtBox_WatchedFolder.Text = fb.SelectedPath;
        }

        private void but_OutFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.SelectedPath = ordSys.OutputFolder;
            var result = fb.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fb.SelectedPath))
                txtBox_OutputFolder.Text = fb.SelectedPath;
        }

        private void but_LabInFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.SelectedPath = ordSys.LabInFldr;
            var result = fb.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fb.SelectedPath))
                txtBox_LabInFolder.Text = fb.SelectedPath;
        }

        private void but_Update_Click(object sender, EventArgs e)
        {
            var webChanged = false;
            var locChanged = false;
            if (ordSys.Active != chkBox_Active.Checked ||
                ordSys.WatchedFolder != txtBox_WatchedFolder.Text ||
                ordSys.LabInFldr != txtBox_LabInFolder.Text ||
                ordSys.OutputFolder != txtBox_OutputFolder.Text)
            {
                locChanged = true;
                ordSys.Active = chkBox_Active.Checked;
                ordSys.WatchedFolder = txtBox_WatchedFolder.Text;
                ordSys.LabInFldr = txtBox_LabInFolder.Text;
                ordSys.OutputFolder = txtBox_OutputFolder.Text;
            }

            if (ordSys.Ext != txtBox_WchdExt.Text ||
                ordSys.ProductSubFolder != txtBox_ProdSubFldr.Text ||
                ordSys.WaitFile != txtBox_WaitForFile.Text ||
                ordSys.WaitIsFolder != chkBox_WaitFileIsFldr.Checked)
            {
                webChanged = true;
                ordSys.Ext = txtBox_WchdExt.Text;
                ordSys.ProductSubFolder = txtBox_ProdSubFldr.Text;
                ordSys.WaitFile = txtBox_WaitForFile.Text;
                ordSys.WaitIsFolder = chkBox_WaitFileIsFldr.Checked;
            }

            if (locChanged)
            {
                try
                {
                    Set.SaveSettings();
                }
                catch
                {
                    MessageBox.Show("Error saving OrderSystem local settings");
                }
            }
            if (webChanged)
            {
                try
                {
                    OrderSystem.UpdateOrderSystemOnServer(ordSys);
                }
                catch
                {
                    MessageBox.Show("Error saving OrderSystem web settings");
                }
            }

            Close();
        }

        private void but_AddKeyWord_Click(object sender, EventArgs e)
        {
            editKeyWordForm = new EditKeywordForm(ordSys.Id, null);
            editKeyWordForm.FormClosed += editKeyWordForm_FormClosed;
            editKeyWordForm.Show();
        }

        private void Gridview_pukKeywords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selRow = Gridview_PukKeyWords.SelectedCells[0].RowIndex;
            var puk = ordSys.PuKeyWordList[selRow];
            var editKeyWordForm = new EditKeywordForm(ordSys.Id,puk);
            editKeyWordForm.FormClosed += editKeyWordForm_FormClosed;
            editKeyWordForm.Show();
        }

        private void editKeyWordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Gridview_PukKeyWords.DataSource = null;
            fillKeywordGrid(ordSys);
        }

    }
}
