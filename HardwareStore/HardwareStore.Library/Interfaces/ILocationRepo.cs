using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore.Library.Interfaces
{
    public interface ILocationRepo
    {
        //IEnumerable<Location> GetLocations();
        //Location GetLocationById(int locationId);
        //IEnumerable<Location> GetInventory(int productId, int locationId);
        //void DecreaseInventory(int productId, int locationId, int quantity);
        IEnumerable<Order> GetOrderHistoryByLocation(int locationId);
        IEnumerable<Location> GetAllLocations();
        IEnumerable<Inventory> GetInventoryByLocationId(int locationId);
        //void Save();
    }
}
