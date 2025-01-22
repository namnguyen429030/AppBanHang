using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Repositories.Implementations
{
    public class OrderProductRepository : Repository, IOrderProductRepository
    {
        public OrderProductRepository(ShopManagementAppContext shopManagementAppContext) : base(shopManagementAppContext)
        {
        }

        public OrderProduct Add(OrderProduct entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderProduct> AddAsync(OrderProduct entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(OrderProduct entity)
        {
            throw new System.NotImplementedException();
        }
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<OrderProduct> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<OrderProduct>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public OrderProduct? GetByKey(int key)
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderProduct?> GetByKeyAsync(int key)
        {
            throw new System.NotImplementedException();
        }

        public OrderProduct Update(OrderProduct entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
