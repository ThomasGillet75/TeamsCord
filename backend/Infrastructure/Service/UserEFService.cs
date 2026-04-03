using Application.Interfaces;
using Domain;
using Infrastructure.Mapper;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class UserEFService (DatabaseContext db) : IUserEFService
{
    public UserEntity GetUserById(Guid userId)
    {
        User? user = db.Users.Find(userId);
        if (user == null) throw new Exception("User not found");
        return UserMapper.ToDomain(user);
    }

    public void AddUser(UserEntity user)
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

    public UserEntity VerifyUser(string email, string password)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("email is required", nameof(email));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("password is required", nameof(password));

            User? user = db.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
            if (user == null) throw new Exception("User not found");
            return UserMapper.ToDomain(user);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("data is not valid");
        }
    }
}