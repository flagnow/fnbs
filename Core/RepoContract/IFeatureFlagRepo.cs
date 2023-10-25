using fnbs.Core.Models;
using fnbs.Core.Models.Dtos;

namespace fnbs.Core.RepoContract;

public interface IFeatureFlagRepo
{
    Task<FeatureFlag> CreateFeature(CreateFeatureFlag a);
    Task<List<FeatureFlag>> GetAllFlagsFromScope(Int64 scopeId);
    Task<FeatureFlag> UpdateFeature(Int64 scopeId, CreateFeatureFlag a);
}