﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalsOfflineReports.Class
{
    class PrintContractDetails
    {
        public int transId { get; set; }
        public string customerfullname { get; set; }
        public string customeraddress { get; set; }
        public string contactno { get; set; }
        public DateTime datetimesched { get; set; }
        public string event_name { get; set; }
        public int noofPax { get; set; }
        public string event_venue { get; set; }
        public string eventcolScheme { get; set; }
        public string typeofService { get; set; }
        public string packagedesc { get; set; }
        public decimal packageamount { get; set; }
        public decimal cateringdiscount { get; set; }
        public decimal dpA { get; set; }
        public decimal fpA { get; set; }

        private PegasusEntities dbEntities=new PegasusEntities();
        private readonly ClsServices service=new ClsServices();

        public IEnumerable<PrintContractDetails> GetContractDetails()
        {
            //  dbEntities.Configuration.ProxyCreationEnabled = false;




            IEnumerable<Booking> bookings = (from c in dbEntities.Bookings select c).ToList();
            List<PrintContractDetails> prn_Contract = new List<PrintContractDetails>();

            try
            {
                prn_Contract = (from booking in bookings
                    join sv in dbEntities.ServiceTypes on booking.typeofservice equals sv.serviceId
                    select new PrintContractDetails()
                    {
                        transId = booking.trn_Id,
                        customerfullname = Utilities.getfullname(booking.Customer.lastname, booking.Customer.firstname, booking.Customer.middle),
                        customeraddress = booking.Customer.address,
                        contactno = booking.Customer.contact1,
                        datetimesched = Convert.ToDateTime(booking.startdate),
                        event_name = booking.occasion,
                        noofPax = Convert.ToInt32(booking.noofperson),
                        event_venue = booking.venue,
                        eventcolScheme = booking.eventcolor,
                        typeofService = sv.servicetypedetails,
                        packagedesc = booking.Package.p_descripton,
                        packageamount = Convert.ToDecimal(booking.Package.p_amountPax),
                        cateringdiscount = service.GetCateringDiscount(booking.trn_Id)

                    }).ToList();




            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return prn_Contract.ToList();
        }


    }
}
