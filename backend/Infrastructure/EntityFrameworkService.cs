using Application.Interfaces;
using Infrastructure.Models;

namespace Infrastructure;

public class EntityFrameworkService : IEntityFrameworkService
{
    InstaBookContext db = new InstaBookContext();

    public User GetUserById(int? userId)
    {
        return db.Users.Find(userId);
    }

    public void AddUser(User user)
    {
        db.Users.Add(user);
    }
}