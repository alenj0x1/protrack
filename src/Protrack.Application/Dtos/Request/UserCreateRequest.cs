using System.ComponentModel.DataAnnotations;

namespace Protrack.Application.Dtos.Request;

public class UserCreateRequest
{
    [Required] [MaxLength(32)] public required string Username { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public required string EmailAddress { get; set; }
}