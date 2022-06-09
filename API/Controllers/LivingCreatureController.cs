using API.Models;
using API.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivingCreatureController : ControllerBase
    {
        private readonly ILivingCreatureRepository _livingCreatureRepository;

        public LivingCreatureController(ILivingCreatureRepository livingCreatureRepository)
        {
            _livingCreatureRepository = livingCreatureRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivingCreature>>> GetAll()
        {
            var result = await _livingCreatureRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<LivingCreature>> GetById(string id)
        {
            var creature = await _livingCreatureRepository.GetById(id);
            if (creature == null)
                return NotFound();
            return Ok(creature);
        }


        [HttpPost]
        public async Task<IActionResult> Create(LivingCreature creature)
        {
            await _livingCreatureRepository.Create(creature);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(LivingCreature creature)
        {
            var creatureUpdated = await _livingCreatureRepository.GetById(creature.Id);
            if (creatureUpdated == null)
                return NotFound();
            await _livingCreatureRepository.Update(creature.Id, creature);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var creatureDeleted = await _livingCreatureRepository.GetById(id);
            if (creatureDeleted == null)
                return NotFound();
            await _livingCreatureRepository.Delete(id);
            return Ok();
        }

    }
}
