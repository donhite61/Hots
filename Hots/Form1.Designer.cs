namespace Hots
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.but_NewRoesOrder = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_NewOrders = new System.Windows.Forms.TabPage();
            this.tab_Settings = new System.Windows.Forms.TabPage();
            this.txtBox_RoesOutput = new System.Windows.Forms.TextBox();
            this.txtBox_WchRoes = new System.Windows.Forms.TextBox();
            this.txtBox_DakisOutput = new System.Windows.Forms.TextBox();
            this.txtBox_WchDakis = new System.Windows.Forms.TextBox();
            this.txtBox_ReadFldr = new System.Windows.Forms.TextBox();
            this.txtBox_WchFldr = new System.Windows.Forms.TextBox();
            this.but_SetRoesOut = new System.Windows.Forms.Button();
            this.but_SetWchRoes = new System.Windows.Forms.Button();
            this.but_SetDakisOut = new System.Windows.Forms.Button();
            this.but_ReadFldr = new System.Windows.Forms.Button();
            this.but_SetWchDakis = new System.Windows.Forms.Button();
            this.but_SetWchFldr = new System.Windows.Forms.Button();
            this.but_Save = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tab_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_NewRoesOrder
            // 
            this.but_NewRoesOrder.Location = new System.Drawing.Point(275, 244);
            this.but_NewRoesOrder.Margin = new System.Windows.Forms.Padding(2);
            this.but_NewRoesOrder.Name = "but_NewRoesOrder";
            this.but_NewRoesOrder.Size = new System.Drawing.Size(92, 23);
            this.but_NewRoesOrder.TabIndex = 0;
            this.but_NewRoesOrder.Text = "Start Watch";
            this.but_NewRoesOrder.UseVisualStyleBackColor = true;
            this.but_NewRoesOrder.Click += new System.EventHandler(this.but_StartWatch_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_NewOrders);
            this.tabControl1.Controls.Add(this.tab_Settings);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(656, 309);
            this.tabControl1.TabIndex = 1;
            // 
            // tab_NewOrders
            // 
            this.tab_NewOrders.Location = new System.Drawing.Point(4, 22);
            this.tab_NewOrders.Name = "tab_NewOrders";
            this.tab_NewOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tab_NewOrders.Size = new System.Drawing.Size(648, 283);
            this.tab_NewOrders.TabIndex = 0;
            this.tab_NewOrders.Text = "tabPage1";
            this.tab_NewOrders.UseVisualStyleBackColor = true;
            // 
            // tab_Settings
            // 
            this.tab_Settings.Controls.Add(this.but_Save);
            this.tab_Settings.Controls.Add(this.txtBox_RoesOutput);
            this.tab_Settings.Controls.Add(this.but_NewRoesOrder);
            this.tab_Settings.Controls.Add(this.txtBox_WchRoes);
            this.tab_Settings.Controls.Add(this.txtBox_DakisOutput);
            this.tab_Settings.Controls.Add(this.txtBox_WchDakis);
            this.tab_Settings.Controls.Add(this.txtBox_ReadFldr);
            this.tab_Settings.Controls.Add(this.txtBox_WchFldr);
            this.tab_Settings.Controls.Add(this.but_SetRoesOut);
            this.tab_Settings.Controls.Add(this.but_SetWchRoes);
            this.tab_Settings.Controls.Add(this.but_SetDakisOut);
            this.tab_Settings.Controls.Add(this.but_ReadFldr);
            this.tab_Settings.Controls.Add(this.but_SetWchDakis);
            this.tab_Settings.Controls.Add(this.but_SetWchFldr);
            this.tab_Settings.Location = new System.Drawing.Point(4, 22);
            this.tab_Settings.Name = "tab_Settings";
            this.tab_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Settings.Size = new System.Drawing.Size(648, 283);
            this.tab_Settings.TabIndex = 1;
            this.tab_Settings.Text = "Settings";
            this.tab_Settings.UseVisualStyleBackColor = true;
            // 
            // txtBox_RoesOutput
            // 
            this.txtBox_RoesOutput.Location = new System.Drawing.Point(126, 209);
            this.txtBox_RoesOutput.Name = "txtBox_RoesOutput";
            this.txtBox_RoesOutput.Size = new System.Drawing.Size(491, 20);
            this.txtBox_RoesOutput.TabIndex = 2;
            // 
            // txtBox_WchRoes
            // 
            this.txtBox_WchRoes.Location = new System.Drawing.Point(126, 174);
            this.txtBox_WchRoes.Name = "txtBox_WchRoes";
            this.txtBox_WchRoes.Size = new System.Drawing.Size(491, 20);
            this.txtBox_WchRoes.TabIndex = 2;
            // 
            // txtBox_DakisOutput
            // 
            this.txtBox_DakisOutput.Location = new System.Drawing.Point(126, 139);
            this.txtBox_DakisOutput.Name = "txtBox_DakisOutput";
            this.txtBox_DakisOutput.Size = new System.Drawing.Size(491, 20);
            this.txtBox_DakisOutput.TabIndex = 2;
            // 
            // txtBox_WchDakis
            // 
            this.txtBox_WchDakis.Location = new System.Drawing.Point(126, 104);
            this.txtBox_WchDakis.Name = "txtBox_WchDakis";
            this.txtBox_WchDakis.Size = new System.Drawing.Size(491, 20);
            this.txtBox_WchDakis.TabIndex = 2;
            // 
            // txtBox_ReadFldr
            // 
            this.txtBox_ReadFldr.Location = new System.Drawing.Point(126, 69);
            this.txtBox_ReadFldr.Name = "txtBox_ReadFldr";
            this.txtBox_ReadFldr.Size = new System.Drawing.Size(491, 20);
            this.txtBox_ReadFldr.TabIndex = 2;
            // 
            // txtBox_WchFldr
            // 
            this.txtBox_WchFldr.Location = new System.Drawing.Point(126, 34);
            this.txtBox_WchFldr.Name = "txtBox_WchFldr";
            this.txtBox_WchFldr.Size = new System.Drawing.Size(491, 20);
            this.txtBox_WchFldr.TabIndex = 2;
            // 
            // but_SetRoesOut
            // 
            this.but_SetRoesOut.Location = new System.Drawing.Point(19, 203);
            this.but_SetRoesOut.Name = "but_SetRoesOut";
            this.but_SetRoesOut.Size = new System.Drawing.Size(101, 30);
            this.but_SetRoesOut.TabIndex = 1;
            this.but_SetRoesOut.Text = "Roes Output";
            this.but_SetRoesOut.UseVisualStyleBackColor = true;
            this.but_SetRoesOut.Click += new System.EventHandler(this.but_SetFldr_Click);
            // 
            // but_SetWchRoes
            // 
            this.but_SetWchRoes.Location = new System.Drawing.Point(19, 168);
            this.but_SetWchRoes.Name = "but_SetWchRoes";
            this.but_SetWchRoes.Size = new System.Drawing.Size(101, 30);
            this.but_SetWchRoes.TabIndex = 1;
            this.but_SetWchRoes.Text = "Watched Roes";
            this.but_SetWchRoes.UseVisualStyleBackColor = true;
            this.but_SetWchRoes.Click += new System.EventHandler(this.but_SetFldr_Click);
            // 
            // but_SetDakisOut
            // 
            this.but_SetDakisOut.Location = new System.Drawing.Point(19, 133);
            this.but_SetDakisOut.Name = "but_SetDakisOut";
            this.but_SetDakisOut.Size = new System.Drawing.Size(101, 30);
            this.but_SetDakisOut.TabIndex = 1;
            this.but_SetDakisOut.Text = "Dakis Output";
            this.but_SetDakisOut.UseVisualStyleBackColor = true;
            this.but_SetDakisOut.Click += new System.EventHandler(this.but_SetFldr_Click);
            // 
            // but_ReadFldr
            // 
            this.but_ReadFldr.Location = new System.Drawing.Point(19, 63);
            this.but_ReadFldr.Name = "but_ReadFldr";
            this.but_ReadFldr.Size = new System.Drawing.Size(101, 30);
            this.but_ReadFldr.TabIndex = 1;
            this.but_ReadFldr.Text = "Read Folder";
            this.but_ReadFldr.UseVisualStyleBackColor = true;
            this.but_ReadFldr.Click += new System.EventHandler(this.but_SetFldr_Click);
            // 
            // but_SetWchDakis
            // 
            this.but_SetWchDakis.Location = new System.Drawing.Point(19, 98);
            this.but_SetWchDakis.Name = "but_SetWchDakis";
            this.but_SetWchDakis.Size = new System.Drawing.Size(101, 30);
            this.but_SetWchDakis.TabIndex = 1;
            this.but_SetWchDakis.Text = "Watched Dakis";
            this.but_SetWchDakis.UseVisualStyleBackColor = true;
            this.but_SetWchDakis.Click += new System.EventHandler(this.but_SetFldr_Click);
            // 
            // but_SetWchFldr
            // 
            this.but_SetWchFldr.Location = new System.Drawing.Point(19, 28);
            this.but_SetWchFldr.Name = "but_SetWchFldr";
            this.but_SetWchFldr.Size = new System.Drawing.Size(101, 30);
            this.but_SetWchFldr.TabIndex = 1;
            this.but_SetWchFldr.Text = "Watched Folder";
            this.but_SetWchFldr.UseVisualStyleBackColor = true;
            this.but_SetWchFldr.Click += new System.EventHandler(this.but_SetFldr_Click);
            // 
            // but_Save
            // 
            this.but_Save.Location = new System.Drawing.Point(516, 244);
            this.but_Save.Name = "but_Save";
            this.but_Save.Size = new System.Drawing.Size(101, 23);
            this.but_Save.TabIndex = 3;
            this.but_Save.Text = "Save";
            this.but_Save.UseVisualStyleBackColor = true;
            this.but_Save.Click += new System.EventHandler(this.but_Save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 329);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_Settings.ResumeLayout(false);
            this.tab_Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button but_NewRoesOrder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_NewOrders;
        private System.Windows.Forms.TabPage tab_Settings;
        private System.Windows.Forms.Button but_SetWchFldr;
        private System.Windows.Forms.TextBox txtBox_WchRoes;
        private System.Windows.Forms.TextBox txtBox_DakisOutput;
        private System.Windows.Forms.TextBox txtBox_WchDakis;
        private System.Windows.Forms.TextBox txtBox_WchFldr;
        private System.Windows.Forms.Button but_SetWchRoes;
        private System.Windows.Forms.Button but_SetDakisOut;
        private System.Windows.Forms.Button but_SetWchDakis;
        private System.Windows.Forms.TextBox txtBox_RoesOutput;
        private System.Windows.Forms.Button but_SetRoesOut;
        private System.Windows.Forms.TextBox txtBox_ReadFldr;
        private System.Windows.Forms.Button but_ReadFldr;
        private System.Windows.Forms.Button but_Save;
    }
}

