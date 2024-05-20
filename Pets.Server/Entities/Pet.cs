using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Pets.Server.Entities
{
    public class Pet
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name"), BsonRepresentation(BsonType.String)]
        public required string Name { get; set; }

        [BsonElement("created_at"), BsonRepresentation(BsonType.String)]
        public required string CreatedAt { get; set; }

        [BsonElement("type"), BsonRepresentation(BsonType.String)]
        public required string Type { get; set; }

        [BsonElement("color"), BsonRepresentation(BsonType.String)]
        public required string Color { get; set; }

        [BsonElement("Age"), BsonRepresentation(BsonType.Int32)]
        public required int Age { get; set; }



    }
}
