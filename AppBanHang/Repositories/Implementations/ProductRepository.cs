using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public void Delete(Product entity)
        {
            shopManagementAppContext.Remove(entity);
            shopManagementAppContext.SaveChanges();
        }

        public async Task DeleteAsync(Product product)
        {
            shopManagementAppContext.Products.Remove(product);
            await shopManagementAppContext.SaveChangesAsync();
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
            return shopManagementAppContext.Products.FirstOrDefault(p => p.Id == key);
        }

        public Task<Product?> GetByKeyAsync(int key)
        {
            return shopManagementAppContext.Products.FirstOrDefaultAsync(p => p.Id == key);
        }

        public Product Update(Product entity)
        {
            shopManagementAppContext.Products.Update(entity);
            shopManagementAppContext.SaveChanges();
            return entity;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            shopManagementAppContext.Products.Update(product);
            await shopManagementAppContext.SaveChangesAsync();
            return product;
        }
    }
}
