using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order AddOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> AddOrderAsync(Order order)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteOrder(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteOrderAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrdersByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrdersByUserIdAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Order UpdateOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> UpdateOrderAsync(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
