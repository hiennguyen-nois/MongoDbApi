using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace API.Entities.History
{
    public class TestHistory
    {
        [BsonElement("testId")]
        public string TestId { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("testName")]
        public string TestName { get; set; }

        [BsonElement("startTime")]
        public DateTime StartTime { get; set; }

        [BsonElement("endTime")]
        public DateTime EndTime { get; set; }

        [BsonElement("score")]
        public int Score { get; set; }

        [BsonElement("isPassed")]
        public bool isPassed { get; set; }

        [BsonElement("answerHistory")]
        public IList<AnswerHistory> AnswerHistories { get; set; }
    }
}
