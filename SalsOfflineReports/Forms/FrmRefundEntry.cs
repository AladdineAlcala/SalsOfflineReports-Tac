using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalsOfflineReports.Class;
using SalsOfflineReports.Data;

namespace SalsOfflineReports.Forms
{
    public partial class FrmRefundEntry : Form
    {
        public FrmRefundEntry()
        {
            InitializeComponent();
        }
        private PegasusEntities dbEntities=new PegasusEntities();

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (txt_refundentryNo.Text.Trim() == String.Empty)
            {
                MessageBox.Show(@"Invalid Operation", @" Record Does Not Exist", MessageBoxButtons.OK);
                txt_refundentryNo.Focus();
            }
            else
            {

                var refundentryNo = Convert.ToInt32(txt_refundentryNo.Text);

                var refundentryexist = dbEntities.Refunds.FirstOrDefault(t =>t.Rf_id == refundentryNo);

                if (refundentryexist != null)
                {
                    ClassVariables.RefundEntryNo = Convert.ToInt32(refundentryNo);
                    ClassVariables.TransactionCode = Convert.ToInt32(refundentryexist.trn_Id);

                    this.Close();

                    PrintRefundVouch printvouch =
                        new PrintRefundVouch() {StartPosition = FormStartPosition.CenterParent};
                    printvouch.ShowDialog();
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
