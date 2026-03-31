using GenshinHub.Domain.Entities;

namespace GenshinHub.Domain.Interfaces;

public interface IWeaponRepository
{
    Task<IEnumerable<Weapon>> GetAllAsync();
    Task<Weapon?> GetByIdAsync(string id);
    Task CreateAsync(Weapon weapon);
    Task UpdateAsync(Weapon weapon);
    Task DeleteAsync(string id);
}