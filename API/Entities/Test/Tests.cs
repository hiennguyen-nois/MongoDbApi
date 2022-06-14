using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace API.Entities.Test
{
    public class Tests
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("categoryId")]
        public string? CategoryId { get; set; }

        [BsonElement("testName")]
        public string? Name { get; set; }

        [BsonElement("activeFor")]
        public TimeSpan? ActiveFor { get; set; }

        [BsonElement("timeForEachQuestion")]
        public TimeSpan? TimeForEachQuestion { get; set; }

        [BsonElement("timeToComplete")]
        public TimeSpan? TimeToComplete { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("createdByUserId")]
        public string? CreatedByUserId { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }

        [BsonElement("passMarkValue")]
        public int PassMarkValue { get; set; }

        [BsonElement("passMarkUnit")]
        public string? PassMarkUnit { get; set; }

        [BsonElement("questions")]
        public IList<Question> Questions { get; set; }
    }
}
