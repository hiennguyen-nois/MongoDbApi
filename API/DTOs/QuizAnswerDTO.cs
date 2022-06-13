using System.Collections.Generic;

namespace API.DTOs
{
    public class QuizAnswerDTO
    {
        public string QuizId { get; set; }
        public string UserId { get; set; }
        public IList<AnswerDTO> Answers { get; set; }
    }
}
