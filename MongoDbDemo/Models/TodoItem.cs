using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbDemo.Models
{
    public class TodoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public DateTime CreationTime { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? DueDate { get; set; }

        public DateTime? Completed { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
