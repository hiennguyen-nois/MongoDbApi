using MongoDB.Bson.Serialization.Attributes;

namespace API.Entities.Test
{
    public class Answer
    {
        [BsonElement("number")]
        public int Number { get; set; }

        [BsonElement("text")]
        public string Text { get; set; }

        [BsonElement("isCorrect")]
        public bool IsCorrect { get; set; }

        
    }
}