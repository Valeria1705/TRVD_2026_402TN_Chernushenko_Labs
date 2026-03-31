namespace GenshinHub.Application.DTOs;

public class ResourceCalculationRequestDto
{
    public string UserId { get; set; } = string.Empty;
}

public class ResourceCalculationResponseDto
{
    public Dictionary<string, int> RequiredMaterials { get; set; } = new();
    public int TotalMora { get; set; }
    public int TotalExpBooks { get; set; }
}