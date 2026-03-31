using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GenshinHub.Domain.Entities;

public class News
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? SourceUrl { get; set; }
    public DateTime PublishedAt { get; set; }
}