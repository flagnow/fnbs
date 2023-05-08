using fnbs.Core.Models.Dtos;

namespace fnbs.Core.Models.ServicesContract;

public interface IUserService
{
    Task<ResponseWrapper<User>> CreateUser(User u);
}