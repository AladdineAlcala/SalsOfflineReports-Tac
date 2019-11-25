using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalsOfflineReports.Class
{
    public class ClsServices
    {
        private readonly PegasusEntities dbEntities;
        public ClsServices()
        {
            dbEntities = new PegasusEntities();

        }

        public PackagesRangeBelowMin IsBelowMinimumPax(int? noofPax)
        {

            return dbEntities.PackagesRangeBelowMins.FirstOrDefault(x => x.pMax >= noofPax && x.pMin <= noofPax); ;

        }

      

        public decimal GetBelowminPax(int? noofpax)
        {
        
            decimal amount = 0;

                var amtAdded = dbEntities.PackagesRangeBelowMins.FirstOrDefault(x => x.pMax >= noofpax && x.pMin <= noofpax); ;
                if (amtAdded != null)
                {
                    amount = (decimal)amtAdded.Amt_added;
                }
               
            
            return amount;

        }

        public decimal GetCateringDiscount(int transId)
        {
            decimal amount = 0;

            var bookings = dbEntities.Bookings.Find(transId);

            if (bookings != null)
            {
                var package = dbEntities.Packages.FirstOrDefault(p => p.p_id == bookings.p_id);

            
                    if (package.p_type.Trim() != "vip")
                    {
                        var amountdeduc =
                            dbEntities.CateringDiscounts.FirstOrDefault(x => x.DiscPaxMax >= bookings.noofperson && x.DiscPaxMin <= bookings.noofperson);
                        if (amountdeduc != null)
                        {
                            amount = Convert.ToDecimal(amountdeduc.Amount);
                        }
                    }
                
            }

            return amount;
        }


        public string Getbookingtype(int transId)
        {
            string btype = string.Empty;

            var booking = (from b in dbEntities.Bookings where b.trn_Id == transId select b).FirstOrDefault();


            if (booking.booktype != null)
            {
                if (booking.booktype.Trim() == "ins")
                {
                    btype = "Inside";

                }
                else
                {
                    btype = "Outside";
                }
            }
            else
            {
                btype = "";
            }
          
            return btype;

        }
    }
}
