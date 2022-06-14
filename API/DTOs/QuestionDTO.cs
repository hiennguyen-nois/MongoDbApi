using System.Collections.Generic;

namespace API.DTOs
{
    public class QuestionDTO
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public IList<AnswerDTO> Answers { get; set; }
    }
}