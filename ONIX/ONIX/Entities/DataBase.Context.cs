﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ONIX.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ONIX_DATABASEEntities : DbContext
    {
        public ONIX_DATABASEEntities()
            : base("name=ONIX_DATABASEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BankAccount> BankAccount { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<ExpenceInvoice> ExpenceInvoice { get; set; }
        public virtual DbSet<ExpenceInvoiceSpecification> ExpenceInvoiceSpecification { get; set; }
        public virtual DbSet<Good> Good { get; set; }
        public virtual DbSet<GoodNDS> GoodNDS { get; set; }
        public virtual DbSet<GoodPrice> GoodPrice { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Parameter> Parameter { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SaleContract> SaleContract { get; set; }
        public virtual DbSet<SaleContractSpecification> SaleContractSpecification { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceContract> ServiceContract { get; set; }
        public virtual DbSet<ServiceContractSpecification> ServiceContractSpecification { get; set; }
        public virtual DbSet<ServiceNDS> ServiceNDS { get; set; }
        public virtual DbSet<ServicePrice> ServicePrice { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TypeOrganization> TypeOrganization { get; set; }
        public virtual DbSet<TypeService> TypeService { get; set; }
    }
}