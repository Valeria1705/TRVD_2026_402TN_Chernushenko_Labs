using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GenshinHub.Application.DTOs;
using GenshinHub.Application.Services;

namespace GenshinHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserProgressController : ControllerBase
{
    private readonly ProgressService _progressService;
    private readonly ResourceCalculationService _resourceCalculationService;

    public UserProgressController(ProgressService progressService, ResourceCalculationService resourceCalculationService)
    {
        _progressService = progressService;
        _resourceCalculationService = resourceCalculationService;
    }

    [HttpGet("{characterId}")]
    public async Task<IActionResult> GetProgress(string characterId)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var progress = await _progressService.GetUserProgressAsync(userId, characterId);
        if (progress == null) return NotFound();
        return Ok(progress);
    }

    [HttpPut("{characterId}")]
    public async Task<IActionResult> UpdateProgress(string characterId, [FromBody] UserProgressDto progressDto)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var result = await _progressService.UpdateUserProgressAsync(userId, characterId, progressDto);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpPost("{characterId}")]
    public async Task<IActionResult> AddCharacter(string characterId)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var result = await _progressService.AddCharacterToUserAsync(userId, characterId);
        if (!result) return NotFound();
        return Ok();
    }

    [HttpGet("resources/calculate")]
    public async Task<IActionResult> CalculateResources()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var resources = await _resourceCalculationService.CalculateRequiredResourcesAsync(userId);
        return Ok(resources);
    }
}