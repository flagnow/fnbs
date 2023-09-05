using System.ComponentModel.DataAnnotations;

namespace fnbs.Core.Models.Dtos;

public class CreateAnalyticsDTO
{
    [Required] public String Action { get; set; }
    [Required] public Int64 UserId { get; set; }
}