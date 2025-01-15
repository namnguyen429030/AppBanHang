using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Interfaces;

namespace AppBanHang.Services.Implementations
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;
        public ReceiptService(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }
    }
}
