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
            this.SuspendLayout();
            // 
            // but_NewRoesOrder
            // 
            this.but_NewRoesOrder.Location = new System.Drawing.Point(12, 51);
            this.but_NewRoesOrder.Name = "but_NewRoesOrder";
            this.but_NewRoesOrder.Size = new System.Drawing.Size(239, 55);
            this.but_NewRoesOrder.TabIndex = 0;
            this.but_NewRoesOrder.Text = "New Roes Order";
            this.but_NewRoesOrder.UseVisualStyleBackColor = true;
            this.but_NewRoesOrder.Click += new System.EventHandler(this.but_NewRoesOrder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.but_NewRoesOrder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button but_NewRoesOrder;
    }
}

