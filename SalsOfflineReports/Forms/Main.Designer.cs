namespace SalsOfflineReports.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.contractFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menusDistributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentVouchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.refundVouchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contractFormToolStripMenuItem,
            this.menusDistributionToolStripMenuItem,
            this.paymentVouchToolStripMenuItem,
            this.refundVouchToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(899, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // contractFormToolStripMenuItem
            // 
            this.contractFormToolStripMenuItem.Name = "contractFormToolStripMenuItem";
            this.contractFormToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.contractFormToolStripMenuItem.Text = "Contract Form";
            this.contractFormToolStripMenuItem.Click += new System.EventHandler(this.contractFormToolStripMenuItem_Click);
            // 
            // menusDistributionToolStripMenuItem
            // 
            this.menusDistributionToolStripMenuItem.Name = "menusDistributionToolStripMenuItem";
            this.menusDistributionToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.menusDistributionToolStripMenuItem.Text = "Menus Requisation";
            this.menusDistributionToolStripMenuItem.Click += new System.EventHandler(this.menusDistributionToolStripMenuItem_Click);
            // 
            // paymentVouchToolStripMenuItem
            // 
            this.paymentVouchToolStripMenuItem.Name = "paymentVouchToolStripMenuItem";
            this.paymentVouchToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.paymentVouchToolStripMenuItem.Text = "Payment Vouch";
            this.paymentVouchToolStripMenuItem.Click += new System.EventHandler(this.paymentVouchToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::SalsOfflineReports.Properties.Resources.salslogo_JPEG;
            this.pictureBox1.Location = new System.Drawing.Point(0, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(899, 565);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // refundVouchToolStripMenuItem
            // 
            this.refundVouchToolStripMenuItem.Name = "refundVouchToolStripMenuItem";
            this.refundVouchToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.refundVouchToolStripMenuItem.Text = "Refund Vouch";
            this.refundVouchToolStripMenuItem.Click += new System.EventHandler(this.refundVouchToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 593);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SALS E-BOOKING REPORTS ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contractFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menusDistributionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentVouchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refundVouchToolStripMenuItem;
    }
}