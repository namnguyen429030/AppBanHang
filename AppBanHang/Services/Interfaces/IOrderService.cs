using AppBanHang.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrdersByUserId(int userId);
        Order GetOrderById(int id);
        Order UpdateOrder(Order order);
        Order AddOrder(Order order);
        bool DeleteOrder(int id);

        Task<IEnumerable<Order>> GetAllOrdersByUserIdAsync(int userId);
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> UpdateOrderAsync(Order order);
        Task<Order> AddOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int id);
    }
}
