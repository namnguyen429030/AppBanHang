using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Implementations
{
    public class ReceiptInfoService : IReceiptInforService
    {
        private readonly IReceiptInfoRepository _receiptInfoRepository;
        public ReceiptInfoService(IReceiptInfoRepository receiptInfoRepository)
        {
            _receiptInfoRepository = receiptInfoRepository;
        }

        public ReceiptInfo AddReceiptInfo(ReceiptInfo receiptInfo)
        {
            throw new System.NotImplementedException();
        }

        public Task<ReceiptInfo> AddReceiptInfoAsync(ReceiptInfo receiptInfo)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteReceiptInfo(int reReceiptId, int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteReceiptInfoAsync(int receiptId, int productId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ReceiptInfo> GetAllReceiptInfosByReceiptId(int receiptId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ReceiptInfo>> GetAllReceiptInfosByReceiptIdAsync(int receiptId)
        {
            throw new System.NotImplementedException();
        }

        public ReceiptInfo GetReceiptInfo(int receiptId, int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ReceiptInfo> GetReceiptInfoAsync(int receiptId, int productId)
        {
            throw new System.NotImplementedException();
        }

        public ReceiptInfo UpdateReceiptInfo(ReceiptInfo receiptInfo)
        {
            throw new System.NotImplementedException();
        }

        public Task<ReceiptInfo> UpdateReceiptInfoAsync(ReceiptInfo receiptInfo)
        {
            throw new System.NotImplementedException();
        }
    }
}
