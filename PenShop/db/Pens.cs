//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PenShop.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pens
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pens()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int Id_Pen { get; set; }
        public int Id_Company { get; set; }
        public int Id_TypeP { get; set; }
        public string Articul { get; set; }
        public string Color_Pen { get; set; }
        public string Price { get; set; }
    
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
        public virtual Type_Pens Type_Pens { get; set; }
    }
}
