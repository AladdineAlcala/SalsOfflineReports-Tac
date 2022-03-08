using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalsOfflineReports.Data;

namespace SalsOfflineReports.Class
{
    class BookMenusDeptViewModel
    {
        public int transId { get; set; }
        public string accnName { get; set; }
        public string menuId { get; set; }
        public string menuName { get; set; }
        public string course { get; set; }
        public int deptId { get; set; }
        public string deptName { get; set; }
        public int noofPax { get; set; }
        public string venue { get; set; }
        public DateTime eventDateTime { get; set; }

        private PegasusEntities dbEntities=new PegasusEntities();

        public IEnumerable<BookMenusDeptViewModel> getAllBookMenusbyDept()
        {
            List<BookMenusDeptViewModel> listofBookMenus=new List<BookMenusDeptViewModel>();

            var bookmenus = (from bk in dbEntities.Book_Menus select bk).ToList();
            var bookings = (from book in dbEntities.Bookings select book).ToList();

            listofBookMenus = (from  bm in bookmenus  join b in bookings on bm.trn_Id equals b.trn_Id
                               join m in dbEntities.Menus on bm.menuid equals m.menuid
                                join d in dbEntities.Departments on m.deptId equals d.deptId
                                join cc in dbEntities.CourseCategories on m.CourserId equals cc.CourserId
                                select new BookMenusDeptViewModel()
                                {
                                    transId =Convert.ToInt32(bm.trn_Id),
                                    accnName = Utilities.getfullname(b.Customer.lastname,b.Customer.firstname,b.Customer.middle),
                                    menuId = bm.menuid,
                                    menuName = m.menu_name,
                                    course = cc.Course,
                                    deptId =d.deptId,
                                    deptName = d.deptName,
                                    noofPax = Convert.ToInt32(bm.Booking.noofperson),
                                    venue = bm.Booking.venue,
                                    eventDateTime =Convert.ToDateTime(bm.Booking.startdate)   
                                }).ToList();

            return listofBookMenus.ToList();
        }
    }
}
