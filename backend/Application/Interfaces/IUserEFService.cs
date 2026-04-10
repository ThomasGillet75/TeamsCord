using Domain;

namespace Infrastructure;

public interface IUserEFService
{
    Task AddUserAsync(UserEntity user);
    UserEntity VerifyUser(string email, string password);
    UserEntity GetUserById(Guid userId);
    
    Task<bool> ExistsByEmailAsync(string email);
}