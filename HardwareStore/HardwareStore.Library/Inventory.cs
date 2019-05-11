using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore.Library
{
    /// <summary>
    /// Inventory object. Each inventory has an InventoryId, productId, 
    /// variable to hold amount in stock, and a StoreId that references
    /// which store it belongs to.
    /// </summary>
    public class Inventory
    {
        //will be using composite pk of locationid and productid

       // public int InventoryId { get; set; }
        public int ProductId { get; set; } //maybe dont need this, just product list
        //public int AmountInStock { get; set; } probably not need this
        //TODO:add inventory list, orderlist..scratch that maybe just list of products
        public int LocationId { get; set; }
        public int AmountInStock { get; set; }

    }
}
