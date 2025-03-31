using AppBanHang.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<int, Product>
    {
        IEnumerable<Product> GetAllByOwnerId(int ownerId);
    }
}
