using System.ComponentModel.DataAnnotations;

namespace fnbs.Core.Models.Dtos;

public class CreateFeatureFlag
{
    [Required] public String Name { get; set; }
    [Required] public String GroupA { get; set; }
    [Required] public String GroupB { get; set; }

    [Required] public Int64 ScopeId { get; set; }
}