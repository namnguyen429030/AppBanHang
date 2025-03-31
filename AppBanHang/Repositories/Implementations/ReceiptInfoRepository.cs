using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AppBanHang.Repositories.Implementations
{
    public class ReceiptInfoRepository : Repository, IReceiptInfoRepository
    {
        public ReceiptInfoRepository(ShopManagementAppContext shopManagementAppContext) : base(shopManagementAppContext)
        {
        }

        public ReceiptInfo Add(ReceiptInfo entity)
        {
            shopManagementAppContext.Add(entity);
            shopManagementAppContext.SaveChanges();
            return entity;
        }

        public async Task<ReceiptInfo> AddAsync(ReceiptInfo entity)
        {
            await shopManagementAppContext.AddAsync(entity);
            await shopManagementAppContext.SaveChangesAsync();
            return entity;
        }

        public void Delete(ReceiptInfo entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(ReceiptInfo entity)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ReceiptInfo> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ReceiptInfo>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public ReceiptInfo? GetByKey(int key)
        {
            throw new System.NotImplementedException();
        }

        public Task<ReceiptInfo?> GetByKeyAsync(int key)
        {
            throw new System.NotImplementedException();
        }

        public ReceiptInfo Update(ReceiptInfo entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ReceiptInfo> UpdateAsync(ReceiptInfo entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
