using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Repositories.Implementations
{
    public class CustomerOrderRepository : Repository, ICustomerOrderRepository
    {
        public CustomerOrderRepository(ShopManagementAppContext shopManagementAppContext) : base(shopManagementAppContext)
        {
        }

        public CustomerOrder Add(CustomerOrder entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<CustomerOrder> AddAsync(CustomerOrder entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(CustomerOrder entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int key)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(CustomerOrder entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int key)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CustomerOrder> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CustomerOrder>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public CustomerOrder? GetByKey(int key)
        {
            throw new System.NotImplementedException();
        }

        public Task<CustomerOrder?> GetByKeyAsync(int key)
        {
            throw new System.NotImplementedException();
        }

        public CustomerOrder? Update(CustomerOrder entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<CustomerOrder?> UpdateAsync(CustomerOrder entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
