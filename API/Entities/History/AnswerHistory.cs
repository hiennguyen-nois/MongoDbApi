using API.Entities.Test;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace API.Entities.History
{
    public class AnswerHistory
    {

        [BsonElement("question")]
        public Question Question { get; set; }

        [BsonElement("answerText")]
        public string AnswerText { get; set; }

        [BsonElement("selectedAnswer")]
        public IList<int> SelectedAnswer { get; set; }

        [BsonElement("feedBack")]
        public string? Feedback { get; set; }

    }
}