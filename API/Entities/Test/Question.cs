using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace API.Entities.Test
{
    
    public class Question
    {
        [BsonElement("text")]
        public string? Text { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("pointIfCorrect")]
        public int PointIfCorrect { get; set; }

        [BsonElement("pointIfIncorrect")]
        public int PointIfIncorrect { get; set; }

        // Descriptive question
        [BsonElement("maxNumberOfWords")]
        public int MaxNumberOfWords { get; set; }

        // Descriptive question
        [BsonElement("maxPoints")]
        public int MaxPoints { get; set; }

        // Short answer question
        [BsonElement("maxNumberOfAnswers")]
        public int MaxNumberOfAnswers { get; set; }

        // Multiplechoice question
        [BsonElement("scoreIfFullyCorrectAnswersOnly")]
        public bool? ScoreIfFullyCorrect { get; set; }

        // Multiplechoice question
        [BsonElement("scorePartialAnswers")]
        public bool? ScorePartialAnswers { get; set; }

        // Multiplechoice question
        [BsonElement("pointForAllCorrectPartialAnswers")]
        public int PointForAllCorrectPartialAnswers { get; set; }

        // Multiplechoice question
        [BsonElement("pointForIncompleteOrIncorrectAnswer")]
        public int PointForIncompleteOrIncorrectAnswer { get; set; }

        [BsonElement("answers")]
        public IList<Answer> Answers { get; set; }
    }
}
