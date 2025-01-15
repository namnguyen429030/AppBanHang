using AppBanHang.Models;
using System.Collections.Generic;

namespace AppBanHang.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
    }
}
