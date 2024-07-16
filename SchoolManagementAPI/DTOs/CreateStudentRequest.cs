using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SchoolManagementAPI.DTOs
{
    public class CreateStudentRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Fullname")]
        public string Name { get; set; }
        [BsonElement("Age")]
        public int Age { get; set; }
        [BsonElement("Class")]
        public string Class { get; set; }
    }
}
