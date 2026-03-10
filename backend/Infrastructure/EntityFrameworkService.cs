using Application.Interfaces;
using Domain;
using Infrastructure.Models;

namespace Infrastructure;

public class EntityFrameworkService : IEntityFrameworkService
{
    private readonly DatabaseContext _db;

    public EntityFrameworkService(DatabaseContext db)
    {
        _db = db;
    }
    public User GetUserById(int? userId)
    {
        return _db.Users.Find(userId);
    }

    public void AddUser(UserEntity user)
    {
        Console.WriteLine("=======================" +
                          "Add User" +
                          "=======================");
        User newUser = new User(10, user.Username, user.Email,"dsfq");
        _db.Users.Add(newUser);
        _db.SaveChanges();
    }
}