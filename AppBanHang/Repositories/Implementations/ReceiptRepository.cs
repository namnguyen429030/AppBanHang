using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AppBanHang.Repositories.Implementations
{
    public class ReceiptRepository : Repository, IReceiptRepository
    {
        public ReceiptRepository(ShopManagementAppContext shopManagementAppContext) : base(shopManagementAppContext)
        {
        }

        public Receipt Add(Receipt entity)
        {
            shopManagementAppContext.Add(entity);
            shopManagementAppContext.SaveChanges();
            return entity;
        }

        public async Task<Receipt> AddAsync(Receipt entity)
        {
            await shopManagementAppContext.AddAsync(entity);
            try
            {
                await shopManagementAppContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return entity;
        }

        public void Delete(Receipt entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Receipt entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Receipt> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Receipt>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Receipt? GetByKey(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Receipt?> GetByKeyAsync(int key)
        {
            throw new NotImplementedException();
        }

        public Receipt Update(Receipt entity)
        {
            shopManagementAppContext.Update(entity);
            shopManagementAppContext.SaveChanges();
            return entity;
        }

        public Task<Receipt> UpdateAsync(Receipt entity)
        {
            throw new NotImplementedException();
        }
    }
}
