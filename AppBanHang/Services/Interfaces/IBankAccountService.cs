using AppBanHang.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Interfaces
{
    public interface IBankAccountService
    {
        IEnumerable<BankAccount> GetAllBankAccountByUserId(int userId);
        BankAccount? GetBankAccountById(int id);
        BankAccount AddBankAccount(BankAccount bankAccount);
        BankAccount UpdateBankAccount(BankAccount bankAccount);
        bool DeleteBankAccount(int id);

        Task<IEnumerable<BankAccount>> GetAllBankAccountByUserIdAsync(int userId);
        Task<BankAccount?> GetBankAccountByIdAsync(int id);
        Task<BankAccount> AddBankAccountAsync(BankAccount bankAccount);
    }
}
