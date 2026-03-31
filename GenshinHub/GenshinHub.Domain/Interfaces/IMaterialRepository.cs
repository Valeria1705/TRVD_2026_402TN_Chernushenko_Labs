using GenshinHub.Domain.Entities;

namespace GenshinHub.Domain.Interfaces;

public interface IMaterialRepository
{
    Task<IEnumerable<Material>> GetAllAsync();
    Task<Material?> GetByIdAsync(string id);
    Task CreateAsync(Material material);
    Task UpdateAsync(Material material);
    Task DeleteAsync(string id);
}