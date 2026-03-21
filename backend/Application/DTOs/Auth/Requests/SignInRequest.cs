using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Auth.Requests;

public record SignInRequest
{
    [Required]
    [EmailAddress] 
    [MaxLength(50)]
    public string Email { get; init; } = string.Empty;
    
    [Required]
    [MinLength(8)]
    [MaxLength(50)]
    public string Password { get; init; } = string.Empty;
}