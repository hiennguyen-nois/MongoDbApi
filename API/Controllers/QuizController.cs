using API.DTOs;
using API.Models;
using API.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository _quizRepository;

        public QuizController(IQuizRepository QuizRepository)
        {
            _quizRepository = QuizRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _quizRepository.GetAllAsync());
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Quiz>> GetById(string id)
        {
            var creature = await _quizRepository.GetByIDAsync(id);
            if (creature == null)
                return NotFound();
            return Ok(creature);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Quiz creature)
        {
            await _quizRepository.AddQuizAsync(creature);
            return Ok();
        }

        [HttpPost("marking")]
        public async Task<IActionResult> Marking(QuizAnswerDTO quizAnswerDTO)
        {
            int totalRightAnswer = 0;
            var quiz = await _quizRepository.GetByIDAsync(quizAnswerDTO.QuizId);

            foreach (var answer in quizAnswerDTO.Answers)
            {
                var i = quiz.Questions.FirstOrDefault(a => a.QuestionNumber == answer.QuestionNumber);
                if (i != null && i.RightAnswer.Equals(answer.Answer))
                    totalRightAnswer++;
            }
            return Ok(totalRightAnswer * 5);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Quiz creature)
        {
            var creatureUpdated = await _quizRepository.GetByIDAsync(creature.Id);
            if (creatureUpdated == null)
                return NotFound();
            await _quizRepository.UpdateQuizAsync(creature.Id, creature);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var creatureDeleted = await _quizRepository.GetByIDAsync(id);
            if(creatureDeleted == null)
                return NotFound();
            await _quizRepository.DeleteQuizAsync(id);
            return Ok();
        }

    }
}
