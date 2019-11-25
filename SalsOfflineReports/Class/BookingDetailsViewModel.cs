using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalsOfflineReports.Class
{
    public class BookingDetailsViewModel
    {
        public int TransId { get; set; }
        public string CustomerName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public int NoofPax { get; set; }
        public string EventVenue { get; set; }



        public BookingDetailsViewModel GetBookingDetails(int transId)
        {
            var dbentities=new PegasusEntities();

            var books = (from b in dbentities.Bookings select b).ToList();

            var bookdetails = (from b in books
               
                select new BookingDetailsViewModel()
                {
                    TransId = b.trn_Id,
                    CustomerName = Utilities.getfullname(b.Customer.lastname,b.Customer.firstname,b.Customer.middle),
                    EventDate = Convert.ToDateTime(b.startdate),
                    //EventDate = (DateTime) truncateTime,
                    //EventTime = (TimeSpan) DbFunctions.CreateTime(b.startdate.Value.Hour, b.startdate.Value.Minute, b.startdate.Value.Second),
                    NoofPax = (int) b.noofperson,
                    EventVenue = b.venue
                });

            return bookdetails.FirstOrDefault(x => x.TransId == transId);
        }

    }
}
