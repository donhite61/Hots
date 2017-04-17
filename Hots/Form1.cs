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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            but_StartWatch.Enabled = false;
            Settings.ReadINI();
            FillFormFromSettings();
            CheckPathsRoes();
            CheckPathsDakis();
            CheckPathsDGift();
        }

        private void FillFormFromSettings()
        {
            txtBox_WchRoes.Text = Settings.WchRoes;
            txtBox_RoesExt.Text = Settings.RoesExt;
            txtBox_ReadRoes.Text = Settings.ReadRoes;
            txtBox_OutRoes.Text = Settings.OutRoes;
            txtBox_ProdSubRoes.Text = Settings.ProdSubRoes;
            txtBox_WaitForRoes.Text = Settings.WaitForRoes;
            chkBox_RoesActivate.Checked = Settings.RoesActivate;
            chkBox_RoesWaitIsFldr.Checked = Settings.RoesWaitIsFldr;

            txtBox_WchDakis.Text = Settings.WchDakis;
            txtBox_DakisExt.Text = Settings.DakisExt;
            txtBox_ReadDakis.Text = Settings.ReadDakis;
            txtBox_OutDakis.Text = Settings.OutDakis;
            txtBox_ProdSubDakis.Text = Settings.ProdSubDakis;
            txtBox_WaitForDakis.Text = Settings.WaitForDakis;
            chkBox_DakisActivate.Checked = Settings.DakisActivate;
            chkBox_DakisWaitIsFldr.Checked = Settings.DakisWaitIsFldr;

            txtBox_WchDGift.Text = Settings.WchDGift;
            txtBox_DGiftExt.Text = Settings.DGiftExt;
            txtBox_ReadDGift.Text = Settings.ReadDGift;
            txtBox_OutDGift.Text = Settings.OutDGift;
            txtBox_ProdSubDGift.Text = Settings.ProdSubDGift;
            txtBox_WaitForDGift.Text = Settings.WaitForDGift;
            chkBox_DGiftActivate.Checked = Settings.DGiftActivate;
            chkBox_DGiftWaitIsFldr.Checked = Settings.DGiftWaitIsFldr;
        }

        private bool CheckPathsRoes()
        {
            if (Directory.Exists(Settings.WchRoes))
            {
                txtBox_WchRoes.Text = Settings.WchRoes;
                txtBox_WchRoes.BackColor = Color.White;
            }
            else
            {
                chkBox_RoesActivate.Checked = false;
                txtBox_WchRoes.BackColor = Color.Pink;
            }

            if (Directory.Exists(Settings.ReadRoes))
            {
                txtBox_ReadRoes.Text = Settings.ReadRoes;
                txtBox_ReadRoes.BackColor = Color.White;
            }
            else
            {
                chkBox_RoesActivate.Checked = false;
                txtBox_ReadRoes.BackColor = Color.Pink;
            }

            if (Directory.Exists(Settings.OutRoes))
            {
                txtBox_OutRoes.Text = Settings.OutRoes;
                txtBox_OutRoes.BackColor = Color.White;
            }
            else
            {
                chkBox_RoesActivate.Checked = false;
                txtBox_OutRoes.BackColor = Color.Pink;
            }

            return chkBox_RoesActivate.Checked;
        }

        private bool CheckPathsDakis()
        {
            if (Directory.Exists(Settings.WchDakis))
            {
                txtBox_WchDakis.Text = Settings.WchDakis;
                txtBox_WchDakis.BackColor = Color.White;
            }
            else
            {
                chkBox_DakisActivate.Checked = false;
                txtBox_WchDakis.BackColor = Color.Pink;
            }

            if (Directory.Exists(Settings.ReadDakis))
            {
                txtBox_ReadDakis.Text = Settings.ReadDakis;
                txtBox_ReadDakis.BackColor = Color.White;
            }
            else
            {
                chkBox_DakisActivate.Checked = false;
                txtBox_ReadDakis.BackColor = Color.Pink;
            }

            if (Directory.Exists(Settings.OutDakis))
            {
                txtBox_OutDakis.Text = Settings.OutDakis;
                txtBox_OutDakis.BackColor = Color.White;
            }
            else
            {
                chkBox_DakisActivate.Checked = false;
                txtBox_OutDakis.BackColor = Color.Pink;
            }

            return chkBox_DakisActivate.Checked;
        }

        private bool CheckPathsDGift()
        {
            if (Directory.Exists(Settings.WchDGift))
            {
                txtBox_WchDGift.Text = Settings.WchDGift;
                txtBox_WchDGift.BackColor = Color.White;
            }
            else
            {
                chkBox_DGiftActivate.Checked = false;
                txtBox_WchDGift.BackColor = Color.Pink;
            }

            if (Directory.Exists(Settings.ReadDGift))
            {
                txtBox_ReadDGift.Text = Settings.ReadDGift;
                txtBox_ReadDGift.BackColor = Color.White;
            }
            else
            {
                chkBox_DGiftActivate.Checked = false;
                txtBox_ReadDGift.BackColor = Color.Pink;
            }

            if (Directory.Exists(Settings.OutDGift))
            {
                txtBox_OutDGift.Text = Settings.OutDGift;
                txtBox_OutDGift.BackColor = Color.White;
            }
            else
            {
                chkBox_DGiftActivate.Checked = false;
                txtBox_OutDGift.BackColor = Color.Pink;
            }

            return chkBox_DGiftActivate.Checked;
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

        private void but_Save_Click(object sender, EventArgs e)
        {
            Settings.WchRoes = txtBox_WchRoes.Text;
            Settings.RoesExt = txtBox_RoesExt.Text;
            Settings.ReadRoes = txtBox_ReadRoes.Text;
            Settings.OutRoes = txtBox_OutRoes.Text;
            Settings.ProdSubRoes = txtBox_ProdSubRoes.Text;
            Settings.WaitForRoes = txtBox_WaitForRoes.Text;
            chkBox_RoesActivate.Checked = (true) ?
                        Settings.RoesActivate = true:
                        Settings.RoesActivate = false;
            chkBox_RoesWaitIsFldr.Checked = (true) ?
                        Settings.RoesWaitIsFldr = true:
                        Settings.RoesWaitIsFldr = false;

            Settings.WchDakis = txtBox_WchDakis.Text;
            Settings.DakisExt = txtBox_DakisExt.Text;
            Settings.ReadDakis = txtBox_ReadDakis.Text;
            Settings.OutDakis = txtBox_OutDakis.Text;
            Settings.ProdSubDakis = txtBox_ProdSubDakis.Text;
            Settings.WaitForDakis = txtBox_WaitForDakis.Text;
            chkBox_DakisActivate.Checked = (true) ?
                        Settings.DakisActivate = true :
                        Settings.DakisActivate = false;
            chkBox_DakisWaitIsFldr.Checked = (true) ?
                        Settings.DakisWaitIsFldr = true :
                        Settings.DakisWaitIsFldr = false;

            Settings.WchDGift = txtBox_WchDGift.Text;
            Settings.DGiftExt = txtBox_DGiftExt.Text;
            Settings.ReadDGift = txtBox_ReadDGift.Text;
            Settings.OutDGift = txtBox_OutDGift.Text;
            Settings.ProdSubDGift = txtBox_ProdSubDGift.Text;
            Settings.WaitForDGift = txtBox_WaitForDGift.Text;
            chkBox_DGiftActivate.Checked = (true) ?
                        Settings.DGiftActivate = true :
                        Settings.DGiftActivate = false;
            chkBox_DGiftWaitIsFldr.Checked = (true) ?
                        Settings.DGiftWaitIsFldr = true :
                        Settings.DGiftWaitIsFldr = false;

            Settings.WriteINI();
            CheckPathsRoes();
            CheckPathsDakis();
            CheckPathsDGift();
        }

        private void but_Roes_Click(object sender, EventArgs e)
        {
            var fDB = new FolderBrowserDialog();
            DialogResult result = fDB.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (sender.ToString().Contains("Watched Folder"))
                    txtBox_WchRoes.Text = fDB.SelectedPath;
                else if (sender.ToString().Contains("Read Folder"))
                    txtBox_ReadRoes.Text = fDB.SelectedPath;
                else if (sender.ToString().Contains("Output Folder"))
                    txtBox_OutRoes.Text = fDB.SelectedPath;
            }
        }

        private void chkBox_RoesActivate_CheckedChanged(object sender, EventArgs e)
        {
            //if (!CheckPathsRoes())
            //    chkBox_RoesActivate.Checked = false;
        }
    }
}
