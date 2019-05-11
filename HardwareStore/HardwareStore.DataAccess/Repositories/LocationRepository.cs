using System;
using System.Collections.Generic;
using System.Text;
using HardwareStore.Library.Interfaces;
using HardwareStore.Library;
using HardwareStore.DataAccess.Entities;
using System.Linq;

namespace HardwareStore.DataAccess.Repositories
{
    public class LocationRepository:ILocationRepo
    {
        private readonly HardwareStoreDbContext _dbContext;
        public LocationRepository(HardwareStoreDbContext dbContext) =>
           _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<Order> GetOrderHistoryByLocation(int locationId)
        {
            return Mapper.Map(_dbContext.CustomerOrder.Where(loc => loc.LocationId == locationId));
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return Mapper.Map(_dbContext.StoreLocation);
        }

        public void DisplayLocations()
        {
            var locations = GetAllLocations();
            foreach(var loc in locations)
            {
                Console.WriteLine($"Location id: {loc.LocationId} Location name: {loc.Name} address: {loc.Address}");
            }
        }

        public Location GetLocationById(int locationId)
        {
            return Mapper.Map(_dbContext.StoreLocation.Find(locationId));

        }

        public IEnumerable<Library.Inventory> GetInventoryByLocationId(int locationId)
        {
            return Mapper.Map(_dbContext.Inventory.Where(inv=>inv.LocationId==locationId));
        }

    }
}
