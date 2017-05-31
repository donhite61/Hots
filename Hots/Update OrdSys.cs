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
        DataGridViewRow sRow;
        protected string ordSysName;
        int index;

        public frm_UpdOrdSys(DataGridViewRow _selectedRow)
        {
            InitializeComponent();
            sRow = _selectedRow;
            ordSysName = Convert.ToString(_selectedRow.Cells[0].Value);
        }

        private void frm_UpdOrdSys_Load(object sender, EventArgs e)
        {
            fillTextBoxesFromSelectedRow(sRow);
            fillKeywordGrid();
        }

        private void fillTextBoxesFromSelectedRow(DataGridViewRow _selectedRow)
        {
            index = _selectedRow.Index;
            txtBox_OrdSysName.Text = Convert.ToString(_selectedRow.Cells[0].Value);
            chkBox_Active.Checked = Convert.ToBoolean(_selectedRow.Cells[1].Value);
            txtBox_WatchedFolder.Text = Convert.ToString(_selectedRow.Cells[2].Value);
            txtBox_WchdExt.Text = Convert.ToString(_selectedRow.Cells[3].Value);
            txtBox_OutputFolder.Text = Convert.ToString(_selectedRow.Cells[4].Value);
            txtBox_ProdSubFldr.Text = Convert.ToString(_selectedRow.Cells[5].Value);
            txtBox_WaitForFile.Text = Convert.ToString(_selectedRow.Cells[6].Value);
            chkBox_WaitFileIsFldr.Checked = Convert.ToBoolean(_selectedRow.Cells[7].Value);
        }

        private void fillKeywordGrid()
        {
            var sskTable = PickupKeywords.GetSPickupKeywordDTableFilterByOrdSys(txtBox_OrdSysName.Text);
            Gridview_OrdSysShipKeywords.DataSource = sskTable;
        }

        private bool processUpdateForm()
        {
            Set.OrdSysList[index].Active = chkBox_Active.Checked;
            Set.OrdSysList[index].WatchFldr = txtBox_WatchedFolder.Text;
            Set.OrdSysList[index].Ext = txtBox_WchdExt.Text;
            Set.OrdSysList[index].OutFldr = txtBox_OutputFolder.Text;
            Set.OrdSysList[index].PrdSubFldr = txtBox_ProdSubFldr.Text;
            Set.OrdSysList[index].WaitFile = txtBox_WaitForFile.Text;
            Set.OrdSysList[index].WaitIsFldr = chkBox_WaitFileIsFldr.Checked;
            Set.SaveSettings();
            Close();
            return true;
        }

        private void but_Update_Click(object sender, EventArgs e)
        {
            processUpdateForm();
        }

        private void but_WatchFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            var result = fb.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fb.SelectedPath))
                    txtBox_WatchedFolder.Text = fb.SelectedPath;
        }

        private void but_OutFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.SelectedPath = "";
            var result = fb.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fb.SelectedPath))
                txtBox_OutputFolder.Text = fb.SelectedPath;
        }

        private void Gridview_sskKeywords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //var selRow = Gridview_OrdSysShipKeywords.SelectedCells[0].RowIndex;
            //var editKeyWordForm = new KeywordForm(Gridview_OrdSysShipKeywords.Rows[selRow], ordSysName);
            //editKeyWordForm.FormClosed += editKeyWordForm_FormClosed;
            //editKeyWordForm.Show();
        }

        private void editKeyWordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void but_AddKeyWord_Click(object sender, EventArgs e)
        {
           // editKeyWordForm = new KeywordForm(null, ordSysName);
            editKeyWordForm.FormClosed += editKeyWordForm_FormClosed;
            editKeyWordForm.Show();
        }
    }
}
