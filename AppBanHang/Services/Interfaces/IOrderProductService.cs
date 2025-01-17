using AppBanHang.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Interfaces
{
    public interface IOrderProductService
    {
        IEnumerable<OrderProduct> GetAllOrderProductByOrderId(int orderId);
        OrderProduct GetOrderProduct(int orderId, int productId);
        OrderProduct AddOrderProduct(OrderProduct orderProduct);
        bool DeleteOrderProduct(int orderId, int productId);
        OrderProduct UpdateOrderProduct(OrderProduct orderProduct);

        Task<IEnumerable<OrderProduct>> GetAllOrderProductByOrderIdAsync(int orderId);
        Task<OrderProduct> GetOrderProductAsync(int orderId, int productId);
        Task<OrderProduct> AddOrderProductAsync(int orderId, Product product);
        Task<bool> DeleteOrderProductAsync(int orderId, int productId);
        Task<bool> UpdateOrderProductAsync(OrderProduct product);
    }
}
