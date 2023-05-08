using fnbs.Core.Models;
using fnbs.Core.Models.Dtos;
using fnbs.Core.Models.ServicesContract;
using fnbs.Core.RepoContract;

namespace fnbs.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepo _users;

    public UserService(IUserRepo users)
    {
        _users = users;
    }

    public async Task<ResponseWrapper<User>> CreateUser(User u)
    {
        var response = new ResponseWrapper<User>.Builder();

        var repoResponse = await _users.CreateUser(u);

        response.SetData(repoResponse).SetMessage("Usuário criado com sucesso").SetStatus(201);
        return response.Build();
    }
}