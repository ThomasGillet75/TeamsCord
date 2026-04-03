using Infrastructure.Interfaces.Repositories;
using Infrastructure.Models;

namespace Infrastructure.Repository;

public class ChannelRepository(DatabaseContext db) : IChannelRepository
{
    public Task<IReadOnlyList<Channel>> GetServerChannelsAsync(Guid serverId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void AddChannel(Channel channel, CancellationToken cancellationToken = default)
    {
        db.Channels.Add(channel);
        db.SaveChanges();
    }
}

