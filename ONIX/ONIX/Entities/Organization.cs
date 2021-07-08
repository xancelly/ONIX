//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Organization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organization()
        {
            this.SaleContract = new HashSet<SaleContract>();
            this.ServiceContract = new HashSet<ServiceContract>();
        }
    
        public int Id { get; set; }
        public int IdBankAccount { get; set; }
        public int IdTypeOrganization { get; set; }
        public string ContactPerson { get; set; }
        public string Name { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string OKPO { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PhysicalAddress { get; set; }
        public string BusinessAddress { get; set; }
        public string PaymentAccount { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual BankAccount BankAccount { get; set; }
        public virtual TypeOrganization TypeOrganization { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleContract> SaleContract { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceContract> ServiceContract { get; set; }
    }
}
