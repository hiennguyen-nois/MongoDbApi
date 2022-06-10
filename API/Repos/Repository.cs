using API.Data;
using API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repos
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _collection;

        protected Repository(IOptions<AppSettings> options, IMyWorldContext myWorldContext)
        {
            _collection = myWorldContext.MyWorldDb.GetCollection<TEntity>(options.Value.CollectionName);
        }


        public async Task<TEntity> GetById(string id)
        {
            var data = await _collection.Find(Filter(id)).SingleOrDefaultAsync();
            return data;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await _collection.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllByField(string fieldName, string key)
        {
            var all = await _collection.FindAsync(Filter(fieldName, key));
            return all.ToList();
        }

        public async Task<TEntity> Create(TEntity obj)
        {
            await _collection.InsertOneAsync(obj);
            return obj;
        }


        public async Task<TEntity> Update(string id, TEntity obj)
        {
            await _collection.ReplaceOneAsync(Filter(id), obj);
            return obj;
        }

        public async Task<bool> Delete(string id)
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
