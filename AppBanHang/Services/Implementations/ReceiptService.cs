using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Implementations
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;
        public ReceiptService(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public Receipt AddReceipt(Receipt receipt)
        {
            throw new System.NotImplementedException();
        }

        public Task<Receipt> AddReceiptAsync(Receipt receipt)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Receipt> GetAllReceiptsByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Receipt>> GetAllReceiptsByUserIdAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Receipt GetReceiptById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Receipt> GetReceiptByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
