using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace SalsOfflineReports.Class
{
    public static class Utilities
    {
        public static string getfullname(string last, string first, string middle)
        {
            string conCat = " ";

            if (!string.IsNullOrEmpty(last))
            {
                conCat += last + " ,";
            }
            if (!string.IsNullOrEmpty(first))
            {
                conCat += first + " ";
            }

            if (!string.IsNullOrEmpty(middle))
            {
                conCat += middle + " ";
            }

            return conCat.Trim();
        }

        public static string getfullname_nonreverse(string last, string first, string middle)
        {
            string conCat = " ";


            if (!string.IsNullOrEmpty(first))
            {
                conCat += first.Trim() + " ";
            }
            if (!string.IsNullOrEmpty(middle))
            {
                conCat += middle.Trim() + ". ";
            }

            if (!string.IsNullOrEmpty(last))
            {
                conCat += last.Trim() + " ";
            }


            return conCat.Trim();
        }

        public static string ReportPath(string reportname)
        {

            var directoryContainingTheExecutable = Path.GetDirectoryName(Application.ExecutablePath);
            directoryContainingTheExecutable += @"\Reports\";
            var fullReportPath = Path.Combine(directoryContainingTheExecutable, reportname);

            return (fullReportPath);

        }

        public static string DBGateway()
        {

            ConnectionStringSettings dbconnString = ConfigurationManager.ConnectionStrings["PegasusEntities2"];

            return dbconnString.ConnectionString;

        }

    }
}
