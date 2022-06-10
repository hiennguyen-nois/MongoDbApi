using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repos
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Create(TEntity obj);
        Task<TEntity> Update(string id, TEntity obj);
        Task<bool> Delete(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAllByField(string filedName, string id);
        Task<TEntity> GetById(string id);
    }
}
