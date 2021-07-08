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
    
    public partial class SaleContract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SaleContract()
        {
            this.ExpenceInvoice = new HashSet<ExpenceInvoice>();
            this.SaleContractSpecification = new HashSet<SaleContractSpecification>();
        }
    
        public int Id { get; set; }
        public int IdStatus { get; set; }
        public int IdEmployee { get; set; }
        public Nullable<int> IdOrganization { get; set; }
        public string DeliveryAddress { get; set; }
        public System.DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpenceInvoice> ExpenceInvoice { get; set; }
        public virtual Organization Organization { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleContractSpecification> SaleContractSpecification { get; set; }
        public virtual Status Status { get; set; }
    }
}
