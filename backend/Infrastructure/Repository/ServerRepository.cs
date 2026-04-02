using Infrastructure.Interfaces.Repositories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ServerRepository(DatabaseContext db) : IServerRepository
{
    public async Task<IReadOnlyList<Server>> GetUserServersAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await db.Members .Where(m => m.UserId == userId)
            .Join(
                db.Servers,
                m => m.ServerId,
                s => s.Id,
                (m, s) => s)
            .Distinct()
            .ToListAsync(cancellationToken);
    }
    
    public async void AddServerAsync(Server server, CancellationToken cancellationToken = default)
    {
        await db.Servers.AddAsync(server, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }
}