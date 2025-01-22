using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Repositories.Implementations
{
    public class BankAccountRepository : Repository, IBankAccountRepository
    {
        public BankAccountRepository(ShopManagementAppContext shopManagementAppContext) : base(shopManagementAppContext)
        {
        }

        public BankAccount Add(BankAccount entity)
        {
            throw new NotImplementedException();
        }

        public Task<BankAccount> AddAsync(BankAccount entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BankAccount entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(BankAccount bankAccount)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BankAccount> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BankAccount>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public BankAccount? GetByKey(int key)
        {
            throw new NotImplementedException();
        }

        public Task<BankAccount?> GetByKeyAsync(int key)
        {
            throw new NotImplementedException();
        }

        public BankAccount Update(BankAccount entity)
        {
            throw new NotImplementedException();
        }

        public Task<BankAccount> UpdateAsync(BankAccount bankAccount)
        {
            throw new NotImplementedException();
        }
    }
}
