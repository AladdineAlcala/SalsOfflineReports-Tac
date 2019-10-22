using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalsOfflineReports.Class
{
    class clsRecievableDetails
    {
        private PegasusEntities dbEntities=new PegasusEntities();
       
        public decimal getTotalPackageAmount(int transId)
        {
            decimal totalpayables = 0;
            decimal packageDue = 0;
            decimal addonAmount = 0;
            decimal locationextAmount = 0;
            decimal packageAmount = 0;
            //decimal belowminPax = 0;
            decimal discounted = 0;
            decimal cateringdiscount = 0;

            var bookings = (from b in dbEntities.Bookings select b).FirstOrDefault(x => x.trn_Id == transId);



            try
            {

                if (bookings != null)
                {
                    packageAmount = this.GetPackageAmount(bookings.p_id);

                    int totalheads = Convert.ToInt32(bookings.noofperson);

                    packageDue = totalheads * packageAmount;

                    addonAmount = this.GetAddons(transId);

                    locationextAmount = (this.Get_extendedAmountLoc(transId) * totalheads);

                    //belowminPax = this.GetBelowMinPaxAmount(totalheads) * Convert.ToInt32(totalheads);

                    cateringdiscount = this.GetCateringDiscount(transId);

                    totalpayables = packageDue + addonAmount + locationextAmount - cateringdiscount;

                    discounted = this.Get_bookingDiscountbyTrans(transId, totalpayables);

                        
                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return totalpayables;
        }


        public decimal GetPackageAmount(int? packageId)
        {
           
                return Convert.ToDecimal(dbEntities.Packages.FirstOrDefault(x => x.p_id == packageId).p_amountPax);
        }

        public decimal GetAddons(int transId)
        {
            var addonslist = dbEntities.BookingAddons.Where(x => x.trn_Id == transId).ToList();

            return addonslist.Sum(y => Convert.ToDecimal(y.AddonAmount));
        }

        public decimal Get_extendedAmountLoc(int transId)
        {
            decimal extAmt = 0;
            var booking =dbEntities.Bookings.FirstOrDefault(x => x.trn_Id == transId);

            if (booking.Package.p_type.Trim() != "vip" && booking.extendedAreaId!=null)
            {
                try
                {
                    var list = (from b in dbEntities.Bookings
                        join p in dbEntities.Packages on b.p_id equals p.p_id
                        join pa in dbEntities.PackageAreaCoverages on p.p_id equals pa.p_id
                        where pa.p_id == booking.p_id && pa.aID == booking.extendedAreaId
                        select new
                        {
                            extLocAmount = pa.ext_amount

                        }).FirstOrDefault();


                    if (list != null)
                    {
                        extAmt = Convert.ToDecimal(list.extLocAmount);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
           

            return extAmt;
        }

        public decimal GetBelowMinPaxAmount(int no_of_Pax)
        {

            decimal amt_added = 0;
            dbEntities.Configuration.ProxyCreationEnabled = false;
            //List<PackagesRangeBelowMin> packagerangebelowmin=new List<PackagesRangeBelowMin>();
            PackagesRangeBelowMin packagerangebelowmin = new PackagesRangeBelowMin();

            packagerangebelowmin =
                dbEntities.PackagesRangeBelowMins.FirstOrDefault(x => x.pMax >= no_of_Pax && x.pMin <= no_of_Pax);


            if (packagerangebelowmin != null)
            {
                amt_added = Convert.ToDecimal(packagerangebelowmin.Amt_added);
            }

            return amt_added;
        }

        public decimal Get_bookingDiscountbyTrans(int transId, decimal subtotal)
        {
            decimal totaldisc = 0;

            try
            {

                var hasdiscount = dbEntities.Book_Discount.FirstOrDefault(x => x.trn_Id == transId);

                if (hasdiscount != null)
                {
                    var bookdiscount = dbEntities.Discounts.FirstOrDefault(d => d.disc_Id == hasdiscount.disc_Id);

                    if (bookdiscount != null)
                    {
                        if (bookdiscount.disctype == "percentage")
                        {
                            var percentage = bookdiscount.discount1 / 100;

                            totaldisc = subtotal * Convert.ToDecimal(percentage);

                        }
                        else
                        {
                            totaldisc = Convert.ToDecimal(bookdiscount.discount1);
                        }
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return totaldisc;
        }


        public decimal GetTotalPayments(int transId)
        {
            decimal totalPay = 0;
            try
            {
                var payments = (from p in dbEntities.Payments select p).Where(x => x.trn_Id == transId).ToList();
                totalPay = (decimal)payments.Sum(p => p.amtPay);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return totalPay;
        }

        public decimal GetCateringDiscount(int transid)
        {
            var _dbcontext = new PegasusEntities();
            Booking bookings = new Booking();
            decimal discountedAmount = 0;


            bookings = _dbcontext.Bookings.FirstOrDefault(x => x.trn_Id == transid);

            if (bookings != null)
            {
                var noofpax = bookings.noofperson;

                var amount = this.GetCateringdiscountAmount(Convert.ToInt32(noofpax));
                discountedAmount = Convert.ToDecimal(amount * noofpax);
            }

            return discountedAmount;

        }


        public decimal GetCateringdiscountAmount(int noofPax)
        {
            decimal amount = 0;
            var cateringdiscount =
                dbEntities.CateringDiscounts.FirstOrDefault(x => x.DiscPaxMin <= noofPax && x.DiscPaxMax >= noofPax);

            if (cateringdiscount != null)
            {
                amount = (decimal)cateringdiscount.Amount;
            }

            return amount;
        }

    }
}
