using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer AddCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> AddCustomerAsync(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteCustomer(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteCustomerAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> GetCustomerByIdAsync()
        {
            throw new System.NotImplementedException();
        }

        public Customer UpdateCustomer(int id, Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> UpdateCustomerAsync(int id, Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
