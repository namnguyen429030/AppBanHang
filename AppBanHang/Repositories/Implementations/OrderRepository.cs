using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Repositories.Implementations
{
    public class OrderRepository : Repository, IOrderRepository
    {
        public OrderRepository(ShopManagementAppContext shopManagementAppContext) : base(shopManagementAppContext)
        {
        }

        public Order Add(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> AddAsync(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Order entity)
        {
            throw new System.NotImplementedException();
        }
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Order? GetByKey(int key)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order?> GetByKeyAsync(int key)
        {
            throw new System.NotImplementedException();
        }

        public Order Update(Order entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
