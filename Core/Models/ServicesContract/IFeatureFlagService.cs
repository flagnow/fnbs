using fnbs.Core.Models.Dtos;

namespace fnbs.Core.Models.ServicesContract;

public interface IFeatureFlagService
{
    Task<ResponseWrapper<FeatureFlag>> CreateFeature(CreateFeatureFlag a);
    Task<ResponseWrapper<List<FeatureFlag>>> GetAllFlagsFromScope(Int64 scopeId);
    Task<ResponseWrapper<FeatureFlag>> UpdateFeature(Int64 scopeId, CreateFeatureFlag a);
}