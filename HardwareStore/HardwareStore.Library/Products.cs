using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore.Library
{
    /// <summary>
    /// A product object. each product has an Id, name, description, and price.
    /// </summary>
    public class Products
    {
        public int ProductId { get; set; }
        private string _productName;
        private string _description;
        private decimal _price;


        //Todo:maybe add TypeID/producttype later? or will do in db?

        public string ProductName
        {
            get => _productName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Product name cannot be empty.", nameof(value));
                }
                _productName = value;
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
            }
        }
    }
}
