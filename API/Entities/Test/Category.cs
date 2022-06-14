using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Entities.Test
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("categoryName")]
        public string Name { get; set; }
    }
}
