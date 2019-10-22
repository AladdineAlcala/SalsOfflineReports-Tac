namespace SalsOfflineReports.Forms
{
    partial class FrmContractforFunction
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
            this.cryContractforFunction = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cryContractforFunction
            // 
            this.cryContractforFunction.ActiveViewIndex = -1;
            this.cryContractforFunction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cryContractforFunction.Cursor = System.Windows.Forms.Cursors.Default;
            this.cryContractforFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cryContractforFunction.Location = new System.Drawing.Point(0, 0);
            this.cryContractforFunction.Name = "cryContractforFunction";
            this.cryContractforFunction.Size = new System.Drawing.Size(1223, 453);
            this.cryContractforFunction.TabIndex = 0;
            this.cryContractforFunction.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.cryContractforFunction.Load += new System.EventHandler(this.cryContractforFunction_Load);
            // 
            // FrmContractforFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 453);
            this.Controls.Add(this.cryContractforFunction);
            this.Name = "FrmContractforFunction";
            this.Text = "FrmContractforFunction";
            this.Load += new System.EventHandler(this.FrmContractforFunction_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cryContractforFunction;
    }
}