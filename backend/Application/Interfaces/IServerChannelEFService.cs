using Domain.Entity;

namespace Application.Interfaces;

public interface IServerChannelEFService
{
    Task<IReadOnlyList<ServerEntity>> GetUserServersAsync(Guid userId);
    void AddServerAsync(ServerEntity server, Guid userId);
}