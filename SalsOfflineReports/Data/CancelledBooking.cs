//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalsOfflineReports.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CancelledBooking
    {
        public long cNo { get; set; }
        public Nullable<System.DateTime> cancelledDated { get; set; }
        public Nullable<int> trn_Id { get; set; }
        public string reasoncancelled { get; set; }
        public Nullable<bool> isrefundable { get; set; }
    
        public virtual Booking Booking { get; set; }
    }
}
