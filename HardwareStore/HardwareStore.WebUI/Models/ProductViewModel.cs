using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HardwareStore.WebUI.Models
{
    public class ProductViewModel
    {
        [Display(Name="Id")]
        public int ProductId { get; set; }
        [Display(Name="Product name")]
        public string ProductName { get; set; }
        [Display(Name="Description")]
        public string description { get; set; }
        [Display(Name="Price")]
        public decimal Price { get; set; }

    }
}
