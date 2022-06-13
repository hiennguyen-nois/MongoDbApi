using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repos
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity obj);
        Task<TEntity> UpdateAsync(string id, TEntity obj);
        Task<bool> DeleteAsync(string id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(string id);
    }
}
