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
    
    public partial class GoodNDS
    {
        public int Id { get; set; }
        public int IdGood { get; set; }
        public int NDS { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Good Good { get; set; }
    }
}