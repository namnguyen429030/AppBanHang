using AppBanHang.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrdersByUserId(int userId);
        Order? GetOrderById(int id);
        Order UpdateOrder(Order order, IEnumerable<OrderProduct> orderProducts);
        Order AddOrder(Order order, IEnumerable<OrderProduct> orderProducts);
        bool DeleteOrder(int id);

        Task<IEnumerable<Order>> GetAllOrdersByUserIdAsync(int userId);
        Task<Order?> GetOrderByIdAsync(int id);
        Task<Order> UpdateOrderAsync(Order order, IEnumerable<OrderProduct> orderProducts);
        Task<Order> AddOrderAsync(Order order, IEnumerable<OrderProduct> orderProducts);
        Task<Order> DeleteOrderAsync(int id);
    }
}
