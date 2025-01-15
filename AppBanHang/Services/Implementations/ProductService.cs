using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Interfaces;

namespace AppBanHang.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
