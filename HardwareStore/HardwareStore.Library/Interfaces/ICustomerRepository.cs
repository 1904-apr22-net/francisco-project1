using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore.Library.Interfaces
{
    public interface ICustomerRepository
    {

        IEnumerable<Customer> GetCustomers();
        void DisplayCustomers();
        void DisplayCustomer(Customer cust);
        IEnumerable<Customer> GetCustomerByName(string first, string last);
        IEnumerable<Order> GetOrderHistoryByCustomer(int customerId);
        /*
        void AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void SetDefaultLocation(int locationId);*/
        //void DisplayOrderHistory(int customerId);
        /*
        //void displayOrderHistoryEarliest,latest,etc();
        //void CanPlaceOrder();

        void Save();*/

    }
}
