using Application.DTOs.Profile;
using Application.UseCase;
using Domain;

namespace Application.Interfaces;

public interface IEntityFrameworkService
{
    void AddUser(UserEntity user);
    bool VerifyUser(string email, string password);
}