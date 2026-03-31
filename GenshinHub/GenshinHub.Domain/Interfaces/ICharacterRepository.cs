using GenshinHub.Domain.Entities;

namespace GenshinHub.Domain.Interfaces;

public interface ICharacterRepository
{
    Task<IEnumerable<Character>> GetAllAsync();
    Task<Character?> GetByIdAsync(string id);
    Task CreateAsync(Character character);
    Task UpdateAsync(Character character);
    Task DeleteAsync(string id);
}