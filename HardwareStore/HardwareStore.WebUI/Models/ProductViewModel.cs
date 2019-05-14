using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HardwareStore.Library;

namespace HardwareStore.WebUI.Models
{
    public class ProductViewModel
    {
        [Display(Name="Id")]
        public int ProductId { get; set; }
        [Display(Name="Product name")]
        public string ProductName { get; set; }
        [Display(Name="Description")]
        public string Description { get; set; }
        [Display(Name="Price")]
        public decimal Price { get; set; }
        public ProductViewModel() { }
        public ProductViewModel(Products product)
        {
            ProductId = product.ProductId;
            ProductName = product.ProductName;
            Description = product.Description;
            Price = product.Price;
        }
        public bool Checked { get; set; }
    }
}
