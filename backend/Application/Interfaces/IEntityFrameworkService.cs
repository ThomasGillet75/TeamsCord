using Application.DTOs.Profile;
using Application.UseCase;
using Domain;

namespace Application.Interfaces;

public interface IEntityFrameworkService
{
    void AddUser(UserEntity createProfileRequest);
}