namespace fnbs.Core.Models;

public class AbList
{
    public Int64 Id { get; set; }
    public Scope Scope { get; set; }
    public Int64 ScopeId { get; set; }
    public Int64 UserId { get; set; }
    public User User { get; set; }
    public Boolean Permission { get; set; }
}