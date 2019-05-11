using System;
using System.Collections.Generic;

namespace HardwareStore.DataAccess.Entities
{
    public partial class Products
    {
        public Products()
        {
            Inventory = new HashSet<Inventory>();
            OrderItem = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
