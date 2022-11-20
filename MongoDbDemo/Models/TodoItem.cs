using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MongoDbDemo.Models
{
    public class TodoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Display(Name ="Creation time")]
        public DateTime CreationTime { get; set; }

        [Display(Name = "Created by")]
        public string CreatedBy { get; set; } = null!;

        [Display(Name = "Assigned to")]
        public string? AssignedTo { get; set; } = null!;

        [Display(Name = "Due date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local, DateOnly = true)] 
        public DateTime? DueDate { get; set; }

        [Display(Name = "Completed at")]
        public DateTime? CompletedAt { get; set; }

        [MinLength(2, ErrorMessage = "A title must be at least 2 characters long")]
        public string Title { get; set; } = null!;

        [MaxLength(500, ErrorMessage = "The description mjst not exceed 500 characters")]
        public string Description { get; set; } = null!;

        public Priority Priority { get; set; } = Priority.Medium;
    }
}
