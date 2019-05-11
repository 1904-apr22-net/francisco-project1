using System;
using System.Collections.Generic;

namespace HardwareStore.DataAccess.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerOrder = new HashSet<CustomerOrder>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int? DefaultLocationId { get; set; }

        public virtual StoreLocation DefaultLocation { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
    }
}
