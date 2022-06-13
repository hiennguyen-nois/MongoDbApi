using API.Models;
using API.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userRepository.GetAllAsync());
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<User>> GetById(string id)
        {
            var creature = await _userRepository.GetByIDAsync(id);
            if (creature == null)
                return NotFound();
            return Ok(creature);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User creature)
        {
            await _userRepository.AddUserAsync(creature);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Update(User creature)
        {
            var creatureUpdated = await _userRepository.GetByIDAsync(creature.Id);
            if (creatureUpdated == null)
                return NotFound();
            await _userRepository.UpdateUserAsync(creature.Id, creature);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var creatureDeleted = await _userRepository.GetByIDAsync(id);
            if (creatureDeleted == null)
                return NotFound();
            await _userRepository.DeleteUserAsync(id);
            return Ok();
        }

    }
}
