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
        Label[] osIlabels;
        BindingList<OrderSystem> osBindingList;
        public FolderWatcher fw;
        delegate void UpdateStausWindowDelegate(int status, string text);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addToLog(1, "Hots order uploader started");
            Set.LoadSettings();
            makeLables();
            fillOSFormFromSettings();
            addToLog(1, "Local settings loaded");
            checkPaths();
            addToLog(1, "Local paths checked\r\n");
        }

        public void UpdateStatusWindow(int status, string text)
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
        }//called by new fle in watched folder

        private void addToLog(int status, string text)// called by FolderWatcherFoundOrder
        {
            if (txtBox_Log.Lines.Length > 500)
            {
                txtBox_Log.Lines = txtBox_Log.Lines.Skip(txtBox_Log.Lines.Length - 500).ToArray();
            }
            txtBox_Log.AppendText(DateTime.Now.ToString("MM/dd h:mm:ss tt  ") + text + "\r\n");

            if (status == 0)
            {
                if (txtBox_Errors.Lines.Length > 500)
                {
                    txtBox_Errors.Lines = txtBox_Errors.Lines.Skip(txtBox_Errors.Lines.Length - 500).ToArray();
                }
                txtBox_Errors.AppendText(DateTime.Now.ToString("MM/dd h:mm:ss tt  ") + text + "\r\n");
            }
        }

        public void fillOrderGridviewfromList(DataTable dt)
        {
            var source = new BindingSource(dt, null);
           // Gridview_OrderList.DataSource = source;
        }

        private void makeLables()
        {
            osIlabels = new Label[Set.ListOrdSys.Count];
            for (int i = 0; i < Set.ListOrdSys.Count; i++)
            {
                osIlabels[i] = new Label();
                osIlabels[i].Text = Set.ListOrdSys[i].Name;
                osIlabels[i].Visible = true;
                osIlabels[i].Location = new Point(100 + (i * 100), 8);
                Controls.Add(osIlabels[i]);
            }
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
                        if (!Set.ListOrdSys[i].WatchFldr.ToUpper().Contains(txtBox_WchRoot.Text.ToUpper()) ||
                            !Directory.Exists(Set.ListOrdSys[i].WatchFldr))
                        {
                            Set.ListOrdSys[i].Active = false;
                            Gridview_OS.Rows[i].Cells[2].Style.BackColor = Color.Pink;
                            Gridview_OS.Rows[i].Cells[2].Value = "Folder must exist inside 'watched root' folder";
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

                    if (Set.ListOrdSys[i].Active == true)
                    {
                        osIlabels[i].ForeColor = Color.Green;
                    }
                    else
                    {
                        osIlabels[i].ForeColor = Color.LightGray;
                    }
                }
            }
        }

        private void fillOSFormFromSettings()
        {
            txtBox_WchRoot.Text = Set.WchRoot;
            osBindingList = new BindingList<OrderSystem>(Set.ListOrdSys);
            var source = new BindingSource(osBindingList, null);
            Gridview_OS.DataSource = source;
        }

        private void but_StartWatch_Click(object sender, EventArgs e)
        {
            fw = new FolderWatcher(Set.WchRoot, this);
            if (but_StartWatch.Text == "Start Watch")
            {
                fw.StartWatching();
                but_StartWatch.Text = "Stop Watch";
                addToLog(1, "Folder watch started");
            }
            else
            {
                fw.StopWatching();
                but_StartWatch.Text = "Start Watch";
                addToLog(1, "Folder watch stopped");
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
                Set.WchRoot = txtBox_WchRoot.Text;
                Set.SaveSettings();
                checkPaths();

            }
        }
    }
}
