using System.Collections.Generic;

namespace API.DTOs
{
    public class QuizResultDTO
    {
        public int TotalRightAnswers { get; set; }
        public ICollection<AnswerDTO> YourAnswers { get; set; }
        public int TotalScore { get; set; }
    }
}
