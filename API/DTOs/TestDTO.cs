using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class TestDTO
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public TimeSpan ActiveFor { get; set; }
        public TimeSpan TimeForEachQuestion { get; set; }
        public TimeSpan TimeToComplete { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUser { get; set; }
        public string Status { get; set; }
        public int PassMarkValue { get; set; }
        public string? PassMarkUnit { get; set; }
        public IList<QuestionDTO> Questions { get; set; }
    }
}
