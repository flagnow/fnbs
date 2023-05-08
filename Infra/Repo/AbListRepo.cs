using fnbs.Core.Models;
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


    public async Task<AbList> GetAbById(long id)
    {
        var res = await _db.AbList.Include(b => b.User).Include(x => x.Scope).FirstOrDefaultAsync(x => x.Id == id);
        return res;
    }

    public async Task<AbList> GetAbByUserAndScope(long userId, long scopeId)
    {
        var res = await _db.AbList.Include(b => b.User).Include(x => x.Scope)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.ScopeId == scopeId);
        return res;
    }

    public async Task<AbList> CreateAbForUser(AbList ab)
    {
        var x = await _db.AbList.AddAsync(ab);
        await _db.SaveChangesAsync();
        return x.Entity;
    }
}