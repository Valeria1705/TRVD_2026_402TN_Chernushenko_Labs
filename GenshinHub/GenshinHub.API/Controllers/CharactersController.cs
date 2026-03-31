using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GenshinHub.Application.DTOs;
using GenshinHub.Application.Services;

namespace GenshinHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly CharacterService _characterService;

    public CharactersController(CharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var characters = await _characterService.GetAllCharactersAsync();
        return Ok(characters);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var character = await _characterService.GetCharacterByIdAsync(id);
        if (character == null) return NotFound();
        return Ok(character);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Create([FromBody] CreateCharacterDto createDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var character = await _characterService.CreateCharacterAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = character.Id }, character);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Update(string id, [FromBody] CreateCharacterDto updateDto)
    {
        var updated = await _characterService.UpdateCharacterAsync(id, updateDto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(string id)
    {
        var deleted = await _characterService.DeleteCharacterAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}