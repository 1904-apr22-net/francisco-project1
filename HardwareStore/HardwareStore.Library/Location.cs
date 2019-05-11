using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore.Library
{
    public class Location
    {
        private string _name;
        private string _address;
        //private int _inventoryId;

        public int LocationId { get; set; }
        public string Name
        {
            get =>_name;
            set
            {
                if (value.Length==0)
                {
                    throw new ArgumentException("Location name cannot be empty.", nameof(value));
                }
                _name = value;
            }
        }
        public string Address
        {
            get =>_address;
            set { _address = value; }
        }
        //public int InventoryId { get; set; }//or make this list of inventories

        public List<Order> ListOfOrders { get; set; }

        //each location  maybe list of inventories
        /*todo:inventory decreases when orders are accepted
        reject orders that cane be fulfilled with remaining inventory
        relationship between products sold must have some complexity
        has order history*/
    }
}
