using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Implementations
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;
        public OrderProductService(IOrderProductRepository orderProductRepository)
        {
            _orderProductRepository = orderProductRepository;
        }

        public OrderProduct AddOrderProduct(OrderProduct orderProduct)
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderProduct> AddOrderProductAsync(int orderId, Product product)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteOrderProduct(int orderId, int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteOrderProductAsync(int orderId, int productId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<OrderProduct> GetAllOrderProductByOrderId(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<OrderProduct>> GetAllOrderProductByOrderIdAsync(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public OrderProduct GetOrderProduct(int orderId, int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderProduct> GetOrderProductAsync(int orderId, int productId)
        {
            throw new System.NotImplementedException();
        }

        public OrderProduct UpdateOrderProduct(OrderProduct orderProduct)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateOrderProductAsync(OrderProduct orderProduct)
        {
            throw new System.NotImplementedException();
        }
    }
}
