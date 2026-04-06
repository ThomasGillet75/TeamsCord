using Domain.Entity;

namespace Application.Interfaces;

public interface IServerChannelEFService
{
    Task<IReadOnlyList<ServerEntity>> GetUserServersAsync(Guid userId);
    void AddServerAsync(ServerEntity serverEntity, Guid userId);
    void AddChannelAsync(ChannelEntity channelEntity);
    Task<IReadOnlyList<ChannelEntity>> GetChannelsByServerIdAsync(Guid serverId);
}