using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Entities.User
{
    public class User : BaseEntity
    {

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
    }
}
