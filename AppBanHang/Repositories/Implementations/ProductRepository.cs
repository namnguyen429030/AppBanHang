using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Repositories.Implementations
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(ShopManagementAppContext shopManagementAppContext) : base(shopManagementAppContext)
        {
        }

        public Product Add(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> AddAsync(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int key)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int key)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Product? GetByKey(int key)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product?> GetByKeyAsync(int key)
        {
            throw new System.NotImplementedException();
        }

        public Product? Update(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product?> UpdateAsync(Product entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
