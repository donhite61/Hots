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
    public partial class Form1 : Form
    {
        public FolderWatcher fw;
        public Form1()
        {
            InitializeComponent();
            fw = new FolderWatcher();
        }

        private void but_NewRoesOrder_Click(object sender, EventArgs e)
        {
                if (but_NewRoesOrder.Text == "Start Watch")
                {
                    fw.StartWatching();
                    but_NewRoesOrder.Text = "Stop Watch";
                }
                else
                {
                    fw.StopWatching();
                    but_NewRoesOrder.Text = "Start Watch";
                }
        }
    }
}
