using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repos
{
    public interface IUserRepository
    {
        Task<IList<User>> GetAllAsync();
        Task<User?> GetByIDAsync(string id);
        Task AddUserAsync(User creature);
        Task UpdateUserAsync(string id, User updatedUser);
        Task DeleteUserAsync(string id);
    }
}
