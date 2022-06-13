using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.Collections.Generic;

namespace API.Models
{
    [BsonNoId]
    public class Result
    {
        [BsonElement("quizId")]
        public string? QuizId { get; set; }

        [BsonElement("quizName")]
        public string? QuizName { get; set; }

        [BsonElement("userAnswer")]
        public IList<UserAnswers> UserAnswers { get; set; }

        [BsonElement("totalRightAnswer")]
        public int TotalRightAnswer { get; set; }

        [BsonElement("totalScore")]
        public int TotalScore { get; set; }

    }
}
