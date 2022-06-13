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
            var quiz = await _quizRepository.GetByIdAsync(id);
            if (quiz == null)
                return NotFound();
            return Ok(quiz);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Quiz quiz)
        {
            await _quizRepository.CreateAsync(quiz);
            return Ok();
        }

        [HttpPost("marking")]
        public async Task<ActionResult<User>> Marking(QuizAnswerDTO quizAnswerDTO)
        {
            var user = await _userRepository.GetByIdAsync(quizAnswerDTO.UserId);
            if (user == null)
                return BadRequest("User not found");

            var quiz = await _quizRepository.GetByIdAsync(quizAnswerDTO.QuizId);
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

            await _userRepository.UpdateAsync(user.Id, user);

            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Quiz quiz)
        {
            var quizUpdated = await _quizRepository.GetByIdAsync(quiz.Id);
            if (quizUpdated == null)
                return NotFound();
            await _quizRepository.UpdateAsync(quiz.Id, quiz);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var quizDeleted = await _quizRepository.GetByIdAsync(id);
            if(quizDeleted == null)
                return NotFound();
            await _quizRepository.DeleteAsync(id);
            return Ok();
        }

    }
}
