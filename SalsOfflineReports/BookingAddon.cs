//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalsOfflineReports
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookingAddon
    {
        public int No { get; set; }
        public Nullable<int> trn_Id { get; set; }
        public Nullable<int> addonId { get; set; }
        public string Addondesc { get; set; }
        public string Note { get; set; }
        public Nullable<decimal> addonQty { get; set; }
        public Nullable<decimal> AddonAmount { get; set; }
    
        public virtual Booking Booking { get; set; }
    }
}
