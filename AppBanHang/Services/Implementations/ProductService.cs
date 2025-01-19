using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product AddProduct(Product product)
        {
            return _productRepository.Add(product);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            return await _productRepository.AddAsync(product);
        }

        public bool DeleteProduct(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public async Task<IEnumerable<Product>> GetAllProductsByUserIdAsync(int userId)
        {
            return await _productRepository.GetAllByOwnerIdAsync(userId);
        }

        public Product GetProductById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAllProductsByUserId(int userId)
        {
            return _productRepository.GetAllByOwnerId(userId);
        }

        public Product UpdateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> UpdateProductAsync(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
