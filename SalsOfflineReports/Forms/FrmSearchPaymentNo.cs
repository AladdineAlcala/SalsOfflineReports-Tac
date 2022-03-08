using SalsOfflineReports.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalsOfflineReports.Data;

namespace SalsOfflineReports.Forms
{
    public partial class FrmSearchPaymentNo : Form
    {

        private PegasusEntities dbEntities = new PegasusEntities();
        public FrmSearchPaymentNo()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if(txt_payNo.Text.Trim() == String.Empty)
            {
                MessageBox.Show(@"Invalid Operation", @" Record Does Not Exist", MessageBoxButtons.OK);
                txt_payNo.Focus();
            }
            else
            {

              


                var isrecordexist = dbEntities.Payments
                    .FirstOrDefault(x => x.payNo == txt_payNo.Text.Trim());

                if (isrecordexist != null)
                {
                    ClassVariables.Paymentcode = txt_payNo.Text.Trim();
                    ClassVariables.TransactionCode = Convert.ToInt32(isrecordexist.trn_Id);

                    this.Close();
                   
                    FrmPrintPaymentVouch frmpayAVouch=new FrmPrintPaymentVouch();
                    frmpayAVouch.StartPosition = FormStartPosition.CenterParent;
                    frmpayAVouch.ShowDialog();
                }
                else
                {
                  
                    MessageBox.Show(@"Not a valid Payment transaction No.", @" Transaction No. Not Found", MessageBoxButtons.OK);
                    txt_payNo.Focus();
                }

            }
        }
    }
}
