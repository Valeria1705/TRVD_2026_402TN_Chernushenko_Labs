using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GenshinHub.Application.DTOs;
using GenshinHub.Application.Services;

namespace GenshinHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaterialsController : ControllerBase
{
    private readonly MaterialService _materialService;

    public MaterialsController(MaterialService materialService)
    {
        _materialService = materialService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var materials = await _materialService.GetAllMaterialsAsync();
        return Ok(materials);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var material = await _materialService.GetMaterialByIdAsync(id);
        if (material == null) return NotFound();
        return Ok(material);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Create([FromBody] CreateMaterialDto createDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var material = await _materialService.CreateMaterialAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = material.Id }, material);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Update(string id, [FromBody] CreateMaterialDto updateDto)
    {
        var updated = await _materialService.UpdateMaterialAsync(id, updateDto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(string id)
    {
        var deleted = await _materialService.DeleteMaterialAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}