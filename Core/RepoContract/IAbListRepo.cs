using fnbs.Core.Models;
using fnbs.Core.Models.Dtos.Out;

namespace fnbs.Core.RepoContract;

public interface IAbListRepo
{
    Task<AbListResponse> GetAbById(Int64 id);
    Task<AbListResponse> GetAbByUserAndScope(Int64 userId, Int64 scopeId);
    Task<AbListResponse> CreateAbForUser(AbList ab);
    Task<List<AbList>> ListAbParticipants(Int64 scopeId);
}