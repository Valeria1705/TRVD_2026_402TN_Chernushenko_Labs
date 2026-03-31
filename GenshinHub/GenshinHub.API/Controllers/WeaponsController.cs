using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GenshinHub.Application.DTOs;
using GenshinHub.Application.Services;

namespace GenshinHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeaponsController : ControllerBase
{
    private readonly WeaponService _weaponService;

    public WeaponsController(WeaponService weaponService)
    {
        _weaponService = weaponService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var weapons = await _weaponService.GetAllWeaponsAsync();
        return Ok(weapons);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var weapon = await _weaponService.GetWeaponByIdAsync(id);
        if (weapon == null) return NotFound();
        return Ok(weapon);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Create([FromBody] CreateWeaponDto createDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var weapon = await _weaponService.CreateWeaponAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = weapon.Id }, weapon);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Update(string id, [FromBody] CreateWeaponDto updateDto)
    {
        var updated = await _weaponService.UpdateWeaponAsync(id, updateDto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(string id)
    {
        var deleted = await _weaponService.DeleteWeaponAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}