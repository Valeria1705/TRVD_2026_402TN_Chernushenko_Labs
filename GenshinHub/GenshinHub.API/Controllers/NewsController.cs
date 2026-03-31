using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GenshinHub.Application.DTOs;
using GenshinHub.Application.Services;

namespace GenshinHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly NewsService _newsService;

    public NewsController(NewsService newsService)
    {
        _newsService = newsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var news = await _newsService.GetAllNewsAsync();
        return Ok(news);
    }

    [HttpGet("recent/{count:int}")]
    public async Task<IActionResult> GetRecent(int count)
    {
        var news = await _newsService.GetRecentNewsAsync(count);
        return Ok(news);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var news = await _newsService.GetNewsByIdAsync(id);
        if (news == null) return NotFound();
        return Ok(news);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Create([FromBody] CreateNewsDto createDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var news = await _newsService.CreateNewsAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = news.Id }, news);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Update(string id, [FromBody] CreateNewsDto updateDto)
    {
        var updated = await _newsService.UpdateNewsAsync(id, updateDto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(string id)
    {
        var deleted = await _newsService.DeleteNewsAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}