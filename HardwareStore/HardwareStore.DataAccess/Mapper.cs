using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HardwareStore.DataAccess
{
    public static class Mapper
    {
        //map customer with customer
        public static Library.Customer Map(Customer customer) => new Library.Customer
        {
            CustId = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            DefaultStoreId = (int)customer.DefaultLocationId
        };

        public static Customer Map(Library.Customer customer) => new Customer
        {
            CustomerId = customer.CustId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            DefaultLocationId = customer.DefaultStoreId
        };
        public static IEnumerable<Library.Customer> Map(IEnumerable<Customer> customers) =>
          customers.Select(Map);

        public static IEnumerable<Customer> Map(IEnumerable<Library.Customer> customers) =>
           customers.Select(Map);

        public static Library.Location Map(StoreLocation location) => new Library.Location
        {
            LocationId = location.LocationId,
            Name = location.LocationName,
            Address=location.LocationAddress
        };

      
        public static StoreLocation Map(Library.Location location) => new StoreLocation
        {
            LocationId=location.LocationId,
            LocationName=location.Name,
            LocationAddress=location.Address
        };
        public static IEnumerable<Library.Location> Map(IEnumerable<StoreLocation> locations) =>
          locations.Select(Map);

        public static IEnumerable<StoreLocation> Map(IEnumerable<Library.Location> locations) =>
           locations.Select(Map);
        
        public static Library.Products Map(Products product) => new Library.Products
        {
            ProductId=product.ProductId,
            ProductName=product.ProductName,
            Description=product.ProductDescription,
            Price=product.ProductPrice
        };

        
        public static Products Map(Library.Products product) => new Products
        {
            ProductId=product.ProductId,
            ProductName=product.ProductName,
            ProductDescription=product.Description,
            ProductPrice=product.Price
        };
        
        public static IEnumerable<Library.Products> Map(IEnumerable<Products> products) =>
          products.Select(Map);
        
        public static IEnumerable<Products> Map(IEnumerable<Library.Products> products) =>
           products.Select(Map);


        public static Library.Order Map(CustomerOrder order) => new Library.Order
        {
            CustomerId=order.CustomerId,
            LocationId=order.LocationId,
            OrderTime = (DateTime)order.OrderTime,
            OrderTotal=order.OrderTotal, 
            OrderId=order.OrderId
        };

        
        public static CustomerOrder Map(Library.Order order) => new CustomerOrder
        {
            CustomerId=order.CustomerId,
            LocationId=order.LocationId,
            OrderTime=order.OrderTime,
            OrderTotal=order.OrderTotal,
            OrderId=order.OrderId
        };
        
        public static IEnumerable<Library.Order> Map(IEnumerable<CustomerOrder> orders) =>
          orders.Select(Map);
        
        public static IEnumerable<CustomerOrder> Map(IEnumerable<Library.Order> orders) =>
           orders.Select(Map);

        public static Library.Inventory Map(Inventory inventory) => new Library.Inventory
        {
            LocationId=inventory.LocationId,
            ProductId=inventory.ProductId,
            AmountInStock=(int)inventory.AmountInStock
        };

        
        public static Inventory Map(Library.Inventory inventory) => new Inventory
        {
            LocationId=inventory.LocationId,
            ProductId=inventory.ProductId,
            AmountInStock=inventory.AmountInStock
        };
        

        public static IEnumerable<Library.Inventory> Map(IEnumerable<Inventory> inventories) =>
          inventories.Select(Map);
        
        public static IEnumerable<Inventory> Map(IEnumerable<Library.Inventory> inventories) =>
           inventories.Select(Map);

        public static Library.OrderItem Map(OrderItem orderItem) => new Library.OrderItem
        {
            OrderId=orderItem.OrderId,
            OrderItemNum=orderItem.OrderItemNumber,
            ProductId=orderItem.ProductId,
            QuantityBought=orderItem.QuantityBought,
            Price=orderItem.Price
        };

        
        public static OrderItem Map(Library.OrderItem orderItem) => new OrderItem
        {
            OrderId=orderItem.OrderId,
            OrderItemNumber=orderItem.OrderItemNum,
            ProductId=orderItem.ProductId,
            QuantityBought=orderItem.QuantityBought,
            Price=orderItem.Price
        };
        

        public static IEnumerable<Library.OrderItem> Map(IEnumerable<OrderItem> orderItems) =>
          orderItems.Select(Map);
        
        public static IEnumerable<OrderItem> Map(IEnumerable<Library.OrderItem> orderItems) =>
           orderItems.Select(Map);
    }
}
