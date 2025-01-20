using AppBanHang.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Interfaces
{
    public interface IProductService
    {
        delegate void ProductsUpdatedHandler(Product product);
        event ProductsUpdatedHandler? ProductUpdated;
        event ProductsUpdatedHandler? ProductDeleted;
        event ProductsUpdatedHandler? ProductAdded;
        IEnumerable<Product> GetAllProductsByUserId(int userId);
        Product? GetProductById(int id);
        Product? UpdateProduct(Product product);
        bool DeleteProduct(int id);
        Product AddProduct(Product product);
        Task<IEnumerable<Product>> GetAllProductsByUserIdAsync(int userId);
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product?> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<Product> AddProductAsync(Product product);
    }
}
