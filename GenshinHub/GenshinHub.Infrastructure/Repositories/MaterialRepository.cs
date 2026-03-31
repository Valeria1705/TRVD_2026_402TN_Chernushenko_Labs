using MongoDB.Driver;
using GenshinHub.Domain.Entities;
using GenshinHub.Domain.Interfaces;
using GenshinHub.Infrastructure.Persistence;

namespace GenshinHub.Infrastructure.Repositories;

public class MaterialRepository : IMaterialRepository
{
    private readonly IMongoCollection<Material> _materials;

    public MaterialRepository(MongoDbContext context)
    {
        _materials = context.Materials;
    }

    public async Task<IEnumerable<Material>> GetAllAsync() =>
        await _materials.Find(_ => true).ToListAsync();

    public async Task<Material?> GetByIdAsync(string id) =>
        await _materials.Find(m => m.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Material material) =>
        await _materials.InsertOneAsync(material);

    public async Task UpdateAsync(Material material) =>
        await _materials.ReplaceOneAsync(m => m.Id == material.Id, material);

    public async Task DeleteAsync(string id) =>
        await _materials.DeleteOneAsync(m => m.Id == id);
}