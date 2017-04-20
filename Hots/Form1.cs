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
            //but_StartWatch.Enabled = false;
            var ordSysList = OrderSysList.getOrdSysList();
            bindingList = new BindingList<OrderSystem>(ordSysList);
            var source = new BindingSource(bindingList, null);
            Gridview_OS.DataSource = source;
        }

        private void FillFormFromSettings()
        {
            txtBox_WchRoot.Text = Settings.WchRoot;
            fDB.SelectedPath = Settings.WchRoot;
        }



        private void but_StartWatch_Click(object sender, EventArgs e)
        {
            fw = new FolderWatcher();
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
            var ordSysList = OrderSysList.getOrdSysList();
            bindingList = new BindingList<OrderSystem>(ordSysList);
            var source = new BindingSource(bindingList, null);
            Gridview_OS.DataSource = source;

        }

        private void OrdSysGrid_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = Gridview_OS.Rows[rowIndex];
            frm_UpdOrdSys form = new frm_UpdOrdSys(row);
            form.Show();

        }
    }
}
