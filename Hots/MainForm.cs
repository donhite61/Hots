using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hots
{
    
    public partial class Form1 : Form
    {
        Label[] osIlabels;
        DataTable OrdTable;
        delegate void UpdateStausWindowDelegate(int status, string text);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Data.LogEvents(1, "Interface loaded");
            makeOrdSysIndLables();
            UpdateWchrIndicators();
            fillOSFormFromSettings();

            fillStoreDatatable();
           // Data.LogEvents(1, "Local paths checked");
        }


        public void UpdateStatusWindow(int status, string text)//called by data logevents
        {
            if (txtBox_Log.InvokeRequired)
            {
                var d = new UpdateStausWindowDelegate(addToLog);
                Invoke(d, new object[] {status, text });
            }
            else
            {
                addToLog(status, text);
            }
        }

        private void addToLog(int status, string text)// called by UpdateStatusWindow
        {
            if (txtBox_Log.Lines.Length > 500)
            {
                txtBox_Log.Lines = txtBox_Log.Lines.Skip(txtBox_Log.Lines.Length - 500).ToArray();
            }
            txtBox_Log.AppendText(text + "\r\n");

            if (status == 0)
            {
                if (txtBox_Errors.Lines.Length > 500)
                {
                    txtBox_Errors.Lines = txtBox_Errors.Lines.Skip(txtBox_Errors.Lines.Length - 500).ToArray();
                }
                txtBox_Errors.AppendText( text + "\r\n");
            }
        }

        private void makeOrdSysIndLables()
        {
            osIlabels = new Label[Set.OrdSysList.Count];
            for (int i = 0; i < Set.OrdSysList.Count; i++)
            {
                osIlabels[i] = new Label();
                osIlabels[i].Text = Set.OrdSysList[i].Name.ToString();
                osIlabels[i].ForeColor = Color.LightGray;
                osIlabels[i].Visible = true;
                osIlabels[i].Location = new Point(100 + (i * 100), 8);
                Controls.Add(osIlabels[i]);
            }
        }

        private void UpdateWchrIndicators()
        {
            for (int i = 0; i < Set.OrdSysList.Count; i++)
            {
                if (Set.OrdSysList[i].fwActive == true)
                {
                    osIlabels[i].ForeColor = Color.Green;
                }
                else
                {
                    if (Set.OrdSysList[i].Active == true)
                    {
                        osIlabels[i].ForeColor = Color.Red;
                    }
                    else
                    {
                        osIlabels[i].ForeColor = Color.LightGray;
                    }
                }
            }
        }

        #region Order Systems
        private void fillOSFormFromSettings()
        {
            Gridview_OS.DataSource = Set.OrdSysList;
            Gridview_OS.Columns[0].Visible = false;
            Gridview_OS.Columns[10].Visible = false;
        }

        private void ordSysGrid_DblClicked(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            frm_UpdOrdSys editStoreForm = new frm_UpdOrdSys(Set.OrdSysList[rowIndex]);
            editStoreForm.FormClosed += frm_UpdOrdSys_FormClosed;
            editStoreForm.Show();

        }

        private void frm_UpdOrdSys_FormClosed(object sender, FormClosedEventArgs e)
        {
            Gridview_OS.DataSource = null;
            fillOSFormFromSettings();
        }
        #endregion Order Systems

        #region Orders
        private void fillOrderGridviewfromList()
        {
            OrdTable = Data.GetShortOrderList();
            Gridview_OrdHeaders.DataSource = OrdTable;
        }

        private void btn_UpateOrders_Click(object sender, EventArgs e)
        {

            fillOrderGridviewfromList();
        }

        #endregion Orders

        #region Location

        private void fillStoreDatatable()
        {
            Gridview_Stores.DataSource = Set.LocList;
            Gridview_Stores.Columns[0].Visible = false;
            lbl_SelectedStore.Text = Set.ThisLocation;
        }

        private void Gridview_Location_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var strIndex = Gridview_Stores.SelectedCells[0].RowIndex;
            var editStoreForm = new EditLocationForm(Set.LocList[strIndex]);
            editStoreForm.FormClosed += editLocationForm_FormClosed;
            editStoreForm.Show();
        }

        private void but_AddStore_Click(object sender, EventArgs e)
        {
            var editStoreForm = new EditLocationForm(null);
            editStoreForm.FormClosed += editLocationForm_FormClosed;
            editStoreForm.Show();
        }

        private void editLocationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Gridview_Stores.DataSource = null;
            fillStoreDatatable();
        }

        private void but_SetStore_Click(object sender, EventArgs e)
        {
            if (Gridview_Stores.CurrentCell != null)
            {
                int selRow = Gridview_Stores.CurrentCell.RowIndex;
                DataGridViewRow row = Gridview_Stores.Rows[selRow];
                if (selRow != -1)
                {
                    Set.ThisLocation = row.Cells[1].Value.ToString();
                    lbl_SelectedStore.Text = Set.ThisLocation;
                    Set.SaveSettings();
                }
            }
        }
        #endregion Location

    }
}
