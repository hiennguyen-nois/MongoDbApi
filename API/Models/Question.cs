using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace API.Models
{
    public class Questions
    {
        [BsonElement("questionNumber")]
        public int QuestionNumber { get; set; }

        [BsonElement("question")]
        public string Question { get; set; }

        [BsonElement("answers")]
        public List<string> Answers { get; set; }

        [BsonElement("rightAnswer")]
        public string RightAnswer { get; set; }
    }

}
