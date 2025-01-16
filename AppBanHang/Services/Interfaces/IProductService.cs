using AppBanHang.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductsByUserId(int userId);
        Product GetProductById(int id);
        Product UpdateProduct(int id, Product product);
        bool DeleteProduct(int id);
        Product AddProduct(Product product);
        Task<IEnumerable<Product>> GetAllProductsByUserIdAsync(int userId);
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<Product> AddProductAsync(Product product);
    }
}
