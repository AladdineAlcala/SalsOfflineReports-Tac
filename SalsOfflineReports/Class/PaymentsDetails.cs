using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalsOfflineReports.Class
{
    class PaymentsDetails
    {
        public int  payNo { get; set; }
        public int transId { get; set; }
        public DateTime dateofpayment { get; set; }
        public string particular { get; set; }
        public int paytype { get; set; }
        public decimal AmountPay { get; set; }
        public string paymeans { get; set; }
        public string checkNo { get; set; }
        public string notes { get; set; }


        public IEnumerable<PaymentsDetails> getPayment()
        {
            List<PaymentsDetails> list =new List<PaymentsDetails>();
            PegasusEntities dbEntities=new PegasusEntities();

            try
            {
                IEnumerable<Payment> payment = (from pay in dbEntities.Payments select pay);


                    list = (from p in payment
                    select new PaymentsDetails()
                    {
                        payNo = p.payNo,
                        transId =Convert.ToInt32(p.trn_Id),
                        dateofpayment =Convert.ToDateTime(p.dateofPayment),
                        particular = p.particular,
                        paytype =Convert.ToInt32(p.payType),
                        AmountPay =Convert.ToDecimal(p.amtPay),
                        checkNo = p.checkNo,
                        paymeans = p.pay_means,
                        notes = p.notes


                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return list;
        }
    }
}
