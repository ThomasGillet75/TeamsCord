using Application.DTOs.Profile;
using Application.UseCase;
using Domain;

namespace Application.Interfaces;

public interface IEntityFrameworkService
{
    void AddUser(UserEntity user);
    UserEntity VerifyUser(string email, string password);
    UserEntity GetUserById(Guid userId);
}