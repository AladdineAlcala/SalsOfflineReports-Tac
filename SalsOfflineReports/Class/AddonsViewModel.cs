using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalsOfflineReports.Data;

namespace SalsOfflineReports.Class
{
    class AddonsViewModel
    {
        public int No { get; set; }
        public int TransId { get; set; }
        public int deptId { get; set; }
        public string AddonsDescription { get; set; }
        public string AddonNote { get; set; }
        public decimal AddOnqty { get; set; }
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

        public IEnumerable<AddonsViewModel> BookAddonsList()
        {
            List<AddonsViewModel> bookAddons =new List<AddonsViewModel>();

            var dbentities=new PegasusEntities();

            var bookingaddons = (from b in dbentities.BookingAddons where b.addonId != null select b).ToList();
            var addondetails = (from a in dbentities.AddonDetails select a).Where(x => x.deptId != null).ToList();

            bookAddons = (from ba in bookingaddons
                          join ad in addondetails on ba.addonId equals ad.addonId
                select new AddonsViewModel
                {
                    TransId = (int) ba.trn_Id,
                    AddonsDescription = ba.Addondesc,
                    deptId = (int) ad.deptId,
                    AddOnqty = (decimal) ba.addonQty

                }).ToList();

            return bookAddons;

        }
    }
}
