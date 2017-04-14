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
        public FolderWatcher fw;
        public ReadWrite rw;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rw = new ReadWrite();
            rw.ReadINI();
            CheckPaths();
        }

        private void CheckPaths()
        {
            but_NewRoesOrder.Enabled = true;
            if (Directory.Exists(Settings.FileWatcherNewPath))
            {
                txtBox_WchFldr.Text = Settings.FileWatcherNewPath;
                txtBox_WchFldr.BackColor = Color.White;
            }
            else
            {
                but_NewRoesOrder.Enabled = false;
                txtBox_WchFldr.BackColor = Color.Pink;
            }

            if (Directory.Exists(Settings.FileWatcherReadPath))
            {
                txtBox_ReadFldr.Text = Settings.FileWatcherReadPath;
                txtBox_ReadFldr.BackColor = Color.White;
            }
            else
            {
                but_NewRoesOrder.Enabled = false;
                txtBox_ReadFldr.BackColor = Color.Pink;
            }

            if (Directory.Exists(Settings.DakisWatchPath))
            {
                txtBox_WchDakis.Text = Settings.DakisWatchPath;
                txtBox_WchDakis.BackColor = Color.White;
            }
            else
            {
                but_NewRoesOrder.Enabled = false;
                txtBox_WchDakis.BackColor = Color.Pink;
            }

            if (Directory.Exists(Settings.DakisOrderPath))
            {
                txtBox_DakisOutput.Text = Settings.DakisOrderPath;
                txtBox_DakisOutput.BackColor = Color.White;
            }
            else
            {
                but_NewRoesOrder.Enabled = false;
                txtBox_DakisOutput.BackColor = Color.Pink;
            }

            if (Directory.Exists(Settings.RoesWatchPath))
            {
                txtBox_WchRoes.Text = Settings.RoesWatchPath;
                txtBox_WchRoes.BackColor = Color.White;
            }
            else
            {
                but_NewRoesOrder.Enabled = false;
                txtBox_WchRoes.BackColor = Color.Pink;
            }

            if (Directory.Exists(Settings.RoesOrderPath))
            {
                txtBox_RoesOutput.Text = Settings.RoesOrderPath;
                txtBox_RoesOutput.BackColor = Color.White;
            }
            else
            {
                but_NewRoesOrder.Enabled = false;
                txtBox_RoesOutput.BackColor = Color.Pink;
            }
        }

        private void but_SetFldr_Click(object sender, EventArgs e)
        {
            var fDB = new FolderBrowserDialog();
            if (sender.ToString().Contains("Watched Dakis") ||
                sender.ToString().Contains("Watched Roes") ||
                sender.ToString().Contains("Read Folder"))
                    fDB.SelectedPath = txtBox_WchFldr.Text;

            DialogResult result = fDB.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (sender.ToString().Contains("Watched Folder"))
                    txtBox_WchFldr.Text = fDB.SelectedPath;
                else if (sender.ToString().Contains("Watched Dakis"))
                    txtBox_WchDakis.Text = fDB.SelectedPath;
                else if (sender.ToString().Contains("Dakis Output"))
                    txtBox_DakisOutput.Text = fDB.SelectedPath;
                else if (sender.ToString().Contains("Watched Roes"))
                    txtBox_WchRoes.Text = fDB.SelectedPath;
                else if (sender.ToString().Contains("Roes Output"))
                    txtBox_RoesOutput.Text = fDB.SelectedPath;
                else if (sender.ToString().Contains("Read Folder"))
                    txtBox_ReadFldr.Text = fDB.SelectedPath;
            }
        }

        private void but_StartWatch_Click(object sender, EventArgs e)
        {
            fw = new FolderWatcher();
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

        private void but_Save_Click(object sender, EventArgs e)
        {
            Settings.FileWatcherNewPath = txtBox_WchFldr.Text;
            Settings.DakisWatchPath = txtBox_WchDakis.Text;
            Settings.DakisOrderPath = txtBox_DakisOutput.Text;
            Settings.RoesWatchPath = txtBox_WchRoes.Text;
            Settings.RoesOrderPath = txtBox_RoesOutput.Text;
            Settings.FileWatcherReadPath = txtBox_ReadFldr.Text;
            rw.WriteINI();
            CheckPaths();
        }
    }
}
