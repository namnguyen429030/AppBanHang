using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Interfaces;

namespace AppBanHang.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
