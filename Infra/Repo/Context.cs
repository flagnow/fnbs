using fnbs.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace fnbs.Infra.Repo;

public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<AbList> AbList { get; set; }
    public DbSet<Scope> Scopes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder opt)
    {
        opt.UseInMemoryDatabase("inmemo");
    }
}