using Application.Interfaces;
using Domain;
using Infrastructure.Mapper;
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
        _db.Users.Add(new User(user.Username, user.Email, user.Password));
        _db.SaveChanges();
    }

    public UserEntity VerifyUser(string email, string password)
    {
        User user = _db.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        if (user != null)
        {
            return UserMapper.ToDomain(user);
        }
        return null;
    }
}