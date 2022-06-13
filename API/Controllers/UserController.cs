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
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _userRepository.CreateAsync(user);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            var userUpdated = await _userRepository.GetByIdAsync(user.Id);
            if (userUpdated == null)
                return NotFound();
            await _userRepository.UpdateAsync(user.Id, user);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var userDeleted = await _userRepository.GetByIdAsync(id);
            if (userDeleted == null)
                return NotFound();
            await _userRepository.DeleteAsync(id);
            return Ok();
        }

    }
}
