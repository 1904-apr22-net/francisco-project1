using System;
using System.Collections.Generic;

namespace HardwareStore.DataAccess.Entities
{
    public partial class OrderItem
    {
        public int OrderId { get; set; }
        public int OrderItemNumber { get; set; }
        public int ProductId { get; set; }
        public int QuantityBought { get; set; }
        public decimal Price { get; set; }

        public virtual CustomerOrder Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
