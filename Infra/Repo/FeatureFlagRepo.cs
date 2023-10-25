using fnbs.Core.Models;
using fnbs.Core.Models.Dtos;
using fnbs.Core.RepoContract;
using Microsoft.EntityFrameworkCore;

namespace fnbs.Infra.Repo;

public class FeatureFlagRepo : IFeatureFlagRepo
{
    private readonly Context _db;

    public FeatureFlagRepo(Context db)
    {
        _db = db;
    }

    public async Task<FeatureFlag> CreateFeature(CreateFeatureFlag a)
    {
        var response = await _db.FeatureFlag.AddAsync(new FeatureFlag()
        {
            GroupA = a.GroupA,
            GroupB = a.GroupB,
            Name = a.Name,
            ScopeId = a.ScopeId,
        });
        await _db.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<List<FeatureFlag>> GetAllFlagsFromScope(long scopeId)
    {
        var res = await _db.FeatureFlag.Where(x => x.ScopeId == scopeId).ToListAsync();
        return res;
    }

    public async Task<FeatureFlag> UpdateFeature(long scopeId, CreateFeatureFlag a)
    {
        var feature = await _db.FeatureFlag.FirstOrDefaultAsync(x => x.Id == scopeId);
        feature.GroupA = a.GroupA;
        feature.GroupB = a.GroupB;
        feature.Name = a.Name;

        await _db.SaveChangesAsync();

        return feature;
    }
}