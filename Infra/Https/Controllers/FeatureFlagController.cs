using fnbs.Core.Models.Dtos;
using fnbs.Core.Models.ServicesContract;
using Microsoft.AspNetCore.Mvc;

namespace fnbs.Infra.Https.Controllers;

[ApiController]
[Route("[controller]")]
public class FeatureFlagController : ControllerBase
{
    private readonly IFeatureFlagService _featureFlag;

    public FeatureFlagController(IFeatureFlagService ab)
    {
        _featureFlag = ab;
    }


    [HttpPost(Name = "Create a featureflag")]
    public async Task<IActionResult> CreateFeature(CreateFeatureFlag s)
    {
        var response = await _featureFlag.CreateFeature(s);

        return StatusCode(response.statusCode, response);
    }

    [HttpGet(Name = "Get all featureflag from scope")]
    public async Task<IActionResult> ListFeatureFlags(long scopeId)
    {
        var response = await _featureFlag.GetAllFlagsFromScope(scopeId);

        return StatusCode(response.statusCode, response);
    }


    [HttpPut(Name = "Create a featureflag")]
    public async Task<IActionResult> UpdateAFeature(long scopeId, CreateFeatureFlag s)
    {
        var response = await _featureFlag.UpdateFeature(scopeId, s);
        return StatusCode(response.statusCode, response);
    }
}