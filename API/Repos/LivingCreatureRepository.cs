using API.Data;
using API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repos
{
    public class LivingCreatureRepository : ILivingCreatureRepository
    {
        private readonly IMongoCollection<LivingCreature> _livingCreatureCollection;
        public LivingCreatureRepository(IOptions<AppSettings> options, IMyWorldContext myWorldContext)
        {
            _livingCreatureCollection = myWorldContext.MyWorldDb.GetCollection<LivingCreature>(options.Value.LivingCreatureCollection);
        }

        public async Task<IList<LivingCreature>> GetAllAsync() =>
            await _livingCreatureCollection.Find(_ => true).ToListAsync();

        public async Task<LivingCreature?> GetByIDAsync(string id) =>
            await _livingCreatureCollection.Find(lv => lv.Id == id).FirstOrDefaultAsync();

        public async Task AddCreatureAsync(LivingCreature creature) =>
            await _livingCreatureCollection.InsertOneAsync(creature);

        public async Task UpdateCreatureAsync(string id, LivingCreature updatedBook) =>
            await _livingCreatureCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);


        public async Task DeleteCreatureAsync(string id) =>
            await _livingCreatureCollection.DeleteOneAsync(x => x.Id == id);
    }
}
