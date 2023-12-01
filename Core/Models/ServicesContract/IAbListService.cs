using fnbs.Core.Models.Dtos;
using fnbs.Core.Models.Dtos.Out;

namespace fnbs.Core.Models.ServicesContract;

public interface IAbListService
{
    Task<ResponseWrapper<AbListResponse>> GetAbList(Int64 userId, Int64 scopeid);
    Task<ResponseWrapper<List<AbList>>> ListAbByScopeID(Int64 scopeid);

    Task<ResponseWrapper<Scope>> Scope(Int64 scopeid);
}