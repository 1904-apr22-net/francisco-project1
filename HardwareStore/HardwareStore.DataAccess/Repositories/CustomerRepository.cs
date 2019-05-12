//using HardwareStore.DataAccess.Entities;
using HardwareStore.DataAccess;
using HardwareStore.Library.Interfaces;
using System;
using System.Collections.Generic;
using NLog;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HardwareStore.Library;

namespace HardwareStore.DataAccess.Repositories
{
    public class CustomerRepository :ICustomerRepository
    {
        private readonly HardwareStoreDbContext _dbContext;
        //maybe add logger if time

        /// <summary>
        /// initializes a new customer repository given a suitable data source
        /// </summary>
        /// <param name="dbContext"></param>
        public CustomerRepository(HardwareStoreDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        //private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        public IEnumerable<Library.Customer> GetCustomers()
        {
            return Mapper.Map(_dbContext.Customer);
        }

        public void DisplayCustomers()
        {
            foreach(var cust in GetCustomers())
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
    }
}
