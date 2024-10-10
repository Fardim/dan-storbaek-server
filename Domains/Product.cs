using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace dan_storbaek_server.Domains
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; } = null!;
        [BsonElement("model")]
        public string Model { get; set; } = null!;
        [BsonElement("brand")]
        public string Brand { get; set; } = null!;
        [BsonElement("price")]
        public decimal Price { get; set; }
        [BsonElement("lotNo")]
        public string LotNo { get; set; } = null!;
    }
}
