using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HardwareStore.DataAccess
{
    public static class Mapper
    {
        //map customer with customer
        public static Library.Customer Map(Entities.Customer customer) => new Library.Customer
        {
            CustId = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            DefaultStoreId = (int)customer.DefaultLocationId
        };

        public static Entities.Customer Map(Library.Customer customer) => new Entities.Customer
        {
            CustomerId = customer.CustId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            DefaultLocationId = customer.DefaultStoreId
        };
        public static IEnumerable<Library.Customer> Map(IEnumerable<Entities.Customer> customers) =>
          customers.Select(Map);

        public static IEnumerable<Entities.Customer> Map(IEnumerable<Library.Customer> customers) =>
           customers.Select(Map);

        public static Library.Location Map(Entities.StoreLocation location) => new Library.Location
        {
            LocationId = location.LocationId,
            Name = location.LocationName,
            Address=location.LocationAddress
        };

      
        public static Entities.StoreLocation Map(Library.Location location) => new Entities.StoreLocation
        {
            LocationId=location.LocationId,
            LocationName=location.Name,
            LocationAddress=location.Address
        };
        public static IEnumerable<Library.Location> Map(IEnumerable<Entities.StoreLocation> locations) =>
          locations.Select(Map);

        public static IEnumerable<Entities.StoreLocation> Map(IEnumerable<Library.Location> locations) =>
           locations.Select(Map);
        
        public static Library.Products Map(Entities.Products product) => new Library.Products
        {
            ProductId=product.ProductId,
            ProductName=product.ProductName,
            Description=product.ProductDescription,
            Price=product.ProductPrice
        };

        
        public static Entities.Products Map(Library.Products product) => new Entities.Products
        {
            ProductId=product.ProductId,
            ProductName=product.ProductName,
            ProductDescription=product.Description,
            ProductPrice=product.Price
        };
        
        public static IEnumerable<Library.Products> Map(IEnumerable<Entities.Products> products) =>
          products.Select(Map);
        
        public static IEnumerable<Entities.Products> Map(IEnumerable<Library.Products> products) =>
           products.Select(Map);


        public static Library.Order Map(Entities.CustomerOrder order) => new Library.Order
        {
            CustomerId=order.CustomerId,
            LocationId=order.LocationId,
            OrderTime = (DateTime)order.OrderTime,
            OrderTotal=order.OrderTotal, 
            OrderId=order.OrderId
        };

        
        public static Entities.CustomerOrder Map(Library.Order order) => new Entities.CustomerOrder
        {
            CustomerId=order.CustomerId,
            LocationId=order.LocationId,
            OrderTime=order.OrderTime,
            OrderTotal=order.OrderTotal,
            OrderId=order.OrderId
        };
        
        public static IEnumerable<Library.Order> Map(IEnumerable<Entities.CustomerOrder> orders) =>
          orders.Select(Map);
        
        public static IEnumerable<Entities.CustomerOrder> Map(IEnumerable<Library.Order> orders) =>
           orders.Select(Map);

        public static Library.Inventory Map(Entities.Inventory inventory) => new Library.Inventory
        {
            LocationId=inventory.LocationId,
            ProductId=inventory.ProductId,
            AmountInStock=(int)inventory.AmountInStock
        };

        
        public static Entities.Inventory Map(Library.Inventory inventory) => new Entities.Inventory
        {
            LocationId=inventory.LocationId,
            ProductId=inventory.ProductId,
            AmountInStock=inventory.AmountInStock
        };
        

        public static IEnumerable<Library.Inventory> Map(IEnumerable<Entities.Inventory> inventories) =>
          inventories.Select(Map);
        
        public static IEnumerable<Entities.Inventory> Map(IEnumerable<Library.Inventory> inventories) =>
           inventories.Select(Map);

        public static Library.OrderItem Map(Entities.OrderItem orderItem) => new Library.OrderItem
        {
            OrderId=orderItem.OrderId,
            OrderItemNum=orderItem.OrderItemNumber,
            ProductId=orderItem.ProductId,
            QuantityBought=orderItem.QuantityBought,
            Price=orderItem.Price
        };

        
        public static Entities.OrderItem Map(Library.OrderItem orderItem) => new Entities.OrderItem
        {
            OrderId=orderItem.OrderId,
            OrderItemNumber=orderItem.OrderItemNum,
            ProductId=orderItem.ProductId,
            QuantityBought=orderItem.QuantityBought,
            Price=orderItem.Price
        };
        

        public static IEnumerable<Library.OrderItem> Map(IEnumerable<Entities.OrderItem> orderItems) =>
          orderItems.Select(Map);
        
        public static IEnumerable<Entities.OrderItem> Map(IEnumerable<Library.OrderItem> orderItems) =>
           orderItems.Select(Map);
    }
}
