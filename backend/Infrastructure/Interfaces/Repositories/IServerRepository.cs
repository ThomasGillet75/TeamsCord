using Domain;
using Infrastructure.Models;

namespace Infrastructure.Interfaces.Repositories;

public interface IServerRepository
{
    Task<IReadOnlyList<Server>> GetUserServersAsync(Guid userId, CancellationToken cancellationToken = default);
    void AddServer(Server server, CancellationToken cancellationToken = default);
    void DeleteServer(Guid serverId, CancellationToken cancellationToken = default);
}