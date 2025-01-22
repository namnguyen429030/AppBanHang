using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Implementations
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public BankAccount AddBankAccount(BankAccount bankAccount)
        {
            throw new System.NotImplementedException();
        }

        public Task<BankAccount> AddBankAccountAsync(BankAccount bankAccount)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteBankAccount(int id)
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<BankAccount> GetAllBankAccountByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<BankAccount>> GetAllBankAccountByUserIdAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public BankAccount GetBankAccountById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<BankAccount> GetBankAccountByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public BankAccount UpdateBankAccount(BankAccount bankAccount)
        {
            throw new System.NotImplementedException();
        }
    }
}
