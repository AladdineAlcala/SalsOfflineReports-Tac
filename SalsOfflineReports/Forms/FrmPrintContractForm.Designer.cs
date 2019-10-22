namespace SalsOfflineReports.Forms
{
    partial class FrmPrintContractForm
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
            this.crViewerPrintContract = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crViewerPrintContract
            // 
            this.crViewerPrintContract.ActiveViewIndex = -1;
            this.crViewerPrintContract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crViewerPrintContract.Cursor = System.Windows.Forms.Cursors.Default;
            this.crViewerPrintContract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crViewerPrintContract.Location = new System.Drawing.Point(0, 0);
            this.crViewerPrintContract.Name = "crViewerPrintContract";
            this.crViewerPrintContract.Size = new System.Drawing.Size(1089, 500);
            this.crViewerPrintContract.TabIndex = 0;
            this.crViewerPrintContract.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crViewerPrintContract.Load += new System.EventHandler(this.crViewerPrintContract_Load);
            // 
            // FrmPrintContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 500);
            this.Controls.Add(this.crViewerPrintContract);
            this.Name = "FrmPrintContractForm";
            this.Text = "FrmPrintContractForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrintContractForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crViewerPrintContract;
    }
}