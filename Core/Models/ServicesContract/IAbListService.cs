using fnbs.Core.Models.Dtos;

namespace fnbs.Core.Models.ServicesContract;

public interface IAbListService {
    Task<ResponseWrapper<AbList>> GetAbList(Int64 userId, Int64 scopeid);
}