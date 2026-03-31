using MongoDB.Driver;
using GenshinHub.Domain.Entities;
using GenshinHub.Domain.Interfaces;
using GenshinHub.Infrastructure.Persistence;

namespace GenshinHub.Infrastructure.Repositories;

public class WeaponRepository : IWeaponRepository
{
	private readonly IMongoCollection<Weapon> _weapons;

	public WeaponRepository(MongoDbContext context)
	{
		_weapons = context.Weapons;
	}

	public async Task<IEnumerable<Weapon>> GetAllAsync() =>
		await _weapons.Find(_ => true).ToListAsync();

	public async Task<Weapon?> GetByIdAsync(string id) =>
		await _weapons.Find(w => w.Id == id).FirstOrDefaultAsync();

	public async Task CreateAsync(Weapon weapon) =>
		await _weapons.InsertOneAsync(weapon);

	public async Task UpdateAsync(Weapon weapon) =>
		await _weapons.ReplaceOneAsync(w => w.Id == weapon.Id, weapon);

	public async Task DeleteAsync(string id) =>
		await _weapons.DeleteOneAsync(w => w.Id == id);
}