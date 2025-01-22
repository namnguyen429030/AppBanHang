using AppBanHang.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Interfaces
{
    public interface IReceiptService
    {
        IEnumerable<Receipt> GetAllReceiptsByUserId(int userId);
        IEnumerable<ReceiptInfo> GetAllReceiptInfo(int receiptId);
        Receipt? GetReceiptById(int id);
        Receipt AddReceipt(Receipt receipt, IEnumerable<ReceiptInfo> receiptInfo);

        Task<IEnumerable<Receipt>> GetAllReceiptsByUserIdAsync(int userId);
        Task<IEnumerable<ReceiptInfo>> GetAllReceiptInfoAsync(int userId);
        Task<Receipt?> GetReceiptByIdAsync(int id);
        Task<Receipt> AddReceiptAsync(Receipt receipt, IEnumerable<ReceiptInfo> receiptInfo);
    }
}
