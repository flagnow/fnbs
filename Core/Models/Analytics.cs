using System.ComponentModel.DataAnnotations;

namespace fnbs.Core.Models;

public class Analytics
{
    [Required] public Int64 Id { get; set; }
    [Required] public String Action { get; set; }
    public DateTime CreatedAt { get; set; }
    [Required] public Int64 UserId { get; set; }
    public User User { get; set; }
}