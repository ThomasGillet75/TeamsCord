using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Profile;

public record ProfileResponse(string LastName, string FirstName, string Email);