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
            _collection = myWorldContext.MyWorldDb.GetCollection<TEntity>(options.Value.LivingCreatureCollection);
        }


        public async Task<TEntity> GetById(string id)
        {
            var data = await _collection.Find(FilterId(id)).SingleOrDefaultAsync();
            return data;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await _collection.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public async Task<TEntity> Create(TEntity obj)
        {
            await _collection.InsertOneAsync(obj);
            return obj;
        }


        public async Task<TEntity> Update(string id, TEntity obj)
        {
            await _collection.ReplaceOneAsync(FilterId(id), obj);
            return obj;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _collection.DeleteOneAsync(FilterId(id));
            return result.IsAcknowledged;
        }
        private static FilterDefinition<TEntity> FilterId(string key)
        {
            return Builders<TEntity>.Filter.Eq("Id", key);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
