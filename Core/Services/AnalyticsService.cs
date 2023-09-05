using fnbs.Core.Models;
using fnbs.Core.Models.Dtos;
using fnbs.Core.Models.ServicesContract;
using fnbs.Core.RepoContract;
using fnbs.Infra.Repo;

namespace fnbs.Core.Services;

public class AnalyticsService : IAnalyticsService
{
    private readonly IAbListRepo _ab;
    private readonly IScopeRepo _scopes;
    private readonly Context _db;

    private readonly IUserRepo _user;

    public AnalyticsService(IAbListRepo ab, IScopeRepo scope, IUserRepo user, Context db)
    {
        _scopes = scope;
        _ab = ab;
        _user = user;
        _db = db;
    }


    public async Task<ResponseWrapper<Analytics>> AddAnalytics(CreateAnalyticsDTO a)
    {
        var response = new ResponseWrapper<Analytics>.Builder();
        var analytics = new Analytics()
        {
            Action = a.Action,
            CreatedAt = new DateTime(),
            UserId = a.UserId
        };
        try
        {
            await _db.Analytics.AddAsync(analytics);

            return response.SetData(analytics).SetStatus(200).SetMessage("Criado com sucesso").Build();
        }
        catch (Exception e)
        {
            return response.SetData(analytics).SetStatus(500).SetMessage("Houve algum erro inesperado").Build();
        }
    }
}