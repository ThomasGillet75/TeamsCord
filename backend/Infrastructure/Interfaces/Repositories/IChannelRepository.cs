using Infrastructure.Models;

namespace Infrastructure.Interfaces.Repositories;

public interface IChannelRepository
{
    Task<IReadOnlyList<Channel>> GetServerChannelsAsync(Guid serverId, CancellationToken cancellationToken = default);
    void AddChannel(Channel channel, CancellationToken cancellationToken = default);
}

