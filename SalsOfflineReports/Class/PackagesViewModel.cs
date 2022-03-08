using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalsOfflineReports.Data;

namespace SalsOfflineReports.Class
{
    public class PackagesViewModel
    {
        public int p_id { get; set; }
        public string p_type { get; set; }
        public string p_descripton { get; set; }
        public decimal p_amountPax { get; set; }
        public int nopax_id { get; set; }
        public int p_min { get; set; }
        public bool isActive { get; set; }


        public IQueryable<PackagesViewModel> GetPackages(IQueryable<Package> package)
        {
            return package.Select(t => new PackagesViewModel()
            {
                p_id = t.p_id,
                p_type = t.p_type,
                p_descripton = t.p_descripton,
                p_amountPax = (decimal) t.p_amountPax,
                nopax_id = (int) t.nopax_id,
                p_min = (int) t.p_min,
                isActive = t.isActive
            });
        }
    }
}
