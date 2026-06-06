using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebApiAzureAppService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _repo;

    public UsersController(IUserRepository repo) => _repo = repo;

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _repo.GetAllAsync();
        return Ok(new
        {
            count = users.Count(),
            data = users
        });
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _repo.GetByIdAsync(id);
        return user is null ? NotFound() : Ok(user);
    }
}