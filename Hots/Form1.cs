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
        FolderBrowserDialog fDB = new FolderBrowserDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //but_StartWatch.Enabled = false;
            Settings.ReadINI();
            FillFormFromSettings();
            but_Save.Visible = false;
            var os = new OrderSysList();
            os = os.getOrdSysList();
            var bindingList = new BindingList<OrderSystem>(os.List);
            var source = new BindingSource(bindingList, null);
            Gridview_OI.DataSource = source;
        }

        private void FillFormFromSettings()
        {
            txtBox_WchRoot.Text = Settings.WchRoot;
            fDB.SelectedPath = Settings.WchRoot;

            txtBox_WchRoes.Text = Settings.WchRoes;
            txtBox_RoesExt.Text = Settings.RoesExt;
            txtBox_ReadRoes.Text = Settings.ReadRoes;
            txtBox_OutRoes.Text = Settings.OutRoes;
            txtBox_ProdSubRoes.Text = Settings.ProdSubRoes;
            txtBox_WaitForRoes.Text = Settings.WaitForRoes;
            chkBox_RoesActivate.Checked = Settings.RoesActivate;
            chkBox_RoesWaitIsFldr.Checked = Settings.RoesWaitIsFldr;
            led_RoesOn.Visible = (Settings.RoesActivate) ? true : false;

            txtBox_WchDakis.Text = Settings.WchDakis;
            txtBox_DakisExt.Text = Settings.DakisExt;
            txtBox_ReadDakis.Text = Settings.ReadDakis;
            txtBox_OutDakis.Text = Settings.OutDakis;
            txtBox_ProdSubDakis.Text = Settings.ProdSubDakis;
            txtBox_WaitForDakis.Text = Settings.WaitForDakis;
            chkBox_DakisActivate.Checked = Settings.DakisActivate;
            chkBox_DakisWaitIsFldr.Checked = Settings.DakisWaitIsFldr;
            led_DakisOn.Visible = (Settings.DakisActivate) ? true : false;

            txtBox_WchDGift.Text = Settings.WchDGift;
            txtBox_DGiftExt.Text = Settings.DGiftExt;
            txtBox_ReadDGift.Text = Settings.ReadDGift;
            txtBox_OutDGift.Text = Settings.OutDGift;
            txtBox_ProdSubDGift.Text = Settings.ProdSubDGift;
            txtBox_WaitForDGift.Text = Settings.WaitForDGift;
            chkBox_DGiftActivate.Checked = Settings.DGiftActivate;
            chkBox_DGiftWaitIsFldr.Checked = Settings.DGiftWaitIsFldr;
            led_DGiftOn.Visible = (Settings.DGiftActivate) ? true : false;
        }

        private void CheckPathGeneral()
        {
            if (Directory.Exists(Settings.WchRoot))
            {
                txtBox_WchRoot.Text = Settings.WchRoot;
                txtBox_WchRoot.BackColor = Color.White;
            }
            else
            {
                txtBox_WchRoot.BackColor = Color.Pink;
            }
        }

        private bool CheckPathsRoes()
        {
            var path = "ok";
            if (Directory.Exists(txtBox_WchRoes.Text))
            {
                txtBox_WchRoes.BackColor = Color.White;
            }
            else
            {
                path = "bad";
                txtBox_WchRoes.BackColor = Color.Pink;
            }

            if (Directory.Exists(txtBox_ReadRoes.Text))
            {
                txtBox_ReadRoes.BackColor = Color.White;
            }
            else
            {
                txtBox_ReadRoes.BackColor = Color.Pink;
                path = "bad";
            }

            if (Directory.Exists(txtBox_OutRoes.Text))
            {
                txtBox_OutRoes.BackColor = Color.White;
            }
            else
            {
                txtBox_OutRoes.BackColor = Color.Pink;
                path = "bad";
            }
            return (path == "bad") ? false : true;

        }

        private bool CheckPathsDakis()
        {
            var path = "ok";
            if (Directory.Exists(txtBox_WchDakis.Text))
            {
                txtBox_WchDakis.BackColor = Color.White;
            }
            else
            {
                path = "bad";
                txtBox_WchDakis.BackColor = Color.Pink;
            }

            if (Directory.Exists(txtBox_ReadDakis.Text))
            {
                txtBox_ReadDakis.BackColor = Color.White;
            }
            else
            {
                path = "bad";
                txtBox_ReadDakis.BackColor = Color.Pink;
            }

            if (Directory.Exists(txtBox_OutDakis.Text))
            {
                txtBox_OutDakis.BackColor = Color.White;
            }
            else
            {
                path = "bad";
                txtBox_OutDakis.BackColor = Color.Pink;
            }

            return (path == "bad") ? false : true;
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

        private void but_Gen_Click(object sender, EventArgs e)
        {
            if (sender.ToString().Contains("Watched Root"))
            {
                DialogResult result = fDB.ShowDialog();
                if (result == DialogResult.OK)
                    txtBox_WchRoot.Text = fDB.SelectedPath;
            }
        }

        private void but_Roes_Click(object sender, EventArgs e)
        {
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

        private void but_Dakis_Click(object sender, EventArgs e)
        {
            DialogResult result = fDB.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (sender.ToString().Contains("Watched Folder"))
                    txtBox_WchDakis.Text = fDB.SelectedPath;
                else if (sender.ToString().Contains("Read Folder"))
                    txtBox_ReadDakis.Text = fDB.SelectedPath;
                else if (sender.ToString().Contains("Output Folder"))
                    txtBox_OutDakis.Text = fDB.SelectedPath;
            }
        }

        private void but_DGift_Click(object sender, EventArgs e)
        {
            DialogResult result = fDB.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (sender.ToString().Contains("Watched Folder"))
                    txtBox_WchDGift.Text = fDB.SelectedPath;
                else if (sender.ToString().Contains("Read Folder"))
                    txtBox_ReadDGift.Text = fDB.SelectedPath;
                else if (sender.ToString().Contains("Output Folder"))
                    txtBox_OutDGift.Text = fDB.SelectedPath;
            }
        }

        private void fillSettingsFromForm()
        {
            Settings.WchRoot = txtBox_WchRoot.Text;
            fDB.SelectedPath = Settings.WchRoot;

            Settings.WchRoes = txtBox_WchRoes.Text;
            Settings.RoesExt = txtBox_RoesExt.Text;
            Settings.ReadRoes = txtBox_ReadRoes.Text;
            Settings.OutRoes = txtBox_OutRoes.Text;
            Settings.ProdSubRoes = txtBox_ProdSubRoes.Text;
            Settings.WaitForRoes = txtBox_WaitForRoes.Text;
            Settings.RoesActivate = (chkBox_RoesActivate.Checked) ? true : false;
            Settings.RoesWaitIsFldr = (chkBox_RoesWaitIsFldr.Checked) ? true : false;

            Settings.WchDakis = txtBox_WchDakis.Text;
            Settings.DakisExt = txtBox_DakisExt.Text;
            Settings.ReadDakis = txtBox_ReadDakis.Text;
            Settings.OutDakis = txtBox_OutDakis.Text;
            Settings.ProdSubDakis = txtBox_ProdSubDakis.Text;
            Settings.WaitForDakis = txtBox_WaitForDakis.Text;
            Settings.DakisActivate = (chkBox_DakisActivate.Checked) ? true : false;
            Settings.DakisWaitIsFldr = (chkBox_DakisWaitIsFldr.Checked) ? true : false;

            Settings.WchDGift = txtBox_WchDGift.Text;
            Settings.DGiftExt = txtBox_DGiftExt.Text;
            Settings.ReadDGift = txtBox_ReadDGift.Text;
            Settings.OutDGift = txtBox_OutDGift.Text;
            Settings.ProdSubDGift = txtBox_ProdSubDGift.Text;
            Settings.WaitForDGift = txtBox_WaitForDGift.Text;
            Settings.DGiftActivate = (chkBox_DGiftActivate.Checked) ? true : false;
            Settings.DGiftWaitIsFldr = (chkBox_DGiftWaitIsFldr.Checked) ? true : false;

            //Settings.WriteINI();
            CheckPathsRoes();
            CheckPathsDakis();
            CheckPathsDGift();
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

        private void but_Save_Clicked(object sender, EventArgs e)
        {
            fillSettingsFromForm();
            Settings.WriteINI();
            but_Save.Visible = false;
        }

        private void Show_But_Saved(object sender, EventArgs e)
        {
            but_Save.Visible = true;
        }

        private void chkBox_RoesActivate_CheckedClicked(object sender, EventArgs e)
        {
            if (chkBox_RoesActivate.Checked)
            {
                if (CheckPathsRoes())
                {
                    fillSettingsFromForm();
                    //Settings.WriteINI();
                    led_RoesOn.Visible = true;
                    but_Save.Visible = true;
                }
                else
                {
                    chkBox_RoesActivate.Checked = false;
                    led_RoesOn.Visible = false;
                }
            }
            else
            {
                led_RoesOn.Visible = false;
                but_Save.Visible = true;
            }
        }

        private void chkBox_DakisActivate_Checked_Clicked(object sender, EventArgs e)
        {
            if (chkBox_DakisActivate.Checked)
            {
                if (CheckPathsDakis())
                {
                    fillSettingsFromForm();
                    //Settings.WriteINI();
                    led_DakisOn.Visible = true;
                    but_Save.Visible = true;
                }
                else
                {
                    chkBox_DakisActivate.Checked = false;
                    led_DakisOn.Visible = false;
                }
            }
            else
            {
                led_DakisOn.Visible = false;
                but_Save.Visible = true;
            }
        }
    }
}
