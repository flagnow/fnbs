using fnbs.Core.Models;

namespace fnbs.Core.RepoContract;

public interface IAnalyticsRepo
{
    Task<Analytics> Analysis(Analytics a);
}