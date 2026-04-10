using Application.Interfaces;
using Domain;
using Infrastructure.Mapper;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class UserEFService(DatabaseContext db) : IUserEFService
{
    public UserEntity GetUserById(Guid userId)
    {
        User? user = db.Users.Find(userId);
        if (user == null) throw new Exception("User not found");
        return UserMapper.ToDomain(user);
    }

    public async Task AddUserAsync(UserEntity user)
    {
        try
        {
            db.Users.Add(new User(user.Username, user.Email, user.Password));
            db.SaveChanges();
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("error occurred while adding the user to the database");
        }
    }

    public UserEntity VerifyUser(string email)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("email is required");
            
            User? user = db.Users.SingleOrDefault(u => u.Email == email);
            if (user == null) throw new Exception("Email invalid or User does not exist");
            return UserMapper.ToDomain(user);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("data is not valid");
        }
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        try
        {
            if(db.Users.SingleOrDefault(u => u.Email == email) != null)
                return true;
            return false;
        }
        catch (Exception e)
        {
            throw new InvalidOperationException("An error occurred while checking for existing email", e);
        }
    }
}