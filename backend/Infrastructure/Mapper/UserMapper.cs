using Domain;
using Infrastructure.Models;

namespace Infrastructure.Mapper;

public static class UserMapper{
    public static UserEntity ToDomain(User model)
        => new UserEntity(model.Id,model.Username, model.Email, model.Password);

    public static User ToModel(UserEntity entity)
        => new User(entity.Username, entity.Email, entity.Password)
        {
            Id = entity.Id 
        };
}