using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace API.Models
{
    public class Result
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("quizId")]
        public string QuizId { get; set; }

        [BsonElement("quizName")]
        public string QuizName { get; set; }

        [BsonElement("userAnswer")]
        public IDictionary<Questions, string> UserAnswers { get; set; }

        [BsonElement("totalRightAnswer")]
        public int TotalRightAnswer { get; set; }

        [BsonElement("totalScore")]
        public int TotalScore { get; set; }

    }
}
