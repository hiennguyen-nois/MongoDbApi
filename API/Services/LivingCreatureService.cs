using API.Models;
using API.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class LivingCreatureService : ILivingCreatureService
    {
        private readonly ILivingCreatureRepository _livingCreatureRepository;

        public LivingCreatureService(ILivingCreatureRepository livingCreatureRepository)
        {
            _livingCreatureRepository = livingCreatureRepository;
        }

        public async Task<LivingCreature> CreateLivingCreatureAsync(LivingCreature obj)
        {
            return await _livingCreatureRepository.Create(obj);
        }

        public async Task<IEnumerable<LivingCreature>> GetAll()
        {
            return await _livingCreatureRepository.GetAll();
        }

        public async Task<LivingCreature> GetByIdAsync(string id)
        {
            return await _livingCreatureRepository.GetById(id);
        }

        public async Task<bool> DeleteLivingCreatureAsync(string id)
        {
            return await _livingCreatureRepository.Delete(id);
        }

        public async Task<LivingCreature> UpdateLivingCreatureAsync(string id, LivingCreature obj)
        {
            return await _livingCreatureRepository.Update(id, obj);
        }
    }
}
