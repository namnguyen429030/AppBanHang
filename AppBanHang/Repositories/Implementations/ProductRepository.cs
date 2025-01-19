using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
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
            shopManagementAppContext.Products.Add(entity);
            shopManagementAppContext.SaveChanges();
            return entity;
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await shopManagementAppContext.Products.AddAsync(entity);
            await shopManagementAppContext.SaveChangesAsync();
            return entity;
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
            return shopManagementAppContext.Products;
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAllByOwnerId(int ownerId)
        {
            return shopManagementAppContext.Products.Where(p => p.OwnerId == ownerId);
        }

        public Task<IEnumerable<Product>> GetAllByOwnerIdAsync(int ownerId)
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
