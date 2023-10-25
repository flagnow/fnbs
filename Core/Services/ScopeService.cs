using fnbs.Core.Models;
using fnbs.Core.Models.Dtos;
using fnbs.Core.Models.Dtos.Out;
using fnbs.Core.Models.ServicesContract;
using fnbs.Core.RepoContract;

namespace fnbs.Core.Services;

public class ScopeService : IScopesService
{
    private readonly IScopeRepo _scopes;

    public ScopeService(IScopeRepo scope)
    {
        _scopes = scope;
    }

    public async Task<ResponseWrapper<Scope>> CreateScope(Scope u)
    {
        var response = new ResponseWrapper<Scope>.Builder();

        var repoResponse = await _scopes.CreateScope(u);
        response.SetMessage("Scope criado com sucesso").SetData(repoResponse).SetStatus(201);


        return response.Build();
    }

    public async Task<ResponseWrapper<List<ScopeAdminDTO>>> ListScopes()
    {
        var response = new ResponseWrapper<List<ScopeAdminDTO>>.Builder();

        var repoResponse = await _scopes.ListScopes();
        response.SetData(repoResponse);

        return response.Build();
    }
}