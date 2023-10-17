using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using ThirdParty.Json.LitJson;

namespace StudentManagement.Models
{
    [BsonIgnoreExtraElements]
    public class Course
    {
        [BsonElement("_id")]

        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string CourseName { get; set; } = String.Empty;

    }
}
