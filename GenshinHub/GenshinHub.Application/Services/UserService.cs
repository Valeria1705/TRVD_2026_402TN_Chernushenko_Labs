using GenshinHub.Application.DTOs;
using GenshinHub.Domain.Interfaces;

namespace GenshinHub.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Email = u.Email,
            Role = u.Role,
            CreatedAt = u.CreatedAt,
            Progress = u.Progress.Select(p => new UserProgressDto
            {
                CharacterId = p.CharacterId,
                CharacterName = p.CharacterName,
                CurrentLevel = p.CurrentLevel,
                TargetLevel = p.TargetLevel,
                Talents = new TalentsDto
                {
                    Auto = p.Talents.Auto,
                    Skill = p.Talents.Skill,
                    Burst = p.Talents.Burst
                },
                Owned = p.Owned
            }).ToList()
        });
    }

    public async Task<UserDto?> GetUserByIdAsync(string id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return null;

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Role = user.Role,
            CreatedAt = user.CreatedAt,
            Progress = user.Progress.Select(p => new UserProgressDto
            {
                CharacterId = p.CharacterId,
                CharacterName = p.CharacterName,
                CurrentLevel = p.CurrentLevel,
                TargetLevel = p.TargetLevel,
                Talents = new TalentsDto
                {
                    Auto = p.Talents.Auto,
                    Skill = p.Talents.Skill,
                    Burst = p.Talents.Burst
                },
                Owned = p.Owned
            }).ToList()
        };
    }

    public async Task<bool> UpdateUserRoleAsync(string userId, string newRole)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) return false;

        user.Role = newRole;
        await _userRepository.UpdateAsync(user);
        return true;
    }
}