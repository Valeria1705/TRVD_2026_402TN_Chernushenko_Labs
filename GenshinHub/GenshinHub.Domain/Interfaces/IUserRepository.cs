using GenshinHub.Domain.Entities;

namespace GenshinHub.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(string id);
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task<IEnumerable<User>> GetAllAsync();
}