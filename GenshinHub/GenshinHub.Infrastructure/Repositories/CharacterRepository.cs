using MongoDB.Driver;
using GenshinHub.Domain.Entities;
using GenshinHub.Domain.Interfaces;
using GenshinHub.Infrastructure.Persistence;

namespace GenshinHub.Infrastructure.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly IMongoCollection<Character> _characters;

    public CharacterRepository(MongoDbContext context)
    {
        _characters = context.Characters;
    }

    public async Task<IEnumerable<Character>> GetAllAsync() =>
        await _characters.Find(_ => true).ToListAsync();

    public async Task<Character?> GetByIdAsync(string id) =>
        await _characters.Find(c => c.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Character character) =>
        await _characters.InsertOneAsync(character);

    public async Task UpdateAsync(Character character) =>
        await _characters.ReplaceOneAsync(c => c.Id == character.Id, character);

    public async Task DeleteAsync(string id) =>
        await _characters.DeleteOneAsync(c => c.Id == id);
}