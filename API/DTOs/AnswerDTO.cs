namespace API.DTOs
{
    public class AnswerDTO
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int PointIfCorrect { get; set; }
        public int PointIfIncorrect { get; set; }

    }
}