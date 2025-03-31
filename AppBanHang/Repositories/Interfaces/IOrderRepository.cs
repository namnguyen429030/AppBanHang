using AppBanHang.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<int, Order>
    {
        IEnumerable<Order> GetAllByOwnerId(int ownerId);
    }
}
