using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public Task<Receipt> AddAsync(Receipt entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Receipt entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Receipt entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int key)
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

        public Receipt? Update(Receipt entity)
        {
            throw new NotImplementedException();
        }

        public Task<Receipt?> UpdateAsync(Receipt entity)
        {
            throw new NotImplementedException();
        }
    }
}
