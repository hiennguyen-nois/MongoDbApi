using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repos
{
    public interface ILivingCreatureRepository
    {
        Task<IList<LivingCreature>> GetAllAsync();
        Task<LivingCreature?> GetByIDAsync(string id);
        Task AddCreatureAsync(LivingCreature creature);
        Task UpdateCreatureAsync(string id, LivingCreature updatedBook);
        Task DeleteCreatureAsync(string id);
    }
}
