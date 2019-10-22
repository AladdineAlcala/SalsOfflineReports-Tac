using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalsOfflineReports.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Version version = Assembly.GetExecutingAssembly().GetName().Version;

            Text = Text + ' ' + @"Ver" + ' ' + version.Major + '.' + version.Minor + @" ( build " + version.Build + @")";
            //Text = Application.ProductVersion;
        }

        private void cmdPrintContractDetails_Click(object sender, EventArgs e)
        {
            FrmTransNo  frmTransNo=new FrmTransNo();
            frmTransNo.StartPosition=FormStartPosition.CenterScreen;
            frmTransNo.ShowDialog();
        }

        private void btnPrintMenuDistribution_Click(object sender, EventArgs e)
        {
            FrmMenusDistTransNo frmMenusDistTransNo=new FrmMenusDistTransNo();
            frmMenusDistTransNo.StartPosition=FormStartPosition.CenterScreen;
            frmMenusDistTransNo.ShowDialog();
        }

        private void btncontractforfunction_Click(object sender, EventArgs e)
        {
            FrmContractforFunctionSearchTrans frmContractforFunctionSearch=new FrmContractforFunctionSearchTrans();
            frmContractforFunctionSearch.StartPosition = FormStartPosition.CenterScreen;
            frmContractforFunctionSearch.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void contractFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTransNo frmTransNo = new FrmTransNo();
            frmTransNo.StartPosition = FormStartPosition.CenterScreen;
            frmTransNo.ShowDialog();
        }

        private void cmdPrintContractDetails_Click_1(object sender, EventArgs e)
        {

        }

        private void btnPrintMenuDistribution_Click_1(object sender, EventArgs e)
        {

        }

        private void menusDistributionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMenusDistTransNo frmMenusDistTransNo = new FrmMenusDistTransNo();
            frmMenusDistTransNo.StartPosition = FormStartPosition.CenterScreen;
            frmMenusDistTransNo.ShowDialog();
        }

        private void paymentVouchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSearchPaymentNo searchPayment=new FrmSearchPaymentNo();
            searchPayment.StartPosition =FormStartPosition.CenterScreen;
            searchPayment.ShowDialog();
        }
    }
}
