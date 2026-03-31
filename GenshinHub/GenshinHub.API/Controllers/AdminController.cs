using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GenshinHub.Application.Services;

namespace GenshinHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "admin")]
public class AdminController : ControllerBase
{
    private readonly UserService _userService;

    public AdminController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("users/{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPut("users/{id}/role")]
    public async Task<IActionResult> UpdateUserRole(string id, [FromBody] string newRole)
    {
        var result = await _userService.UpdateUserRoleAsync(id, newRole);
        if (!result) return NotFound();
        return NoContent();
    }
}