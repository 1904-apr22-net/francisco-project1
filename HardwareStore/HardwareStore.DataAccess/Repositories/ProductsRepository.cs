using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HardwareStore;
using HardwareStore.Library;
using HardwareStore.Library.Interfaces;
using HardwareStore.DataAccess.Entities;

namespace HardwareStore.DataAccess.Repositories
{
    public class ProductsRepository:IProductsRepository
    {
        private readonly HardwareStoreDbContext _dbContext;
        public ProductsRepository(HardwareStoreDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public IEnumerable<Library.Products> GetAllProducts()
        {
            return Mapper.Map(_dbContext.Products);
        }

        public Library.Products GetProductByProductId(int productId)
        {
            return Mapper.Map(_dbContext.Products.Where(prod => prod.ProductId == productId).First());
        }
    }
}
