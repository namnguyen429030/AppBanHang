using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Interfaces;

namespace AppBanHang.Services.Implementations
{
    public class ReceiptInfoService : IReceiptInforService
    {
        private readonly IReceiptInfoRepository _receiptInfoRepository;
        public ReceiptInfoService(IReceiptInfoRepository receiptInfoRepository)
        {
            _receiptInfoRepository = receiptInfoRepository;
        }
    }
}
