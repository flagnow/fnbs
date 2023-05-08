using fnbs.Core.Models;
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
}