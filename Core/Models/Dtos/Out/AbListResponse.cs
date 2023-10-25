namespace fnbs.Core.Models.Dtos.Out;

public class AbListResponse : AbList
{
    public List<FeatureFlagResponse> features { get; set; }
}