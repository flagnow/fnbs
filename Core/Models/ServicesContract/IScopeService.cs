using fnbs.Core.Models.Dtos;

namespace fnbs.Core.Models.ServicesContract;

public interface IAnalyticsService
{
    Task<ResponseWrapper<Analytics>> AddAnalytics(CreateAnalyticsDTO u);
}