using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace API.Entities.Test
{
    public class Question
    {
        [BsonElement("number")]
        public int Number { get; set; }

        [BsonElement("text")]
        public string Text { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("maxNumberOfWords")]
        public int MaxNumberOfWords { get; set; }

        [BsonElement("maxPoints")]
        public int MaxPoints { get; set; }

        [BsonElement("maxNumberOfAnswers")]
        public int MaxNumberOfAnswers { get; set; }

        [BsonElement("answers")]
        public IList<Answer> Answers { get; set; }

        [BsonElement("pointIfCorrect")]
        public string PointIfCorrect { get; set; }

        [BsonElement("pointIfIncorrect")]
        public string PointIfIncorrect { get; set; }

        [BsonElement("scoreIfFullyCorrectAnswersOnly")]
        public bool? ScoreIfFullyCorrect { get; set; }

        [BsonElement("scorePartialAnswers")]
        public bool? ScorePartialAnswers { get; set; }

        [BsonElement("pointForAllCorrectPartialAnswers")]
        public int PointForAllCorrectPartialAnswers { get; set; }

        [BsonElement("pointForIncompleteOrIncorrectAnswer")]
        public int PointForIncompleteOrIncorrectAnswer { get; set; }
    }
}
