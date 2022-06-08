using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models
{
    public class LivingCreature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string CreatureName { get; set; }
        public string Home { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
