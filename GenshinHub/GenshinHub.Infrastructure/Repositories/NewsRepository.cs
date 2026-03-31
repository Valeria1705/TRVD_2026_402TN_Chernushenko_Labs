using MongoDB.Driver;
using GenshinHub.Domain.Entities;
using GenshinHub.Domain.Interfaces;
using GenshinHub.Infrastructure.Persistence;

namespace GenshinHub.Infrastructure.Repositories;

public class NewsRepository : INewsRepository
{
    private readonly IMongoCollection<News> _news;

    public NewsRepository(MongoDbContext context)
    {
        _news = context.News;
    }

    public async Task<IEnumerable<News>> GetAllAsync() =>
        await _news.Find(_ => true).ToListAsync();

    public async Task<News?> GetByIdAsync(string id) =>
        await _news.Find(n => n.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(News news) =>
        await _news.InsertOneAsync(news);

    public async Task UpdateAsync(News news) =>
        await _news.ReplaceOneAsync(n => n.Id == news.Id, news);

    public async Task DeleteAsync(string id) =>
        await _news.DeleteOneAsync(n => n.Id == id);

    public async Task<IEnumerable<News>> GetRecentAsync(int count) =>
        await _news.Find(_ => true).SortByDescending(n => n.PublishedAt).Limit(count).ToListAsync();
}