namespace SalsOfflineReports.Forms
{
    partial class FrmPrintPaymentVouch
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
            this.crViewerPaymentVouch = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crViewerPaymentVouch
            // 
            this.crViewerPaymentVouch.ActiveViewIndex = -1;
            this.crViewerPaymentVouch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crViewerPaymentVouch.Cursor = System.Windows.Forms.Cursors.Default;
            this.crViewerPaymentVouch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crViewerPaymentVouch.Location = new System.Drawing.Point(0, 0);
            this.crViewerPaymentVouch.Name = "crViewerPaymentVouch";
            this.crViewerPaymentVouch.ShowLogo = false;
            this.crViewerPaymentVouch.Size = new System.Drawing.Size(913, 423);
            this.crViewerPaymentVouch.TabIndex = 1;
            this.crViewerPaymentVouch.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmPrintPaymentVouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 423);
            this.Controls.Add(this.crViewerPaymentVouch);
            this.Name = "FrmPrintPaymentVouch";
            this.Text = "FrmPrintPaymentVouch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrintPaymentVouch_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crViewerPaymentVouch;
    }
}