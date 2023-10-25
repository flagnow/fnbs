namespace fnbs.Core.Models;

public class FeatureFlag
{
    public Int64 Id { get; set; }
    public String Name { get; set; }
    public String GroupA { get; set; }
    public String GroupB { get; set; }

    public Int64 ScopeId { get; set; }
    public Scope Scope { get; set; }
}