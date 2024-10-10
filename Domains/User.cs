using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace dan_storbaek_server.Domains
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; } = null!;
        [BsonElement("lastName")]
        public string LastName { get; set; } = null!;
        [BsonElement("email")]
        public string Email { get; set; } = null!;
        [BsonElement("age")]
        public int Age { get; set; }
        [BsonElement("nickName")]
        public string NickName { get; set; } = null!;
        [BsonElement("familyLineage")]
        public string FamilyLineage { get; set; } = null!;


    }
}
