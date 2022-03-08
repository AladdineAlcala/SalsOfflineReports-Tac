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
using SalsOfflineReports.Data;
using SalsOfflineReports.Reports;

namespace SalsOfflineReports.Forms
{
    public partial class PrintRefundVouch : Form
    {
        public PrintRefundVouch()
        {
            InitializeComponent();
        }

        private readonly PegasusEntities _dbEntities=new PegasusEntities();
        private readonly BookingsViewModel bookingsview=new BookingsViewModel();
        private readonly RefundsViewModel refundsview=new RefundsViewModel();
        private readonly CustomerViewModel customerview=new CustomerViewModel();
        private readonly PackagesViewModel packagesview=new PackagesViewModel();

        private void PrintRefundVouch_Load(object sender, EventArgs e)
        {
            var transId = ClassVariables.TransactionCode;
            var rfId = ClassVariables.RefundEntryNo;
            
            List<CustomerTransViewModel> conDetails = new List<CustomerTransViewModel>();
            
             PrintRefundViewModel printRefund=new PrintRefundViewModel();
            try
            {

                ReportDocument cryrep= new Print_RefundVouch();

                //var cusid = _dbEntities.Bookings.FirstOrDefault(t => t.trn_Id == transId).c_Id;

                cryrep.Database.Tables["Refunds"].SetDataSource(refundsview.GetRefunds(_dbEntities.Refunds).Where(t => t.Rf_id == rfId).ToList());
                cryrep.Database.Tables["Bookings"].SetDataSource(bookingsview.GetBooking(_dbEntities.Bookings).Where(t=>t.trn_Id==transId).ToList());
                cryrep.Database.Tables["Customer"].SetDataSource(customerview.GetCustomers(_dbEntities.Customers).ToList());
                cryrep.Database.Tables["Packages"].SetDataSource(packagesview.GetPackages(_dbEntities.Packages).ToList());



                //cryrep.SetParameterValue("pmtNo", paymNo);
                //cryrep.SetParameterValue("paymdate", paydate);
                //cryrep.SetParameterValue("addons", addons);
                //cryrep.SetParameterValue("extlocation", locextcharge);
                //cryrep.SetParameterValue("PrevPayment", totalPayment);
                //cryrep.SetParameterValue("totalPackageAmt", totalPackageAmountDue);
                //cryrep.SetParameterValue("Discounted", discount);


                crViewerRefundVouch.ReportSource = cryrep;
                crViewerRefundVouch.Refresh();



            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

        }
    }
}
