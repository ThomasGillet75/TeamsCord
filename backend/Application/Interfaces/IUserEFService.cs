using Domain;

namespace Infrastructure;

public interface IUserEFService
{
    void AddUser(UserEntity user);
    UserEntity VerifyUser(string email, string password);
    UserEntity GetUserById(Guid userId);
}