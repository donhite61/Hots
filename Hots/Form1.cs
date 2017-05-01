﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Hots
{
    delegate void dToggleIncOrdLbl(bool incOrd_Visable);
    public partial class Form1 : Form
    {
        Label[] oSIlable;
        Settings set = Settings.GetSettings();
        BindingList<OrderSystem> bindingList;
        BindingList<Order> OrdBindingList;
        public FolderWatcher fw;
        FolderBrowserDialog fDB = new FolderBrowserDialog();
        public frm_UpdOrdSys frm_UpdOrdSys;
        private delegate void showReceivingOrder(bool _status);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            makeLables();
            fillOSFormFromSettings();
            checkPaths();
        }

        private void ToggleIncOrdLbl(bool incOrd_Visable)// called by FolderWatcherFoundOrder
        {
            lbl_RcvOrder.Visible = incOrd_Visable;
            if (!incOrd_Visable)
            {
                DataTable dt = LData.GetShortOrderList("new", "Web");
                Gridview_OrderList.DataSource = dt;
                Gridview_OrderList.Columns["Sql Id"].Visible = false;
            }

            this.Refresh();
        }

        private void addNewOrdertoNewOrdList(Order _newOrder)
        {
            var list = ListofOrders.AddOrdertoList(_newOrder);
            fillOrderGridviewfromList(list);
        }

        private void fillOrderGridviewfromList(List<Order> _list)
        {
            OrdBindingList = new BindingList<Order>(_list);
            var source = new BindingSource(OrdBindingList, null);
            Gridview_OrderList.DataSource = source;
        }

        public void FolderWatcherFoundOrder(bool incOrd_Visable)//called by new fle in watched folder
        {
            if (lbl_RcvOrder.InvokeRequired)
            {
                dToggleIncOrdLbl d = new dToggleIncOrdLbl(ToggleIncOrdLbl);
                Invoke(d, new object[] { incOrd_Visable });
            }
            else
            {
                ToggleIncOrdLbl(incOrd_Visable);
            }
            
        }

        private void makeLables()
        {
            oSIlable = new Label[set.ListOrdSys.Count];
            for (int i = 0; i < set.ListOrdSys.Count; i++)
            {
                oSIlable[i] = new Label();
                oSIlable[i].Text = set.ListOrdSys[i].Name;
                oSIlable[i].Visible = true;
                oSIlable[i].Location = new Point(100 + (i * 100), 8);
                Controls.Add(oSIlable[i]);
            }
        }

        private void checkPaths()
        {
            if (!Directory.Exists(set.WchRoot))
            {
                txtBox_WchRoot.BackColor = Color.Pink;
                Gridview_OS.Visible = false;
            }
            else
            {
                txtBox_WchRoot.BackColor = Color.White;
                Gridview_OS.Visible = true;
                for (int i = 0; i < set.ListOrdSys.Count; i++)
                {
                    if (set.ListOrdSys[i].Active == true)
                    {
                        if (!set.ListOrdSys[i].WatchFldr.ToUpper().Contains(txtBox_WchRoot.Text.ToUpper()) ||
                            !Directory.Exists(set.ListOrdSys[i].WatchFldr))
                        {
                            set.ListOrdSys[i].Active = false;
                            Gridview_OS.Rows[i].Cells[2].Style.BackColor = Color.Pink;
                            Gridview_OS.Rows[i].Cells[2].Value = "Folder must exist inside 'watched root' folder";
                        }
                        if (!Directory.Exists(set.ListOrdSys[i].ReadFld))
                        {
                            set.ListOrdSys[i].Active = false;
                            Gridview_OS.Rows[i].Cells[4].Style.BackColor = Color.Pink;
                        }
                        if (!Directory.Exists(set.ListOrdSys[i].OutFldr))
                        {
                            set.ListOrdSys[i].Active = false;
                            Gridview_OS.Rows[i].Cells[5].Style.BackColor = Color.Pink;
                        }
                    }

                    if (set.ListOrdSys[i].Active == true)
                    {
                        oSIlable[i].ForeColor = Color.Green;
                    }
                    else
                    {
                        oSIlable[i].ForeColor = Color.LightGray;
                    }
                }
            }
        }

        private void fillOSFormFromSettings()
        {
            txtBox_WchRoot.Text = set.WchRoot;
            bindingList = new BindingList<OrderSystem>(set.ListOrdSys);
            var source = new BindingSource(bindingList, null);
            Gridview_OS.DataSource = source;
        }

        private void but_StartWatch_Click(object sender, EventArgs e)
        {
            fw = new FolderWatcher(set.WchRoot, this);
            if (but_StartWatch.Text == "Start Watch")
            {
                fw.StartWatching();
                but_StartWatch.Text = "Stop Watch";
            }
            else
            {
                fw.StopWatching();
                but_StartWatch.Text = "Start Watch";
            }
        }

        private void frm_UpdOrdSys_FormClosed(object sender, FormClosedEventArgs e)
        {
            fillOSFormFromSettings();
            checkPaths();
        }

        private void ordSysGrid_DblClicked(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = Gridview_OS.Rows[rowIndex];
            frm_UpdOrdSys editStoreForm = new frm_UpdOrdSys(row);
            editStoreForm.FormClosed += frm_UpdOrdSys_FormClosed;
            editStoreForm.Show();

        }

        private void but_SetWchRoot_Click(object sender, EventArgs e)
        {
            var fb = new FolderBrowserDialog();
            fb.SelectedPath = txtBox_WchRoot.Text;
            var result = fb.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fb.SelectedPath))
            {
                txtBox_WchRoot.Text = fb.SelectedPath;
                set.WchRoot = txtBox_WchRoot.Text;
                checkPaths();

            }
        }

        private void but_GetOrders_Click(object sender, EventArgs e)
        {
            DataTable dt = LData.GetShortOrderList("new", "Web");
            Gridview_OrderList.DataSource = dt;
            Gridview_OrderList.Columns["Sql Id"].Visible = false;
        }
    }
}
