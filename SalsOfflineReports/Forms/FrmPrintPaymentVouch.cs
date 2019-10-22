using SalsOfflineReports.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SalsOfflineReports.Forms
{
    public partial class FrmPrintPaymentVouch : Form
    {
        public FrmPrintPaymentVouch()
        {
            InitializeComponent();
        }
        private PrintContractDetails condetails = new PrintContractDetails();
        private clsPayables cpayables =new clsPayables();
        private clsRecievableDetails rcvDetails=new clsRecievableDetails();

        private void FrmPrintPaymentVouch_Load(object sender, EventArgs e)
        {

            var transId = ClassVariables.TransactionCode;
            var paymNo = ClassVariables.Paymentcode;

            List<PrintContractDetails> conDetails = new List<PrintContractDetails>();
            List<clsPayables> payablelist=new List<clsPayables>();
            try
            {

                ReportDocument cryrep = new ReportDocument();
                TableLogOnInfos tbloginfos = new TableLogOnInfos();
                ConnectionInfo crConinfo = new ConnectionInfo();

                string reportName = "PrintPaymentVouch.rpt";

                string report = Utilities.ReportPath(reportName);

                cryrep.Load(report);


                SqlConnectionStringBuilder cnstrbuilding = new SqlConnectionStringBuilder(Utilities.DBGateway());


                crConinfo.ServerName = cnstrbuilding.DataSource;
                crConinfo.DatabaseName = cnstrbuilding.InitialCatalog;
                crConinfo.UserID = cnstrbuilding.UserID;
                crConinfo.Password = cnstrbuilding.Password;
                var cryTables = cryrep.Database.Tables;



                foreach (CrystalDecisions.CrystalReports.Engine.Table cryTable in cryTables)
                {
                    var tbloginfo = cryTable.LogOnInfo;
                    tbloginfo.ConnectionInfo = crConinfo;
                    tbloginfo.ConnectionInfo.IntegratedSecurity = true;
                    cryTable.ApplyLogOnInfo(tbloginfo);
                }

                conDetails = (from c in condetails.GetContractDetails() select c).ToList();

                conDetails = conDetails.Where(x => x.transId == Convert.ToInt32(transId)).ToList();

                payablelist = (from pmt in cpayables.getPayment().ToList() select pmt).ToList();

                var payable = payablelist.Where(p => p.payNo == paymNo).ToList();

                var paydate = payablelist.FirstOrDefault(x => x.payNo == paymNo).dateofpayment;

                decimal totalPackageAmountDue = rcvDetails.getTotalPackageAmount(Convert.ToInt32(transId));
                decimal totalPayment = rcvDetails.GetTotalPayments(Convert.ToInt32(transId));
                var discount = rcvDetails.Get_bookingDiscountbyTrans(transId, totalPackageAmountDue);


                cryrep.Database.Tables[0].SetDataSource(conDetails);
                cryrep.Database.Tables[1].SetDataSource(payable);

                cryrep.SetParameterValue("pmtNo", paymNo);
                cryrep.SetParameterValue("paymdate", paydate);
                cryrep.SetParameterValue("PrevPayment", totalPayment);
                cryrep.SetParameterValue("totalPackageAmt", totalPackageAmountDue);
                cryrep.SetParameterValue("Discounted", discount);
                

                crViewerPaymentVouch.ReportSource = cryrep;
                crViewerPaymentVouch.Refresh();



            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

        }
    }
}
