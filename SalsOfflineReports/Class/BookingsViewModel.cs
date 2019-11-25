using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalsOfflineReports.Class
{
    public class BookingsViewModel
    {
        public int trn_Id { get; set; }
        public DateTime transdate { get; set; }
        public string booktype { get; set; }
        public int c_Id { get; set; }
        public int noofperson { get; set; }
        public string occasion { get; set; }
        public string venue { get; set; }
        public int typeofservice { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string eventcolor { get; set; }
        public int p_id { get; set; }
        public string reference { get; set; }
        public int extendedAreaId { get; set; }
        public bool apply_extendedAmount { get; set; }
        public decimal p_amount { get; set; }
        public bool serve_stat { get; set; }
        public bool is_cancelled { get; set; }
        public string b_createdbyUser { get; set; }
        public DateTime b_updatedDate { get; set; }


        public IQueryable<BookingsViewModel> GetBooking(IQueryable<Booking> bookings)
        {
            return bookings.Select(t => new BookingsViewModel()
            {
             trn_Id   = t.trn_Id,
             transdate = (DateTime) t.transdate,
             booktype = t.booktype,
             c_Id = (int) t.c_Id,
             noofperson = (int) t.noofperson,
             occasion = t.occasion,
             venue = t.venue,
             typeofservice = (int) t.typeofservice,
             startdate = (DateTime) t.startdate,
             enddate = (DateTime) t.enddate,
             eventcolor = t.eventcolor,
             p_id = (int) t.p_id,
             reference = t.reference,
             extendedAreaId = (int) t.extendedAreaId,
             apply_extendedAmount = (bool) t.apply_extendedAmount,
             p_amount = (decimal) t.p_amount,
             serve_stat = (bool) t.serve_stat,
             is_cancelled = (bool) t.is_cancelled,
             b_createdbyUser = t.b_createdbyUser,
             b_updatedDate = t.b_updatedDate
            });
        }
    }
}
