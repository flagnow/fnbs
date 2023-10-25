using fnbs.Core.Models;
using fnbs.Core.Models.Dtos.Out;

namespace fnbs.Core.RepoContract;

public interface IScopeRepo
{
    Task<Scope> CreateScope(Scope u);
    Task<Scope> GetScopeById(Int64 id);
    Task<List<ScopeAdminDTO>> ListScopes();
}