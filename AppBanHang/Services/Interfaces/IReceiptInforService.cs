using AppBanHang.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Interfaces
{
    public interface IReceiptInforService
    {
        IEnumerable<ReceiptInfo> GetAllReceiptInfosByReceiptId(int receiptId);
        ReceiptInfo GetReceiptInfo(int receiptId, int productId);
        ReceiptInfo AddReceiptInfo(ReceiptInfo receiptInfo);
        ReceiptInfo UpdateReceiptInfo(ReceiptInfo receiptInfo);
        bool DeleteReceiptInfo(int reReceiptId, int productId);

        Task<IEnumerable<ReceiptInfo>> GetAllReceiptInfosByReceiptIdAsync(int receiptId);
        Task<ReceiptInfo> GetReceiptInfoAsync(int receiptId, int productId);
        Task<ReceiptInfo> AddReceiptInfoAsync(ReceiptInfo receiptInfo);
        Task<ReceiptInfo> UpdateReceiptInfoAsync(ReceiptInfo receiptInfo);
        Task<bool> DeleteReceiptInfoAsync(int receiptId, int productId);
    }
}
