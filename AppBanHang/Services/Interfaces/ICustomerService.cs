using AppBanHang.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer? GetCustomerById(int id);
        Customer UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);
        Customer AddCustomer(Customer customer);

        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync();
        Task<Customer> AddCustomerAsync(Customer customer);
    }
}
