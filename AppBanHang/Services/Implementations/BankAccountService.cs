using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Interfaces;

namespace AppBanHang.Services.Implementations
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }
    }
}
