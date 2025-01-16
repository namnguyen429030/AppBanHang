using AppBanHang.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        Customer UpdateCustomer(int id, Customer customer);
        bool DeleteCustomer(int id);
        Customer AddCustomer(Customer customer);

        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync();
        Task<Customer> UpdateCustomerAsync(int id, Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
        Task<Customer> AddCustomerAsync(Customer customer);
    }
}
