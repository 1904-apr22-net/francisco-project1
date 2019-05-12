using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HardwareStore.Library;

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
        public DateTime OrderTime { get; set; }
        [Display(Name="Total cost")]
        public decimal OrderTotal { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
