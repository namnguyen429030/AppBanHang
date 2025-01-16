using AppBanHang.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrdersByUserId(int userId);
        Order GetOrderById(int id);
        Order UpdateOrder(int id, Order order);
        Order AddOrder(Order order);
        bool DeleteOrder(int id);

        Task<IEnumerable<Order>> GetAllOrdersByUserIdAsync(int userId);
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> UpdateOrderAsync(int id, Order order);
        Task<Order> AddOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int id);
    }
}
