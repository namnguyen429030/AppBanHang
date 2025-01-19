using AppBanHang.Exceptions;
using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Interfaces;
using BCrypt.Net;
using System.Reactive.Linq;
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
        private User? _currentUser;

        public event IUserService.ChangeUserHandler? CurrentUserChanged;

        public User? CurrentUser => _currentUser;
        public User AddUser(User user)
        {
            var duplicateUsername = GetUserByUserName(user.UserName);
            if(duplicateUsername != null)
            {
                throw new InvalidRegistrationException();
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return _userRepository.Add(user);
        }

        public async Task<User> AddUserAsync(User user)
        {
            var duplicateUsername = await GetUserByUserNameAsync(user.UserName);
            if (duplicateUsername != null)
            {
                throw new InvalidRegistrationException();
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user = await _userRepository.AddAsync(user);
            return user;
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

        public User? GetUserByUserName(string userName)
        {
            return _userRepository.GetByUsername(userName);
        }
        public async Task<User?> GetUserByUserNameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }

        public User UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> UpdateUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public User Login(string userName, string password)
        {
            var searchedUser = GetUserByUserName(userName);
            if(searchedUser == null)
            {
                throw new InvalidLoginException();
            }
            if(!BCrypt.Net.BCrypt.Verify(password, searchedUser.Password))
            {
                throw new BcryptAuthenticationException();
            }
            _currentUser = searchedUser;
            CurrentUserChanged?.Invoke(_currentUser);
            return searchedUser;
        }

        public async Task<User> LoginAsync(string userName, string password)
        {
            var searchedUser = await GetUserByUserNameAsync(userName);
            if (searchedUser == null)
            {
                throw new InvalidLoginException();
            }
            if (!BCrypt.Net.BCrypt.Verify(password, searchedUser.Password))
            {
                throw new BcryptAuthenticationException();
            }
            _currentUser = searchedUser;
            CurrentUserChanged?.Invoke(_currentUser);
            return searchedUser;
        }
    }
}
