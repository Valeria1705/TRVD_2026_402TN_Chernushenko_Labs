using GenshinHub.Domain.Entities;

namespace GenshinHub.Domain.Interfaces;

public interface INewsRepository
{
    Task<IEnumerable<News>> GetAllAsync();
    Task<News?> GetByIdAsync(string id);
    Task CreateAsync(News news);
    Task UpdateAsync(News news);
    Task DeleteAsync(string id);
    Task<IEnumerable<News>> GetRecentAsync(int count);
}