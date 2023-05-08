using fnbs.Core.Models;

namespace fnbs.Core.RepoContract;

public interface IAbListRepo
{
    Task<AbList> GetAbById(Int64 id);
    Task<AbList> GetAbByUserAndScope(Int64 userId, Int64 scopeId);
    Task<AbList> CreateAbForUser(AbList ab);
}