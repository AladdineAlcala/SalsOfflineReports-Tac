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
    
    public partial class Discount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Discount()
        {
            this.Book_Discount = new HashSet<Book_Discount>();
        }
    
        public int disc_Id { get; set; }
        public string discCode { get; set; }
        public string disctype { get; set; }
        public Nullable<decimal> discount1 { get; set; }
        public Nullable<System.DateTime> discStartdate { get; set; }
        public Nullable<System.DateTime> discEnddate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book_Discount> Book_Discount { get; set; }
    }
}
