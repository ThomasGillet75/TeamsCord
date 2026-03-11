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
        _db.Users.Add(new User(user.Username, user.Email,user.Password));
        _db.SaveChanges();
    }
}