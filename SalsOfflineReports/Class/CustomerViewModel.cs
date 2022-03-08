using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalsOfflineReports.Data;

namespace SalsOfflineReports.Class
{
    public class CustomerViewModel
    {
        public int c_Id { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string middle { get; set; }
        public string address { get; set; }
        public string contact1 { get; set; }
        public string contact2 { get; set; }
        public DateTime datereg { get; set; }
        public string company { get; set; }

        public IQueryable<CustomerViewModel> GetCustomers(IQueryable<Customer> customers)
        {
            return customers.Select(t => new CustomerViewModel()
            {
                c_Id = t.c_Id,
                lastname = t.lastname,
                firstname = t.firstname,
                middle = t.middle,
                address = t.address,
                contact1 = t.contact1,
                contact2 = t.contact2,
                datereg = (DateTime) t.datereg,
                company = t.company
            });
        }
    }
}
