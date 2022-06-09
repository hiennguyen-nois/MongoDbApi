using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface ILivingCreatureService
    {
        Task<LivingCreature> CreateLivingCreatureAsync(LivingCreature obj);
        Task<LivingCreature> UpdateLivingCreatureAsync(string id, LivingCreature obj);
        Task<bool> DeleteLivingCreatureAsync(string id);
        Task<LivingCreature> GetByIdAsync(string id);
        Task<IEnumerable<LivingCreature>> GetAll();
    }
}
