using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GenshinHub.Domain.Entities;

public class Character
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
    public string Element { get; set; } = string.Empty;
    public int Rarity { get; set; }
    public string WeaponType { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }

    public List<CharacterMaterial> Materials { get; set; } = new();
}

public class CharacterMaterial
{
    public string MaterialId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int QuantityPerLevel { get; set; }
}