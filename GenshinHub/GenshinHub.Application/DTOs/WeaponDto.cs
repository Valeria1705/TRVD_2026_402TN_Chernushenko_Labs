namespace GenshinHub.Application.DTOs;

public class WeaponDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Rarity { get; set; }
    public string? ImageUrl { get; set; }
    public List<WeaponMaterialDto> Materials { get; set; } = new();
}

public class WeaponMaterialDto
{
    public string MaterialId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int QuantityPerLevel { get; set; }
}

public class CreateWeaponDto
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Rarity { get; set; }
    public string? ImageUrl { get; set; }
    public List<WeaponMaterialDto> Materials { get; set; } = new();
}