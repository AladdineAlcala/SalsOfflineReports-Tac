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
    public partial class FrmContractforFunctionSearchTrans : Form
    {
        public FrmContractforFunctionSearchTrans()
        {
            InitializeComponent();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {

            var dbEntities=new PegasusEntities();
            if (txt_transNo.Text == String.Empty)
            {
                MessageBox.Show(@"No Transaction No. Found", @" Transaction No. Not Found", MessageBoxButtons.OK);
                txt_transNo.Focus();
            }
            else
            {

                int trNo = Convert.ToInt32(txt_transNo.Text.Trim());


                var isrecordexist = dbEntities.Bookings
                    .FirstOrDefault(x => x.trn_Id == trNo);

                if (isrecordexist != null)
                {
                    ClassVariables.TransactionCode = Convert.ToInt32(txt_transNo.Text);

                    this.Close();
                    FrmContractforFunction frmcontractformprint = new FrmContractforFunction();
                    frmcontractformprint.StartPosition = FormStartPosition.CenterParent;
                    frmcontractformprint.ShowDialog();
                }
                else
                {
                    MessageBox.Show(@"Invalid Operation", @" Record Does Not Exist", MessageBoxButtons.OK);
                    txt_transNo.Focus();
                }

            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
