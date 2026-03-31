namespace GenshinHub.Application.DTOs;

public class CharacterDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Element { get; set; } = string.Empty;
    public int Rarity { get; set; }
    public string WeaponType { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public List<CharacterMaterialDto> Materials { get; set; } = new();
}

public class CharacterMaterialDto
{
    public string MaterialId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int QuantityPerLevel { get; set; }
}

public class CreateCharacterDto
{
    public string Name { get; set; } = string.Empty;
    public string Element { get; set; } = string.Empty;
    public int Rarity { get; set; }
    public string WeaponType { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public List<CharacterMaterialDto> Materials { get; set; } = new();
}