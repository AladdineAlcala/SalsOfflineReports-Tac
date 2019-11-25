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

namespace SalsOfflineReports.Forms
{
    public partial class FrmTransNo : Form
    {
        public FrmTransNo()
        {
            InitializeComponent();
        }

        private PegasusEntities dbEntities=new PegasusEntities();
        
     
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTransNo_Load(object sender, EventArgs e)
        {

        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
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
                    FrmPrintContractForm frmcontractformprint = new FrmPrintContractForm();
                    frmcontractformprint.StartPosition = FormStartPosition.CenterParent;
                    frmcontractformprint.ShowDialog();
                }
                else
                {
                    MessageBox.Show(@"Invalid Transaction Code", @" Record Does Not Exist", MessageBoxButtons.OK);
                    txt_transNo.Focus();
                }
               
            }
        }

        private void txt_transNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                txt_transNo.Focus();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
