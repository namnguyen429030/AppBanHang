using AppBanHang.Models;
using AppBanHang.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBanHang.Repositories.Implementations
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(ShopManagementAppContext shopManagementAppContext) : base(shopManagementAppContext)
        {
        }

        public User Add(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> AddAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(User entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int key)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int key)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public User? GetByKey(int key)
        {
            throw new System.NotImplementedException();
        }

        public Task<User?> GetByKeyAsync(int key)
        {
            throw new System.NotImplementedException();
        }

        public User? Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<User?> UpdateAsync(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
