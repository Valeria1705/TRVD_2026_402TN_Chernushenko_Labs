using AutoMapper;
using GenshinHub.Application.DTOs;
using GenshinHub.Domain.Entities;
using GenshinHub.Domain.Interfaces;

namespace GenshinHub.Application.Services;

public class NewsService
{
    private readonly INewsRepository _newsRepository;
    private readonly IMapper _mapper;

    public NewsService(INewsRepository newsRepository, IMapper mapper)
    {
        _newsRepository = newsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NewsDto>> GetAllNewsAsync()
    {
        var news = await _newsRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<NewsDto>>(news);
    }

    public async Task<NewsDto?> GetNewsByIdAsync(string id)
    {
        var news = await _newsRepository.GetByIdAsync(id);
        return news == null ? null : _mapper.Map<NewsDto>(news);
    }

    public async Task<NewsDto> CreateNewsAsync(CreateNewsDto createDto)
    {
        var news = _mapper.Map<News>(createDto);
        news.PublishedAt = DateTime.UtcNow;
        await _newsRepository.CreateAsync(news);
        return _mapper.Map<NewsDto>(news);
    }

    public async Task<bool> UpdateNewsAsync(string id, CreateNewsDto updateDto)
    {
        var existing = await _newsRepository.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(updateDto, existing);
        await _newsRepository.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteNewsAsync(string id)
    {
        var existing = await _newsRepository.GetByIdAsync(id);
        if (existing == null) return false;

        await _newsRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<NewsDto>> GetRecentNewsAsync(int count)
    {
        var news = await _newsRepository.GetRecentAsync(count);
        return _mapper.Map<IEnumerable<NewsDto>>(news);
    }
}