using Microsoft.AspNetCore.Mvc;
using fnbs.Core.Models.ServicesContract;
using fnbs.Core.Models;

namespace fnbs.Controllers;

[ApiController]
[Route("[controller]")]
public class ScopesController : ControllerBase
{
    private readonly ILogger<ScopesController> _logger;
    private readonly IScopesService _scopesService;

    public ScopesController(ILogger<ScopesController> logger, IScopesService scopes)
    {
        _scopesService = scopes;
        _logger = logger;
    }

    [HttpPost(Name = "Create scope")]
    public async Task<IActionResult> CreateScope(Scope s)
    {
        var response = await _scopesService.CreateScope(s);

        return StatusCode(response.statusCode, response);
    }

    [HttpGet(Name = "List scopes")]
    public async Task<IActionResult> ListScopes()
    {
        var response = await _scopesService.ListScopes();
        return StatusCode(response.statusCode, response);
    }
}
