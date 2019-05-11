using System;
using System.Collections.Generic;

namespace HardwareStore.DataAccess.Entities
{
    public partial class Inventory
    {
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int? AmountInStock { get; set; }

        public virtual StoreLocation Location { get; set; }
        public virtual Products Product { get; set; }
    }
}
