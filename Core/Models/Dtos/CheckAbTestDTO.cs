using System.ComponentModel.DataAnnotations;

namespace fnbs.Core.Models.Dtos;

public class CheckAbTestDTO
{
    [Required] public Int64 AbID { get; set; }
    [Required] public Int64 UserID { get; set; }
}