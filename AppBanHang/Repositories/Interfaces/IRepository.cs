using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang.Repositories.Interfaces
{
    public interface IRepository<TKey, TEntity> : IDisposable where TEntity : class
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity? GetByKey(TKey key);
        TEntity? Update(TEntity entity);
        bool Delete(TEntity entity);
        bool Delete(TKey key);

        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity?> GetByKeyAsync(TKey key);
        Task<TEntity?> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> DeleteAsync(TKey key);
    }
}
