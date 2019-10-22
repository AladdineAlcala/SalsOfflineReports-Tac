using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalsOfflineReports.Class
{
    class AddonsViewModel
    {
        public int No { get; set; }
        public int TransId { get; set; }
        public string AddonsDescription { get; set; }
        public string AddonNote { get; set; }
        public decimal AddonAmount { get; set; }

        public IEnumerable<AddonsViewModel> ListofAddons()
        {
            List<AddonsViewModel> list = new List<AddonsViewModel>();
            var _dbentities = new PegasusEntities();
            try
            {
                list = (from a in _dbentities.BookingAddons
                    select new AddonsViewModel
                    {
                        No = a.No,
                        TransId = (int)a.trn_Id,
                        AddonsDescription = a.Addondesc,
                        AddonAmount = (decimal)a.AddonAmount,
                        AddonNote = a.Note
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return list.ToList();
        }
    }
}
