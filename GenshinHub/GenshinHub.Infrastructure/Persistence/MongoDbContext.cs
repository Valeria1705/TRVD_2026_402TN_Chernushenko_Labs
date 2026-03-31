using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using GenshinHub.Domain.Entities;

namespace GenshinHub.Infrastructure.Persistence;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDB");
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase("GenshinHub");
    }

    public IMongoCollection<Character> Characters => _database.GetCollection<Character>("characters");
    public IMongoCollection<User> Users => _database.GetCollection<User>("users");
    public IMongoCollection<Weapon> Weapons => _database.GetCollection<Weapon>("weapons");
    public IMongoCollection<Material> Materials => _database.GetCollection<Material>("materials");
    public IMongoCollection<News> News => _database.GetCollection<News>("news");
}