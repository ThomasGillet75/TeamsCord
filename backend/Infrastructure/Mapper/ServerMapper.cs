using Domain.Entity;
using Infrastructure.Models;

namespace Infrastructure.Mapper;

public class ServerMapper
{
    public static ServerEntity ToDomain(Server model)
        => new ServerEntity(model.Id,model.Name, model.Icon);

    public static Server ToModel(ServerEntity entity)
        => new Server(entity.Id, entity.Name, entity.Icon );
        
}