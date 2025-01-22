using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Implementations
{
    public class ReceiptService : IReceiptService
    {
        private readonly ShopManagementAppContext _shopManagementAppContext;
        private readonly IReceiptRepository _receiptRepository;
        private readonly IReceiptInfoRepository _receiptInfoRepository;
        public ReceiptService(ShopManagementAppContext shopManagementAppContext, IReceiptRepository receiptRepository, IReceiptInfoRepository receiptInfoRepository)
        {
            _shopManagementAppContext = shopManagementAppContext;
            _receiptRepository = receiptRepository;
            _receiptInfoRepository = receiptInfoRepository;
        }

        public Receipt AddReceipt(Receipt receipt, IEnumerable<ReceiptInfo> receiptInfo)
        {
            var addedReceipt = _receiptRepository.Add(receipt);
            foreach(var info in receiptInfo)
            {
                info.ReceiptId = addedReceipt.Id;
                _receiptInfoRepository.Add(info);
            }
            _shopManagementAppContext.SaveChanges();
            return addedReceipt;
        }
        public async Task<Receipt> AddReceiptAsync(Receipt receipt, IEnumerable<ReceiptInfo> receiptInfo)
        {
            var addedReceipt = await _receiptRepository.AddAsync(receipt);
            foreach(var info in receiptInfo)
            {
                info.ReceiptId = addedReceipt.Id;
                await _receiptInfoRepository.AddAsync(info);
            }
            await _shopManagementAppContext.SaveChangesAsync();
            return addedReceipt;
        }

        public IEnumerable<ReceiptInfo> GetAllReceiptInfo(int receiptId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ReceiptInfo>> GetAllReceiptInfoAsync(int userId)
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

        public Receipt? GetReceiptById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Receipt?> GetReceiptByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
