using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore.Library.Interfaces
{
    public interface IProductsRepository
    {
        IEnumerable<Products> GetAllProducts();
        Products GetProductByProductId(int productId);
        //void Save();
    }
}
