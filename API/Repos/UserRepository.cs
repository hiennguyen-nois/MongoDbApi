using API.Data;
using API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;
        public UserRepository(IDataContext myWorldContext)
        {
            _userCollection = myWorldContext.DataDb.GetCollection<User>("Users");
        }

        public async Task<IList<User>> GetAllAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<User?> GetByIDAsync(string id) =>
            await _userCollection.Find(lv => lv.Id == id).FirstOrDefaultAsync();

        public async Task AddUserAsync(User creature) =>
            await _userCollection.InsertOneAsync(creature);

        public async Task UpdateUserAsync(string id, User updatedUser) =>
            await _userCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);


        public async Task DeleteUserAsync(string id) =>
            await _userCollection.DeleteOneAsync(x => x.Id == id);
    }
}
