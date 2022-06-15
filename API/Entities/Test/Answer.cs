using MongoDB.Bson.Serialization.Attributes;

namespace API.Entities.Test
{
    public class Answer
    {
        [BsonElement("text")]
        public string Text { get; set; }

        [BsonElement("isCorrect")]
        public bool IsCorrect { get; set; }

        [BsonElement("numberOfPoints")]
        public int NumberOfPoints { get; set; }

    }
}