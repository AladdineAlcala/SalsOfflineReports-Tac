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
    
    public partial class RefundEntry
    {
        public long No { get; set; }
        public Nullable<long> Rf_id { get; set; }
        public string Particular { get; set; }
        public Nullable<decimal> Amount { get; set; }
    
        public virtual Refund Refund { get; set; }
    }
}