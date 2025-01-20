using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public Task<ReceiptInfo> AddAsync(ReceiptInfo entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(ReceiptInfo entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(ReceiptInfo entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int key)
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
