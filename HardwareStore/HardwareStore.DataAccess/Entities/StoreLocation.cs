using System;
using System.Collections.Generic;

namespace HardwareStore.DataAccess.Entities
{
    public partial class StoreLocation
    {
        public StoreLocation()
        {
            Customer = new HashSet<Customer>();
            CustomerOrder = new HashSet<CustomerOrder>();
            Inventory = new HashSet<Inventory>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationAddress { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
