//using HardwareStore.DataAccess.Entities;
using HardwareStore.DataAccess;
using HardwareStore.Library.Interfaces;
using System;
using System.Collections.Generic;
using NLog;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HardwareStore.Library;


//Instead of using 4 different repos, i made one that does everything so i dont have to create as many instances of specialized repos
namespace HardwareStore.DataAccess.Repositories
{
    public class HardwareStoreRepository:ICustomerRepository, ILocationRepo, IOrdersRepository,IProductsRepository
    {
        private readonly HardwareStoreDbContext _dbContext;
        //maybe add logger if time

        /// <summary>
        /// initializes a new customer repository given a suitable data source
        /// </summary>
        /// <param name="dbContext"></param>
        public HardwareStoreRepository(HardwareStoreDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        //private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        public IEnumerable<Library.Customer> GetCustomers()
        {
            return Mapper.Map(_dbContext.Customer);
        }

        public void DisplayCustomers()
        {
            foreach (var cust in GetCustomers())
            {
                Console.WriteLine("Id: " + cust.CustId + " Name: " + cust.FirstName + " " + cust.LastName + " phone: " + cust.PhoneNumber + " DefaultlocId: " + cust.DefaultStoreId);
            }
        }

        public Library.Customer GetCustomerById(int customerId)
        {
            return Mapper.Map(_dbContext.Customer.Find(customerId));
        }
        public IEnumerable<Library.Customer> GetCustomerByName(string first, string last)
        {
            return Mapper.Map(_dbContext.Customer.Where(cust => cust.FirstName.ToUpper() == first && cust.LastName.ToUpper() == last));
        }

        public void DisplayCustomer(Library.Customer cust)
        {
            Console.WriteLine("Id: " + cust.CustId + " Name: " + cust.FirstName + " " + cust.LastName + " phone: " + cust.PhoneNumber + " DefaultlocId: " + cust.DefaultStoreId);
        }

        /// <summary>
        /// display all order history of a customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public IEnumerable<Order> GetOrderHistoryByCustomer(int customerId)
        {
            return Mapper.Map(_dbContext.CustomerOrder.Where(order => order.CustomerId == customerId).ToList());
        }

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
            foreach (var loc in locations)
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
            return Mapper.Map(_dbContext.Inventory.Where(inv => inv.LocationId == locationId));
        }

        public IEnumerable<Order> GetOrders()
        {
            return Mapper.Map(_dbContext.CustomerOrder);
            //return Mapper.Map(_dbContext.CustomerOrder.ToList());
        }
        public Order GetOrderById(int orderId)
        {
            return Mapper.Map(_dbContext.CustomerOrder.Find(orderId));
        }

        public void DisplayOrderDetailsShort(int orderId)
        {
            Order order = GetOrderById(orderId);
            Console.WriteLine("Order Id: " + order.OrderId + " Order Time: " + order.OrderTime + " Location id: " + order.LocationId + " Customer Id: " + order.CustomerId + "Order total: " + order.OrderTotal);
        }

        public IEnumerable<Library.OrderItem> GetAllItems()
        {
            return Mapper.Map(_dbContext.OrderItem);
        }
        public IEnumerable<Library.OrderItem> GetItemsByOrderId(int orderId)
        {
            return Mapper.Map(_dbContext.OrderItem.Where(item => item.OrderId == orderId));
        }

        public void DisplayOrderDetailsAll(int orderId)
        {
            Order order = GetOrderById(orderId);
            //Console.WriteLine("Displaying all details of order");
            Console.WriteLine("id: " + order.OrderId + " " + order.OrderTime + " Total: " + order.OrderTotal + " location id: " + order.LocationId + " customer id:" + order.CustomerId);
            IEnumerable<Library.OrderItem> itemsList = GetItemsByOrderId(order.OrderId);
            foreach (var x in itemsList)
            {
                Console.WriteLine($"\tOrderItem: Order Id {x.OrderId} OrderItemNum: {x.OrderItemNum} quantity bought {x.QuantityBought} price: {x.Price}");
            }
        }
        public int GetLastOrderAdded()
        {
            return _dbContext.CustomerOrder.OrderByDescending(x => x.OrderId).First().OrderId;
            //return Context.CupcakeOrder.OrderByDescending(x => x.OrderId).First().OrderId;
        }
        public void AddOrder(Order order)
        {
            _dbContext.Add(Mapper.Map(order));
        }

        public void AddOrderItem(Library.OrderItem item)
        {
            _dbContext.Add(Mapper.Map(item));
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<Library.Products> GetAllProducts()
        {
            return Mapper.Map(_dbContext.Products);
        }

        public Library.Products GetProductByProductId(int productId)
        {
            return Mapper.Map(_dbContext.Products.Where(prod => prod.ProductId == productId).First());
        }
    }
}
