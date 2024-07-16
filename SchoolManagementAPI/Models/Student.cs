using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SchoolManagementAPI.Models
{
    public class Student
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
