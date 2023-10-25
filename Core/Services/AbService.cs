using fnbs.Core.Models;
using fnbs.Core.Models.Dtos;
using fnbs.Core.Models.Dtos.Out;
using fnbs.Core.Models.ServicesContract;
using fnbs.Core.RepoContract;

namespace fnbs.Core.Services;

public class AbService : IAbListService
{
    private readonly IAbListRepo _ab;
    private readonly IScopeRepo _scopes;
    private readonly IUserRepo _user;

    public AbService(IAbListRepo ab, IScopeRepo scope, IUserRepo user)
    {
        _scopes = scope;
        _ab = ab;
        _user = user;
    }

    public async Task<ResponseWrapper<AbListResponse>> GetAbList(long userId, long scopeid)
    {
        var response = new ResponseWrapper<AbListResponse>.Builder();
        var resGetScopeById = await _scopes.GetScopeById(scopeid);
        var resGetUserById = await _user.GetUserBydId(userId);

        if (resGetUserById == null || resGetScopeById == null)
            return response.SetMessage("O escopo ou o usuário não existem").SetStatus(400).Build();


        var resGetAbByUserAndScope = await _ab.GetAbByUserAndScope(userId, scopeid);
        if (resGetAbByUserAndScope == null)
        {
            bool Permission;

            Random random = new Random();
            int randomNumber = random.Next(0, 101);

            if (randomNumber <= resGetScopeById.AbPercentage)
            {
                Permission = true;
            }
            else
            {
                Permission = false;
            }

            var createResponse = await _ab.CreateAbForUser(new AbList()
            {
                UserId = userId,
                ScopeId = scopeid,
                Permission = Permission,
            });
            return response.SetData(createResponse).SetStatus(200).Build();
        }

        return response.SetData(resGetAbByUserAndScope).SetStatus(200).Build();
    }

    public async Task<ResponseWrapper<List<AbList>>> ListAbByScopeID(long scopeid)
    {
        var response = new ResponseWrapper<List<AbList>>.Builder();

        var q = await _ab.ListAbParticipants(scopeid);
        return response.SetData(q).Build();
    }
}