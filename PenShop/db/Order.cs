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
    
    public partial class Order
    {
        public int Id_Order { get; set; }
        public Nullable<int> Count_Pens { get; set; }
        public int Id_Pen { get; set; }
        public Nullable<System.DateTime> Date_Order { get; set; }
        public int Id_Client { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Pens Pens { get; set; }
    }
}