using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore.Library
{
    public class OrderItem
    {

        //pk will be composite pk made up of  OrderId and orderitemnum
        //public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int OrderItemNum { get; set; }
        public int ProductId { get; set; }
        public int QuantityBought { get; set; }

        public decimal Price { get; set;}

        //maybe add item name?or repeating self?
        //public int Amount { get; set; } maybe just calculate this in interface
    }
}
