using fnbs.Core.Models;
using fnbs.Core.Models.Dtos;
using fnbs.Core.Models.ServicesContract;
using fnbs.Core.RepoContract;

namespace fnbs.Core.Services;

public class FeatureFlagService : IFeatureFlagService
{
    private readonly IFeatureFlagRepo _featureFlag;


    public FeatureFlagService(IFeatureFlagRepo featureFlag)
    {
        _featureFlag = featureFlag;
    }

    public async Task<ResponseWrapper<FeatureFlag>> CreateFeature(CreateFeatureFlag a)
    {
        var response = new ResponseWrapper<FeatureFlag>.Builder();

        var res = await _featureFlag.CreateFeature(a);
        return response.SetData(res).SetStatus(201).SetMessage("Criado com sucesso").Build();
    }

    public async Task<ResponseWrapper<List<FeatureFlag>>> GetAllFlagsFromScope(long scopeId)
    {
        var response = new ResponseWrapper<List<FeatureFlag>>.Builder();

        var res = await _featureFlag.GetAllFlagsFromScope(scopeId);

        return response.SetData(res).SetStatus(201).SetMessage("Criado com sucesso").Build();
    }

    public async Task<ResponseWrapper<FeatureFlag>> UpdateFeature(long scopeId, CreateFeatureFlag a)
    {
        var response = new ResponseWrapper<FeatureFlag>.Builder();

        var res = await _featureFlag.UpdateFeature(scopeId, a);
        return response.SetData(res).SetStatus(201).SetMessage("Criado com sucesso").Build();
    }
}