using AppBanHang.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Interfaces
{
    public interface IReceiptService
    {
        IEnumerable<Receipt> GetAllReceiptsByUserId(int userId);
        Receipt? GetReceiptById(int id);
        Receipt AddReceipt(Receipt receipt);

        Task<IEnumerable<Receipt>> GetAllReceiptsByUserIdAsync(int userId);
        Task<Receipt?> GetReceiptByIdAsync(int id);
        Task<Receipt> AddReceiptAsync(Receipt receipt);
    }
}
