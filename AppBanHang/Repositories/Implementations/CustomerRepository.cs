using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Repositories.Implementations
{
    public class CustomerRepository : Repository, ICustomerRepository
    {
        public CustomerRepository(ShopManagementAppContext shopManagementAppContext) : base(shopManagementAppContext)
        {
        }

        public Customer Add(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> AddAsync(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Customer? GetByKey(int key)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer?> GetByKeyAsync(int key)
        {
            throw new System.NotImplementedException();
        }

        public Customer Update(Customer entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
