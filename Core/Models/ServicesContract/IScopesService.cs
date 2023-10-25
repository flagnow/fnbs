using fnbs.Core.Models.Dtos;
using fnbs.Core.Models.Dtos.Out;

namespace fnbs.Core.Models.ServicesContract;

public interface IScopesService
{
    Task<ResponseWrapper<Scope>> CreateScope(Scope u);
    Task<ResponseWrapper<List<ScopeAdminDTO>>> ListScopes();
}