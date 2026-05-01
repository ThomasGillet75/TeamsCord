using Infrastructure.Interfaces.Repositories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ServerRepository(DatabaseContext db) : IServerRepository
{
    public async Task<IReadOnlyList<Server>> GetUserServersAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await db.Members.Where(m => m.UserId == userId)
            .Join(
                db.Servers,
                member => member.ServerId,
                server => server.Id,
                (member, server) => server)
            .Distinct()
            .ToListAsync(cancellationToken);
    }
    
    public async void AddServer(Server server, CancellationToken cancellationToken = default)
    {
        await db.Servers.AddAsync(server, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }
    
    public async void DeleteServer(Guid serverId, CancellationToken cancellationToken = default)
    {
        Server? server = await db.Servers.FindAsync(new object[] { serverId }, cancellationToken);
        if (server is null) throw new InvalidOperationException("server not found");
        db.Servers.Remove(server);
        await db.SaveChangesAsync(cancellationToken);
    }
    
}