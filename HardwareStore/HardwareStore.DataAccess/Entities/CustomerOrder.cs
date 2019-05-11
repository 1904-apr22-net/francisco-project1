using System;
using System.Collections.Generic;

namespace HardwareStore.DataAccess.Entities
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderTime { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
        public decimal OrderTotal { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual StoreLocation Location { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
