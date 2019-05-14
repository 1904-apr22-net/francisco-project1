using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareStore.WebUI.Models
{
    public class OrderItemViewModel
    {
        [Display(Name="Order Id")]
        public int OrderId;
        [Display(Name="Item Number")]
        public int OrderItemNum;
        [Display(Name="ProductId")]
        public int ProductId;
        [Display(Name="Quantity bought")]
        public int QuantityBought;
        [Display(Name="Price per item")]
        public decimal Price;
    }
}
