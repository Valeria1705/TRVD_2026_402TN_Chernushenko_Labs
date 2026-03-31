namespace GenshinHub.Application.DTOs;

public class UserDto
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<UserProgressDto> Progress { get; set; } = new();
}

public class UserProgressDto
{
    public string CharacterId { get; set; } = string.Empty;
    public string CharacterName { get; set; } = string.Empty;
    public int CurrentLevel { get; set; }
    public int TargetLevel { get; set; }
    public TalentsDto Talents { get; set; } = new();
    public bool Owned { get; set; }
}

public class TalentsDto
{
    public int Auto { get; set; }
    public int Skill { get; set; }
    public int Burst { get; set; }
}