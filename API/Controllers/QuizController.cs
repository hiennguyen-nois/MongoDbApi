using API.DTOs;
using API.Models;
using API.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IUserRepository _userRepository;

        public QuizController(IQuizRepository quizRepository, IUserRepository userRepository)
        {
            _quizRepository = quizRepository;
            _userRepository = userRepository;
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
        public async Task<ActionResult<User>> Marking(QuizAnswerDTO quizAnswerDTO)
        {
            var user = await _userRepository.GetByIDAsync(quizAnswerDTO.UserId);
            if (user == null)
                return BadRequest("User not found");

            var quiz = await _quizRepository.GetByIDAsync(quizAnswerDTO.QuizId);
            if (quiz == null)
                return BadRequest("Quiz not found");


            var quizResult = new Result{
                QuizId = quiz.Id,
                QuizName = quiz.Name,
                UserAnswers = new List<UserAnswers>(),
                TotalRightAnswer = 0,
                TotalScore = 0
            };

            int rightAnswer = 0;
            foreach (var answer in quizAnswerDTO.Answers)
            {
                var question = quiz.Questions.FirstOrDefault(a => a.QuestionNumber == answer.QuestionNumber);

                if (question != null)
                {
                    var userAnswer = new UserAnswers(question, answer.Answer);
                    quizResult.UserAnswers.Add(userAnswer);
                    if(question.RightAnswer.Equals(answer.Answer))
                        rightAnswer++;
                }
            }

            quizResult.TotalRightAnswer = rightAnswer;
            quizResult.TotalScore = rightAnswer * 5;

            if (user.Results == null)
            {
                user.Results = new List<Result>()
                {
                    quizResult
                };
            }
            else
                user.Results.Add(quizResult);

            await _userRepository.UpdateUserAsync(user.Id, user);

            return Ok(user);
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
