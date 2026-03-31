using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GenshinHub.Domain.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = "player";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<UserProgress> Progress { get; set; } = new();
}

public class UserProgress
{
    public string CharacterId { get; set; } = string.Empty;
    public string CharacterName { get; set; } = string.Empty;
    public int CurrentLevel { get; set; } = 1;
    public int TargetLevel { get; set; } = 90;
    public Talents Talents { get; set; } = new();
    public bool Owned { get; set; } = false;
}

public class Talents
{
    public int Auto { get; set; } = 1;
    public int Skill { get; set; } = 1;
    public int Burst { get; set; } = 1;
}