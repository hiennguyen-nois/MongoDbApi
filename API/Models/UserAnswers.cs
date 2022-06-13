using MongoDB.Bson.Serialization.Attributes;

namespace API.Models
{
    public class UserAnswers : Questions
    {
        public UserAnswers(Questions question, string userAnswer)
        {
            QuestionNumber = question.QuestionNumber;
            Question = question.Question;
            Answers = question.Answers;
            RightAnswer = question.RightAnswer;
            UserAnswer = userAnswer;
        }

        [BsonElement("userAnswer")]
        public string? UserAnswer { get; set; }

    }
}
