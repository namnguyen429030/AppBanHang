using AppBanHang.Models;
using System.Threading.Tasks;

namespace AppBanHang.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        User GetUserByUserName(string userName);
        User AddUser(User user);
        bool DeleteUser(int id);
        User UpdateUser(User user);

        Task<User> AddUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUserNameAsync(string username);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
