using AppBanHang.Models;
using System.Threading.Tasks;

namespace AppBanHang.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<int, User>
    {
        User? GetByUsername(string username);
        Task<User?> GetByUsernameAsync(string username);
    }
}
