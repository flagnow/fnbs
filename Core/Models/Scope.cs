using System.ComponentModel.DataAnnotations;

namespace fnbs.Core.Models;

public class Scope
{
    [Required] public Int64 Id { get; set; }
    [Required] [MinLength(4)] public String Description { get; set; }

    [Required] public int AbPercentage { get; set; }
    public DateTime UpDateTime { get; set; }
}