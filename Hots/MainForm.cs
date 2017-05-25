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
        BindingList<OrderSystem> osBindingList;
        delegate void UpdateStausWindowDelegate(int status, string text);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Data.LogEvents(1, "Interface loaded");
            makeOrdSysIndLables();
            StartStopWatchers();

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

        private void StartStopWatchers()
        {
            for (int i = 0; i < Set.OrdSysList.Count; i++)
            {
                if (Set.OrdSysList[i].Active == true)
                {
                    if (Set.PickupLoc != "Please select Store")
                        Watchers.StartWatching(Set.OrdSysList[i]);
                }
                else
                {
                    Watchers.StopWatching(Set.OrdSysList[i]);
                }

                UpdateWchrIndicators(i);
            }
        }

        private void UpdateWchrIndicators(int i)
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

        #region Order Systems

        private void fillOSFormFromSettings()
        {
            osBindingList = new BindingList<OrderSystem>(Set.OrdSysList);
            var source = new BindingSource(osBindingList, null);
            Gridview_OS.DataSource = source;
        }

        private void frm_UpdOrdSys_FormClosed(object sender, FormClosedEventArgs e)
        {
            fillOSFormFromSettings();
            StartStopWatchers();
        }

        private void ordSysGrid_DblClicked(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = Gridview_OS.Rows[rowIndex];
            frm_UpdOrdSys editStoreForm = new frm_UpdOrdSys(row);
            editStoreForm.FormClosed += frm_UpdOrdSys_FormClosed;
            editStoreForm.Show();

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

        #region Stores

        private void fillStoreDatatable()
        {
            Gridview_Stores.DataSource = PickupLocation.GetStoreDataTable();
            lbl_SelectedStore.Text = Set.PickupLoc;
        }

        private void Gridview_Stores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selRow = Gridview_Stores.SelectedCells[0].RowIndex;
            var editStoreForm = new EditStoreForm(Gridview_Stores.Rows[selRow]);
            editStoreForm.FormClosed += editStoreForm_FormClosed;
            editStoreForm.Show();
        }

        private void but_AddStore_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = null;
            var editStoreForm = new EditStoreForm(row);
            editStoreForm.FormClosed += editStoreForm_FormClosed;
            editStoreForm.Show();
        }

        private void editStoreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            fillStoreDatatable();
        }

        private void but_SetStore_Click(object sender, EventArgs e)
        {
            int selRow = Gridview_Stores.CurrentCell.RowIndex;
            DataGridViewRow row = Gridview_Stores.Rows[selRow];
            if (selRow != -1)
            {
                Set.PickupLoc = row.Cells[1].Value.ToString();
                lbl_SelectedStore.Text = Set.PickupLoc;
                Set.SaveSettings();
                StartStopWatchers();
            }
        }
        #endregion Stores

    }
}
