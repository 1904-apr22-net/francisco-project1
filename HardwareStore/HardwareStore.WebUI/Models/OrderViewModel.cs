using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HardwareStore.Library;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HardwareStore.WebUI.Models
{
    public class OrderViewModel
    {
        [Display(Name="Order Id")]
        public int OrderId { get; set; }
        [Display(Name="Location Id")]
        public int LocationId { get; set; }
        [Display(Name="Customer Id")]
        public int CustomerId { get; set; }
        [Display(Name="Time ordered")]
        [DataType(DataType.DateTime)]
        public DateTime OrderTime { get; set; }
        [Display(Name="Total cost")]
        public decimal OrderTotal { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public OrderViewModel() { }

        public OrderViewModel(Order order)
        {
            OrderId = order.OrderId;
            OrderTime = order.OrderTime;
            OrderTotal = order.OrderTotal;
            LocationId = order.LocationId;
            CustomerId = order.CustomerId;
            OrderItems = order.OrderItems;
        }

        public List<Location> Locations { get; set; }
        public List<Customer> Customers { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public List<OrderItemViewModel> AmountItems { get; set; }
        public Location OrderedAt { get; set; }

        public SelectList selector { get; set; }

        //public List<SelectList> selectLists { get; set; }
        public List <int> NumItems { get; set; }

    }
}
