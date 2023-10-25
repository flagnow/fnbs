using fnbs.Core.Models;
using fnbs.Core.Models.Dtos.Out;
using fnbs.Core.RepoContract;
using Microsoft.EntityFrameworkCore;

namespace fnbs.Infra.Repo;

public class ScopeRepo : IScopeRepo
{
    private readonly Context _db;

    public ScopeRepo(Context db)
    {
        _db = db;
    }

    public async Task<Scope> CreateScope(Scope u)
    {
        var x = await _db.Scopes.AddAsync(u);
        await _db.SaveChangesAsync();
        return x.Entity;
    }

    public async Task<Scope> GetScopeById(long id)
    {
        return await _db.Scopes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<ScopeAdminDTO>> ListScopes()
    {
        return await _db.Scopes.Select(x => new ScopeAdminDTO
        {
            AbPercentage = x.AbPercentage,
            Description = x.Description,
            Id = x.Id,
            Participants = _db.AbList.Where(e => e.ScopeId == x.Id).Count(),
            UpDateTime = x.UpDateTime
        }).ToListAsync();
    }
}