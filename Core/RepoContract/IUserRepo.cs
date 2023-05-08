using fnbs.Core.Models;

namespace fnbs.Core.RepoContract;

public interface IUserRepo
{
    Task<User> CreateUser(User u);
    Task<User> GetUserBydId(Int64 id);
}