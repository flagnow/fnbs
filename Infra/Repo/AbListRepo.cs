using fnbs.Core.Models;
using fnbs.Core.Models.Dtos.Out;
using fnbs.Core.RepoContract;
using Microsoft.EntityFrameworkCore;

namespace fnbs.Infra.Repo;

public class AbListRepo : IAbListRepo
{
    private readonly Context _db;

    public AbListRepo(Context db)
    {
        _db = db;
    }


    public async Task<AbListResponse> GetAbById(long id)
    {
        var res = await _db.AbList.Include(b => b.User).Include(x => x.Scope)
                .Select(x => new AbListResponse()
                {
                    Id = x.Id,
                    Permission = x.Permission,
                    Scope = x.Scope,
                    ScopeId = x.ScopeId,
                    User = x.User,
                    UserId = x.UserId,
                    features = _db.FeatureFlag.Where(z => z.ScopeId == x.ScopeId).Select(e => new FeatureFlagResponse()
                    {
                        Key = e.Name,
                        Value = x.Permission ? e.GroupB : e.GroupA
                    }).ToList()
                })
                .FirstOrDefaultAsync(x => x.Id == id)
            ;
        return res;
    }

    public async Task<AbListResponse> GetAbByUserAndScope(long userId, long scopeId)
    {
        var res = await _db.AbList.Include(b => b.User).Include(x => x.Scope)
            .Select(x => new AbListResponse()
            {
                Id = x.Id,
                Permission = x.Permission,
                Scope = x.Scope,
                ScopeId = x.ScopeId,
                User = x.User,
                UserId = x.UserId,
                features = _db.FeatureFlag.Where(z => z.ScopeId == x.ScopeId).Select(e => new FeatureFlagResponse()
                {
                    Key = e.Name,
                    Value = x.Permission ? e.GroupB : e.GroupA
                }).ToList()
            })
            .FirstOrDefaultAsync(x => x.UserId == userId && x.ScopeId == scopeId);
        return res;
    }

    public async Task<AbListResponse> CreateAbForUser(AbList ab)
    {
        var x = await _db.AbList.AddAsync(ab);
        await _db.SaveChangesAsync();

        return new AbListResponse()
        {
            Id = x.Entity.Id,
            Permission = x.Entity.Permission,
            Scope = x.Entity.Scope,
            ScopeId = x.Entity.ScopeId,
            User = x.Entity.User,
            UserId = x.Entity.UserId,
        };
    }

    public async Task<List<AbList>> ListAbParticipants(long scopeId)
    {
        var res = await _db.AbList.Include(b => b.User).Include(x => x.Scope)
            .Where(x => x.ScopeId == scopeId).ToListAsync();
        return res;
    }
}