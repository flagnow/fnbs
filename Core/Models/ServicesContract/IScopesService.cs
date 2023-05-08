using fnbs.Core.Models.Dtos;

namespace fnbs.Core.Models.ServicesContract;

public interface IScopesService
{
    Task<ResponseWrapper<Scope>> CreateScope(Scope u);
}