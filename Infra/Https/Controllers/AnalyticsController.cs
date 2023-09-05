using fnbs.Core.Models;
using fnbs.Core.Models.Dtos;
using fnbs.Core.Models.ServicesContract;
using Microsoft.AspNetCore.Mvc;

namespace fnbs.Infra.Https.Controllers;

[ApiController]
[Route("[controller]")]
public class AnalyticsController : ControllerBase
{
    private readonly IAnalyticsService _analytics;

    public AnalyticsController(IAnalyticsService ab)
    {
        _analytics = ab;
    }


    [HttpPost(Name = "Add Analytics")]
    public async Task<IActionResult> CreateAnalytics(CreateAnalyticsDTO a)
    {
        var response = await _analytics.AddAnalytics(a);

        return StatusCode(response.statusCode, response);
    }
}