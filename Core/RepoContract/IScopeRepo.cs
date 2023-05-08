using fnbs.Core.Models;

namespace fnbs.Core.RepoContract;

public interface IScopeRepo
{
    Task<Scope> CreateScope(Scope u);
    Task<Scope> GetScopeById(Int64 id);
}