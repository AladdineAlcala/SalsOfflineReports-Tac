﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PegasusEntities : DbContext
    {
        public PegasusEntities()
            : base("name=PegasusEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AddonCategory> AddonCategories { get; set; }
        public virtual DbSet<AddonDetail> AddonDetails { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<AuditLogDetail> AuditLogDetails { get; set; }
        public virtual DbSet<AuditLog> AuditLogs { get; set; }
        public virtual DbSet<Book_Discount> Book_Discount { get; set; }
        public virtual DbSet<Book_Menus> Book_Menus { get; set; }
        public virtual DbSet<BookingAddon> BookingAddons { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<CateringDiscount> CateringDiscounts { get; set; }
        public virtual DbSet<CourseCategory> CourseCategories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<PackageAreaCoverage> PackageAreaCoverages { get; set; }
        public virtual DbSet<PackageBody> PackageBodies { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Packages_No_Pax_applicable> Packages_No_Pax_applicable { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<PackagesRangeBelowMin> PackagesRangeBelowMins { get; set; }
    }
}
