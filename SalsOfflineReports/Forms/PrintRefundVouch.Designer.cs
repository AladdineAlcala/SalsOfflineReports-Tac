namespace SalsOfflineReports.Forms
{
    partial class PrintRefundVouch
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
            this.crViewerRefundVouch = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crViewerRefundVouch
            // 
            this.crViewerRefundVouch.ActiveViewIndex = -1;
            this.crViewerRefundVouch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crViewerRefundVouch.Cursor = System.Windows.Forms.Cursors.Default;
            this.crViewerRefundVouch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crViewerRefundVouch.Location = new System.Drawing.Point(0, 0);
            this.crViewerRefundVouch.Margin = new System.Windows.Forms.Padding(4);
            this.crViewerRefundVouch.Name = "crViewerRefundVouch";
            this.crViewerRefundVouch.ShowLogo = false;
            this.crViewerRefundVouch.Size = new System.Drawing.Size(1520, 732);
            this.crViewerRefundVouch.TabIndex = 2;
            this.crViewerRefundVouch.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // PrintRefundVouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 732);
            this.Controls.Add(this.crViewerRefundVouch);
            this.Name = "PrintRefundVouch";
            this.Text = "PrintRefundVouch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrintRefundVouch_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crViewerRefundVouch;
    }
}