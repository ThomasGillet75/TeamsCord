using System.ComponentModel.DataAnnotations;
using Domain;

namespace Application.DTOs.Profile;

public record GetUserResponse(UserEntity user);