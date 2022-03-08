using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalsOfflineReports.Data;

namespace SalsOfflineReports.Class
{
    public class RefundsViewModel
    {
        public long Rf_id { get; set; }
        public DateTime rfDate { get; set; }
        public int trn_Id { get; set; }
        public string rf_Reason { get; set; }
        public decimal rf_Amount { get; set; }
        public decimal rfDeduction { get; set; }
        public decimal rfNetAmount { get; set; }
        public int rf_Stat { get; set; }



        public IQueryable<RefundsViewModel> GetRefunds(IQueryable<Refund> refunds)
        {
            return refunds.Select(t => new RefundsViewModel()
            {
                Rf_id = t.Rf_id,
                rfDate = (DateTime) t.rfDate,
                trn_Id = (int) t.trn_Id,
                rf_Reason = t.rf_Reason,
                rf_Amount = (decimal) t.rf_Amount,
                rfDeduction = (decimal) t.rfDeduction,
                rfNetAmount = (decimal) t.rfNetAmount,
                rf_Stat = (int) t.rf_Stat
            });
        }
    }
}
