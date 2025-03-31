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
        private readonly IOrderProductRepository _orderProductRepository;
        public OrderService(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository)
        {
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
        }

        public Order AddOrder(Order order, IEnumerable<OrderProduct> orderProducts)
        {
            _orderRepository.Add(order);
            foreach (var orderProduct in orderProducts)
            {
                orderProduct.OrderId = order.Id;
            }
            return order;
        }

        public Task<Order> AddOrderAsync(Order order, IEnumerable<OrderProduct> orderProducts)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteOrder(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> DeleteOrderAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrdersByUserId(int userId)
        {
            return _orderRepository.GetAllByOwnerId(userId);
        }

        public Task<IEnumerable<Order>> GetAllOrdersByUserIdAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order?> GetOrderByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
        public Order UpdateOrder(Order order, IEnumerable<OrderProduct> orderProducts)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> UpdateOrderAsync(Order order, IEnumerable<OrderProduct> orderProducts)
        {
            throw new System.NotImplementedException();
        }
    }
}
