using System;
using System.Collections.Generic;
using System.Text;
using HardwareStore.Library.Interfaces;
using HardwareStore.Library;
using System.Linq;
using HardwareStore.DataAccess.Entities;

namespace HardwareStore.DataAccess.Repositories
{
    public class OrderRepository:IOrdersRepository
    {
        private readonly HardwareStoreDbContext _dbContext;

        public OrderRepository(HardwareStoreDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

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
            Console.WriteLine("Order Id: "+order.OrderId + " Order Time: "+order.OrderTime+" Location id: "+order.LocationId+" Customer Id: "+order.CustomerId+"Order total: "+ order.OrderTotal);
        }

        public IEnumerable<Library.OrderItem> GetAllItems()
        {
            return Mapper.Map(_dbContext.OrderItem);
        }
        public IEnumerable<Library.OrderItem> GetItemsByOrderId(int orderId)
        {
            return Mapper.Map(_dbContext.OrderItem.Where(item =>item.OrderId==orderId));
        }
        
        public void  DisplayOrderDetailsAll(int orderId)
        {
            Order order = GetOrderById(orderId);
            //Console.WriteLine("Displaying all details of order");
            Console.WriteLine("id: " + order.OrderId + " " + order.OrderTime + " Total: " + order.OrderTotal + " location id: " + order.LocationId +" customer id:"+ order.CustomerId);
            IEnumerable<Library.OrderItem> itemsList = GetItemsByOrderId(order.OrderId);
            foreach(var x in itemsList)
            {
                Console.WriteLine($"\tOrderItem: Order Id {x.OrderId} OrderItemNum: {x.OrderItemNum} quantity bought {x.QuantityBought} price: {x.Price}");
            }
        }
        public int GetLastOrderAdded()
        {
            return _dbContext.CustomerOrder.OrderByDescending(x=>x.OrderId).First().OrderId;
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
    }
}
