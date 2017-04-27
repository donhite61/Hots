using System;
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
    public partial class Form1 : Form
    {
        Settings Set = Settings.GetSettings();
        BindingList<OrderSystem> bindingList;
        public FolderWatcher fw;
        FolderBrowserDialog fDB = new FolderBrowserDialog();

        public frm_UpdOrdSys frm_UpdOrdSys;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillFormFromSettings();
        }

        private void checkPaths()
        {
            if (!Directory.Exists(Set.WchRoot))
            {
                txtBox_WchRoot.BackColor = Color.Pink;
                Gridview_OS.Visible = false;
            }
            else
            {
                txtBox_WchRoot.BackColor = Color.White;
                Gridview_OS.Visible = true;
                for (int i = 0; i < Set.ListOrdSys.Count; i++)
                {
                    if (Set.ListOrdSys[i].Active == true)
                    {
                        if (!Directory.Exists(Set.WchRoot + "\\" + Set.ListOrdSys[i].WatchFldr))
                        {
                            Set.ListOrdSys[i].Active = false;
                            Gridview_OS.Rows[i].Cells[2].Style.BackColor = Color.Pink;
                        }
                        if (!Directory.Exists(Set.ListOrdSys[i].ReadFld))
                        {
                            Set.ListOrdSys[i].Active = false;
                            Gridview_OS.Rows[i].Cells[4].Style.BackColor = Color.Pink;
                        }
                        if (!Directory.Exists(Set.ListOrdSys[i].OutFldr))
                        {
                            Set.ListOrdSys[i].Active = false;
                            Gridview_OS.Rows[i].Cells[5].Style.BackColor = Color.Pink;
                        }
                    }
                }
            }
        }

        private void FillFormFromSettings()
        {
            txtBox_WchRoot.Text = Set.WchRoot;
            bindingList = new BindingList<OrderSystem>(Set.ListOrdSys);
            var source = new BindingSource(bindingList, null);
            Gridview_OS.DataSource = source;
        }

        private void but_StartWatch_Click(object sender, EventArgs e)
        {
            fw = new FolderWatcher("watchfolder");
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
            FillFormFromSettings();
            checkPaths();
        }

        private void OrdSysGrid_DblClicked(object sender, DataGridViewCellEventArgs e)
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
                Set.WchRoot = txtBox_WchRoot.Text;
                checkPaths();

            }
        }

        private void Gridview_OS_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            checkPaths();
        }
    }
}
