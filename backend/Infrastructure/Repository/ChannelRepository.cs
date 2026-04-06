using Infrastructure.Interfaces.Repositories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ChannelRepository(DatabaseContext db) : IChannelRepository
{
    public async Task<IReadOnlyList<Channel>> GetServerChannelsAsync(Guid serverId, CancellationToken cancellationToken = default)
    {
        return await db.Channels.Where(channel => channel.ServerId == serverId).ToListAsync(cancellationToken);
    }

    public void AddChannel(Channel channel, CancellationToken cancellationToken = default)
    {
        db.Channels.Add(channel);
        db.SaveChanges();
    }
}