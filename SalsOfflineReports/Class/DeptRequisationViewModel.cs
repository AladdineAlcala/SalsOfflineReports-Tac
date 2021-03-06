using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalsOfflineReports.Data;

namespace SalsOfflineReports.Class
{
   public class DeptRequisationViewModel
    {
        public int TransId { get; set; }
        public int DeptId { get; set; }
        public string Deptname { get; set; }


        public IEnumerable<DeptRequisationViewModel> GetDeptByRequisation(int transId)
        {
            var dbentities=new PegasusEntities();

            List<DeptRequisationViewModel> list=new List<DeptRequisationViewModel>();

            list = (from bm in dbentities.Book_Menus
                join m in dbentities.Menus on bm.menuid equals m.menuid
                join d in dbentities.Departments on m.deptId equals d.deptId
                where bm.trn_Id == transId
                select new DeptRequisationViewModel()
                {
                    TransId = (int) bm.trn_Id,
                    DeptId =(int) m.deptId,
                    Deptname =d.deptName

                }).ToList();

            list.AddRange(from ba in dbentities.BookingAddons join ad in dbentities.AddonDetails on ba.addonId equals ad.addonId
                join d in dbentities.Departments on ad.deptId equals d.deptId
                where ba.trn_Id == transId
                select new DeptRequisationViewModel()
                {
                    TransId = (int)ba.trn_Id,
                    DeptId = (int)ad.deptId,
                    Deptname = d.deptName

                });

            return list.GroupBy(dept=>new {dept.DeptId,dept.Deptname,dept.TransId}).Select(d=>d.First()).ToList();
        }
    }

    

}
