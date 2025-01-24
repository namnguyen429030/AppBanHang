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

        public event IProductService.ProductsUpdatedHandler? ProductUpdated;
        public event IProductService.ProductsUpdatedHandler? ProductDeleted;
        public event IProductService.ProductsUpdatedHandler? ProductAdded;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product AddProduct(Product product)
        {
            var newProduct = _productRepository.Add(product);
            ProductAdded?.Invoke(newProduct);
            return newProduct;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            var newProduct = await _productRepository.AddAsync(product);
            ProductUpdated?.Invoke(newProduct);
            return newProduct;
        }

        public bool DeleteProduct(int id)
        {
            var searchedProduct = _productRepository.GetByKey(id);
            if(searchedProduct == null)
            {
                return false;
            }
            _productRepository.Delete(searchedProduct);
            ProductDeleted?.Invoke(searchedProduct);
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var searchProduct = await _productRepository.GetByKeyAsync(id);
            if(searchProduct == null)
            {
                return false;
            }
            await _productRepository.DeleteAsync(searchProduct);
            ProductDeleted?.Invoke(searchProduct);
            return true;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public async Task<IEnumerable<Product>> GetAllProductsByUserIdAsync(int userId)
        {
            return await _productRepository.GetAllByOwnerIdAsync(userId);
        }

        public Product? GetProductById(int id)
        {
            return _productRepository.GetByKey(id);
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByKeyAsync(id);
        }

        public IEnumerable<Product> GetAllProductsByUserId(int userId)
        {
            return _productRepository.GetAllByOwnerId(userId);
        }

        public Product? UpdateProduct(Product product)
        {
            if (GetProductById(product.Id) == null)
            {
                return null;
            }
            var newProduct = _productRepository.Update(product);
            ProductUpdated?.Invoke(newProduct);
            return newProduct;
        }

        public async Task<Product?> UpdateProductAsync(Product product)
        {
            if (await GetProductByIdAsync(product.Id) == null)
            {
                return null;
            }
            var newProduct = await _productRepository.UpdateAsync(product);
            ProductUpdated?.Invoke(newProduct); 
            return newProduct;
        }
    }
}
