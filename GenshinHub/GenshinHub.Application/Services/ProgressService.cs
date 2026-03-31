using GenshinHub.Application.DTOs;
using GenshinHub.Domain.Entities;
using GenshinHub.Domain.Interfaces;

namespace GenshinHub.Application.Services;

public class ProgressService
{
    private readonly IUserRepository _userRepository;
    private readonly ICharacterRepository _characterRepository;

    public ProgressService(IUserRepository userRepository, ICharacterRepository characterRepository)
    {
        _userRepository = userRepository;
        _characterRepository = characterRepository;
    }

    public async Task<UserProgressDto?> GetUserProgressAsync(string userId, string characterId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) return null;

        var progress = user.Progress.FirstOrDefault(p => p.CharacterId == characterId);
        if (progress == null) return null;

        return new UserProgressDto
        {
            CharacterId = progress.CharacterId,
            CharacterName = progress.CharacterName,
            CurrentLevel = progress.CurrentLevel,
            TargetLevel = progress.TargetLevel,
            Talents = new TalentsDto
            {
                Auto = progress.Talents.Auto,
                Skill = progress.Talents.Skill,
                Burst = progress.Talents.Burst
            },
            Owned = progress.Owned
        };
    }

    public async Task<bool> UpdateUserProgressAsync(string userId, string characterId, UserProgressDto progressDto)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) return false;

        var existingProgress = user.Progress.FirstOrDefault(p => p.CharacterId == characterId);
        if (existingProgress == null)
        {
            var character = await _characterRepository.GetByIdAsync(characterId);
            if (character == null) return false;

            user.Progress.Add(new UserProgress
            {
                CharacterId = characterId,
                CharacterName = character.Name,
                CurrentLevel = progressDto.CurrentLevel,
                TargetLevel = progressDto.TargetLevel,
                Talents = new Talents
                {
                    Auto = progressDto.Talents.Auto,
                    Skill = progressDto.Talents.Skill,
                    Burst = progressDto.Talents.Burst
                },
                Owned = progressDto.Owned
            });
        }
        else
        {
            existingProgress.CurrentLevel = progressDto.CurrentLevel;
            existingProgress.TargetLevel = progressDto.TargetLevel;
            existingProgress.Talents.Auto = progressDto.Talents.Auto;
            existingProgress.Talents.Skill = progressDto.Talents.Skill;
            existingProgress.Talents.Burst = progressDto.Talents.Burst;
            existingProgress.Owned = progressDto.Owned;
        }

        await _userRepository.UpdateAsync(user);
        return true;
    }

    public async Task<bool> AddCharacterToUserAsync(string userId, string characterId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) return false;

        var character = await _characterRepository.GetByIdAsync(characterId);
        if (character == null) return false;

        if (user.Progress.Any(p => p.CharacterId == characterId))
            return true;

        user.Progress.Add(new UserProgress
        {
            CharacterId = characterId,
            CharacterName = character.Name,
            CurrentLevel = 1,
            TargetLevel = 90,
            Talents = new Talents(),
            Owned = true
        });

        await _userRepository.UpdateAsync(user);
        return true;
    }
}