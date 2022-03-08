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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;

namespace SalsOfflineReports.Forms
{
    public partial class FrmPrintContractForm : Form
    {
        public FrmPrintContractForm()
        {
            InitializeComponent();
        }

        private PrintContractDetails condetails = new PrintContractDetails();
        private BookMenusViewModel bm = new BookMenusViewModel();
        private AddonsViewModel add = new AddonsViewModel();
        private ClsServices clsservices=new ClsServices();
        private void FrmPrintContractForm_Load(object sender, EventArgs e)
        {

            try
            {

                var transId = ClassVariables.TransactionCode;

                List<PrintContractDetails> conDetails = new List<PrintContractDetails>();
                List<BookMenusViewModel> conBookMenus = new List<BookMenusViewModel>();
                List<AddonsViewModel> addons = new List<AddonsViewModel>();

                var cryRep = new ReportDocument();
                TableLogOnInfos tbloginfos = new TableLogOnInfos();
                ConnectionInfo crConinfo = new ConnectionInfo();

                string reportName = "ReportContract2Details.rpt";

                string report = Utilities.ReportPath(reportName);

                cryRep.Load(report);

                SqlConnectionStringBuilder cnstrbuilding = new SqlConnectionStringBuilder(Utilities.DBGateway());


                crConinfo.ServerName = cnstrbuilding.DataSource;
                crConinfo.DatabaseName = cnstrbuilding.InitialCatalog;
                crConinfo.UserID = cnstrbuilding.UserID;
                crConinfo.Password = cnstrbuilding.Password;


                var reportSections = cryRep.ReportDefinition.Sections;


                foreach (Section section in reportSections)
                {
                    var crReportObjects = section.ReportObjects;

                    foreach (ReportObject crreportObject in crReportObjects)
                    {

                        if (crreportObject.Kind != ReportObjectKind.SubreportObject)
                            continue;

                        var crSubreportObject = (SubreportObject)crreportObject;
                        var crsubReportDocument = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName);
                        var crDatabase = crsubReportDocument.Database;
                        var crTables = crDatabase.Tables;

                        //var tbloginfos = new TableLogOnInfos();


                        foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables)
                        {

                            var crTableLogOnInfo = crTable.LogOnInfo;
                            crTableLogOnInfo.ConnectionInfo = crConinfo;
                            crTableLogOnInfo.ConnectionInfo.IntegratedSecurity = true;
                            crTable.ApplyLogOnInfo(crTableLogOnInfo);

                        }

                    }
                }



                var cryTables = cryRep.Database.Tables;

                foreach (CrystalDecisions.CrystalReports.Engine.Table cryTable in cryTables)
                {
                    var tbloginfo = cryTable.LogOnInfo;
                    tbloginfo.ConnectionInfo = crConinfo;
                    tbloginfo.ConnectionInfo.IntegratedSecurity = true;
                    cryTable.ApplyLogOnInfo(tbloginfo);
                }


                var btype = clsservices.Getbookingtype(transId);

                //conDetails = (from c in condetails.GetContractDetails() select c).ToList();

                conDetails = condetails.GetContractDetailsById(transId).ToList();
                //where c.transId == Convert.ToInt32(paramTransId)
                //select c).ToList();


                conBookMenus = bm.LisofMenusBook().Where(x => x.transId == Convert.ToInt32(transId)).ToList();

                addons = add.ListofAddons().Where(x => x.TransId == Convert.ToInt32(transId)).ToList();



                //repcontract.SetDataSource(conDetails);



                cryRep.Database.Tables[0].SetDataSource(conDetails);
                cryRep.Database.Tables[1].SetDataSource(conBookMenus);
                cryRep.Database.Tables[2].SetDataSource(addons);


                cryRep.SetParameterValue("booktype", btype);


                crViewerPrintContract.ReportSource = cryRep;
                crViewerPrintContract.Refresh();



            }
            catch (CrystalDecisions.CrystalReports.Engine.EngineException ex)
            {

                MessageBox.Show(String.Format("ERROR ENCOUNTERED"), String.Format(ex.Message.ToString()),
                    MessageBoxButtons.OK);
            }

        }

        private void crViewerPrintContract_Load(object sender, EventArgs e)
        {

        }
    }
}
