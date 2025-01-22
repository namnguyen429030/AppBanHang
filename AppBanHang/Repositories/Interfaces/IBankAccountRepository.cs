using AppBanHang.Models;
using System.Threading.Tasks;

namespace AppBanHang.Repositories.Interfaces
{
    public interface IBankAccountRepository : IRepository<int, BankAccount>
    {
        Task DeleteAsync(BankAccount bankAccount);
        Task<BankAccount> UpdateAsync(BankAccount bankAccount);
    }
}
