using API.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repos
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _collection;

        protected BaseRepository(string collectionName, IDataContext context)
        {
            _collection = context.DataDb.GetCollection<TEntity>(collectionName);
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            var data = await _collection.Find(Filter(id)).SingleOrDefaultAsync();
            return data;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var all = await _collection.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public async Task<TEntity> CreateAsync(TEntity obj)
        {
            await _collection.InsertOneAsync(obj);
            return obj;
        }


        public async Task<TEntity> UpdateAsync(string id, TEntity obj)
        {
            await _collection.ReplaceOneAsync(Filter(id), obj);
            return obj;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(Filter(id));
            return result.IsAcknowledged;
        }
        private static FilterDefinition<TEntity> Filter(string key)
        {
            return Builders<TEntity>.Filter.Eq("Id", key);
        }

        private static FilterDefinition<TEntity> Filter(string fieldName, string key)
        {
            return Builders<TEntity>.Filter.Eq(fieldName, key);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
