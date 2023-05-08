using fnbs.Core.Models;
using fnbs.Core.RepoContract;
using Microsoft.EntityFrameworkCore;

namespace fnbs.Infra.Repo;

public class UserRepo : IUserRepo
{
    private readonly Context _db;

    public UserRepo(Context db)
    {
        _db = db;
    }

    public async Task<User> CreateUser(User u)
    {
        var x = await _db.Users.AddAsync(u);
        await _db.SaveChangesAsync();

        return x.Entity;
    }

    public async Task<User> GetUserBydId(long id)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
}