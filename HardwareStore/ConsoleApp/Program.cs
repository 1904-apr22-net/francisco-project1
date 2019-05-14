using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security;
using System.Collections.Generic;
using System.Linq;
using NLog;
using HardwareStore.DataAccess;
using HardwareStore.Library.Interfaces;
using HardwareStore.Library;
using HardwareStore.DataAccess.Repositories;
using HardwareStore.ProjectUI;

//just using this to test a few things
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var optionsBuilder = new DbContextOptionsBuilder<HardwareStoreDbContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);
            var dbContext = new HardwareStoreDbContext(optionsBuilder.Options);


            HardwareStoreRepository repo = new HardwareStoreRepository(dbContext);
            CustomerRepository cusRepo = new CustomerRepository(dbContext);
            /*CustomerRepository customerRepository = new CustomerRepository(dbContext);
            OrderRepository orderRepository = new OrderRepository(dbContext);
            LocationRepository locationRepository = new LocationRepository(dbContext);
            ProductsRepository productsRepository = new ProductsRepository(dbContext);*/

            Console.WriteLine("getting all customers");
            var CustomerList = cusRepo.GetCustomers().ToList();
            foreach (var cust in CustomerList)
            {
                Console.WriteLine("Id: " + cust.CustId + " Name: " + cust.FirstName + " " + cust.LastName + " phone: " + cust.PhoneNumber + " DefaultlocId: " + cust.DefaultStoreId);
            }

            Console.WriteLine("getting all locations");
            foreach (var o in repo.GetAllLocations())
            {
                Console.WriteLine($"Location id {o.LocationId} name {o.Name} address {o.Address}");
            }
        }
    }
}
