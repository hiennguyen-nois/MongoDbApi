using API.DTOs;
using API.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using API.Entities.Test;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;
        private readonly IUserRepository _userRepository;

        public TestController(ITestRepository testRepository, IUserRepository userRepository)
        {
            _testRepository = testRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _testRepository.GetAllAsync());
        }

        [HttpGet("dto")]
        public async Task<ActionResult<IList<TestDTO>>> GetAllDTO()
        {
            var tests = await _testRepository.GetAllAsync();
            List<TestDTO> testDTOList = await MapListTestToTestDTO(tests);
            return Ok(testDTOList);
        }



        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Tests>> GetById(string id)
        {
            var test = await _testRepository.GetByIdAsync(id);
            if (test == null)
                return NotFound();
            return Ok(test);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tests test)
        {
            test.CreatedAt = System.DateTime.UtcNow;
            Console.WriteLine(test.TimeForEachQuestion);
            await _testRepository.CreateAsync(test);
            return Ok();
        }

        

        [HttpPut]
        public async Task<IActionResult> Update(Tests test)
        {
            var testUpdated = await _testRepository.GetByIdAsync(test.Id);
            if (testUpdated == null)
                return NotFound();
            await _testRepository.UpdateAsync(test.Id, test);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var testDeleted = await _testRepository.GetByIdAsync(id);
            if(testDeleted == null)
                return NotFound();
            await _testRepository.DeleteAsync(id);
            return Ok();
        }


       private TestDTO MapTestToTestDTO(Tests tests)
        {
            return new TestDTO
            {
                Id = tests.Id,
                Name = tests.Name,
                ActiveFor = (System.TimeSpan)
                            (tests.ActiveFor != null ? tests.ActiveFor : null),
                TimeForEachQuestion = (System.TimeSpan)
                        (tests.TimeForEachQuestion != null ? tests.TimeForEachQuestion : null),
                CreatedAt = tests.CreatedAt,
                Status = tests.Status,
                PassMarkUnit = tests.PassMarkUnit,
                PassMarkValue = tests.PassMarkValue,
                Questions = MapListQuestionToListQuestionDTO(tests.Questions)
            };
             
        }

        private QuestionDTO MapQuestionToQuestionDTO(Question question)
        {
            return new QuestionDTO
            {
                Number = question.Number,
                Text = question.Text,
                Type = question.Type,
                Answers = MapListAnswerToListAnswerDTO(question.Answers)
            };
        }

        private AnswerDTO MapAnswerToAnswerDTO(Answer answer)
        {
            return new AnswerDTO
            {
                Number = answer.Number,
                Text = answer.Text,
                IsCorrect = answer.IsCorrect
            };
        }

        private IList<AnswerDTO> MapListAnswerToListAnswerDTO(IList<Answer> answers)
        {
            var answerDTOList = new List<AnswerDTO>();
            if (answers == null)
                return null;
            foreach(var answer in answers)
            {
                var answerDTO = MapAnswerToAnswerDTO(answer);
                answerDTOList.Add(answerDTO);
            }
            return answerDTOList;
        }

        private IList<QuestionDTO> MapListQuestionToListQuestionDTO(IList<Question> questions)
        {
            var questionDTOList = new List<QuestionDTO>();
            foreach (var question in questions)
            {
                var questionDTO = MapQuestionToQuestionDTO(question);
                questionDTOList.Add(questionDTO);
            }
            return questionDTOList;
        }

        private async Task<List<TestDTO>> MapListTestToTestDTO(IEnumerable<Tests> tests)
        {
            var testDTOList = new List<TestDTO>();
            foreach (var test in tests)
            {
                var testDTO = MapTestToTestDTO(test);
                var userCreate = await _userRepository.GetByIdAsync(test.CreatedByUserId);
                testDTO.CreatedByUser = userCreate.FirstName + " " + userCreate.LastName;
                testDTOList.Add(testDTO);
            }

            return testDTOList;
        }

    }

}
