using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GenshinHub.Domain.Entities;

public class Weapon
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Rarity { get; set; }
    public string? ImageUrl { get; set; }

    public List<WeaponMaterial> Materials { get; set; } = new();
}

public class WeaponMaterial
{
    public string MaterialId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int QuantityPerLevel { get; set; }
}