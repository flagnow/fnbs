using fnbs.Core.Models.Dtos;
using fnbs.Core.Models.ServicesContract;
using Microsoft.AspNetCore.Mvc;

namespace fnbs.Infra.Https.Controllers;

[ApiController]
[Route("[controller]")]
public class AbListController : ControllerBase
{
    private readonly IAbListService _ab;

    public AbListController(IAbListService ab)
    {
        _ab = ab;
    }

    [HttpGet("{userId:long}/{scopeID:long}")]
    public async Task<IActionResult> GetAbTest(Int64 userId, Int64 scopeID)
    {
        var response = await _ab.GetAbList(userId, scopeID);

        return StatusCode(response.statusCode, response);
    }

    [HttpGet("listscope/{scopeID:long}")]
    public async Task<IActionResult> ListAbTest(Int64 scopeID)
    {
        var response = await _ab.ListAbByScopeID(scopeID);

        return StatusCode(response.statusCode, response);
    }

    [HttpPost("{userId:long}/{scopeID:long}")]
    public async Task<IActionResult> UpdatePermission(Int64 userId, Int64 scopeID)
    {
        var response = await _ab.UpdateUser(scopeID, userId);

        return StatusCode(response.statusCode, response);
    }

    [HttpGet("{scopeID:long}")]
    public async Task<IActionResult> GetScope(Int64 scopeID)
    {
        var response = await _ab.Scope(scopeID);

        return StatusCode(response.statusCode, response);
    }
}