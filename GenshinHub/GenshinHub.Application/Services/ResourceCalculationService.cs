using GenshinHub.Domain.Interfaces;
using GenshinHub.Application.DTOs;

namespace GenshinHub.Application.Services;

public class ResourceCalculationService
{
    private readonly IUserRepository _userRepository;
    private readonly ICharacterRepository _characterRepository;

    public ResourceCalculationService(IUserRepository userRepository, ICharacterRepository characterRepository)
    {
        _userRepository = userRepository;
        _characterRepository = characterRepository;
    }

    public async Task<ResourceCalculationResponseDto> CalculateRequiredResourcesAsync(string userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) return new ResourceCalculationResponseDto();

        var response = new ResourceCalculationResponseDto();
        var requiredMaterials = new Dictionary<string, int>();

        foreach (var progress in user.Progress.Where(p => p.Owned && p.CurrentLevel < p.TargetLevel))
        {
            var character = await _characterRepository.GetByIdAsync(progress.CharacterId);
            if (character == null) continue;

            foreach (var material in character.Materials)
            {
                if (!requiredMaterials.ContainsKey(material.Name))
                    requiredMaterials[material.Name] = 0;

                requiredMaterials[material.Name] += material.QuantityPerLevel * (progress.TargetLevel - progress.CurrentLevel);
            }

            response.TotalMora += (progress.TargetLevel - progress.CurrentLevel) * 5000;
            response.TotalExpBooks += (progress.TargetLevel - progress.CurrentLevel) * 10;
        }

        response.RequiredMaterials = requiredMaterials;
        return response;
    }
}