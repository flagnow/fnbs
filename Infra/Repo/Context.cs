using fnbs.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace fnbs.Infra.Repo;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<AbList> AbList { get; set; }
    public DbSet<Scope> Scopes { get; set; }
    public DbSet<Analytics> Analytics { get; set; }
    public DbSet<FeatureFlag> FeatureFlag { get; set; }
}