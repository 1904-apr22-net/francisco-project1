﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore.Library.Interfaces
{
     public interface IOrdersRepository
    {
        IEnumerable<Order> GetOrders();
        
        Order GetOrderById(int orderId);
        void DisplayOrderDetailsShort(int orderId);
        void DisplayOrderDetailsAll(int orderId);
        //void GetOrderItems(int orderId);
        void AddOrder(Order order);
        //void UpdateOrder(Order order);
        IEnumerable<Library.OrderItem> GetItemsByOrderId(int orderId);
        void AddOrderItem(Library.OrderItem item);
        int GetLastOrderAdded();
        void Save();

    }
}
