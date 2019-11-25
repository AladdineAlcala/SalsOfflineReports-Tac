namespace SalsOfflineReports.Forms
{
    partial class FrmRefundEntry
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_refundentryNo = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_refundentryNo);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(475, 94);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter Refund Entry No.";
            // 
            // txt_refundentryNo
            // 
            this.txt_refundentryNo.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txt_refundentryNo.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_refundentryNo.Location = new System.Drawing.Point(52, 37);
            this.txt_refundentryNo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_refundentryNo.Name = "txt_refundentryNo";
            this.txt_refundentryNo.Size = new System.Drawing.Size(387, 29);
            this.txt_refundentryNo.TabIndex = 0;
            this.txt_refundentryNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(333, 128);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(151, 33);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "C&lose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(168, 128);
            this.cmdPrint.Margin = new System.Windows.Forms.Padding(4);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(151, 33);
            this.cmdPrint.TabIndex = 6;
            this.cmdPrint.Text = "&Show Record";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // FrmRefundEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 171);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmRefundEntry";
            this.Text = "RefundEntry";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_refundentryNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button cmdPrint;
    }
}