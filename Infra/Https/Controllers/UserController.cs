using fnbs.Core.Models;
using fnbs.Core.Models.ServicesContract;
using Microsoft.AspNetCore.Mvc;

namespace fnbs.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost(Name = "Create user")]
    public async Task<IActionResult> CreateUser(User u)
    {
        var response = await _userService.CreateUser(u);

        return StatusCode(response.statusCode, response);
    }
}
