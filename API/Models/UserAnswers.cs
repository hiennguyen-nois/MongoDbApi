using MongoDB.Bson.Serialization.Attributes;

namespace API.Models
{
    public class UserAnswers : Questions
    {
        public UserAnswers(Questions question, string userAnswer)
        {
            UserAnswer = userAnswer;
            QuestionNumber = question.QuestionNumber;
            Question = question.Question;
            Answers = question.Answers;
            RightAnswer = question.RightAnswer;
        }

        [BsonElement("userAnswer")]
        public string? UserAnswer { get; set; }

    }
}
