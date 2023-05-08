using System.ComponentModel.DataAnnotations;

namespace fnbs.Core.Models;

public class User
{
    [Required] public Int64 Id { get; set; }

    public String Name { get; set; }
}