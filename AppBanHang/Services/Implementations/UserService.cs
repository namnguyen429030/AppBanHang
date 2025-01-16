using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Interfaces;
using System.Threading.Tasks;

namespace AppBanHang.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User AddUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> AddUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserByUserName(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUserByUserNameAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> UpdateUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
