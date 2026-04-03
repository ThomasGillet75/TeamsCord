using Application.Interfaces;
using Domain.Entity;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Mapper;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ServerChannelEFService(DatabaseContext db, IServerRepository serverRepository) : IServerChannelEFService
{
    public async Task<IReadOnlyList<ServerEntity>> GetUserServersAsync(Guid userId)
    {
        if (userId != Guid.Empty) throw new ArgumentException("userId is required", nameof(userId));
        IReadOnlyList<Server> servers = await serverRepository.GetUserServersAsync(userId);
        return servers.Select(ServerMapper.ToDomain).ToList();
    }

    public void AddServerAsync(ServerEntity server, Guid userId)
    {
        if (server is null) throw new ArgumentNullException(nameof(server));
        try
        {
            serverRepository.AddServerAsync(ServerMapper.ToModel(server));
            
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("error occurred while adding the server to the database");
        }
    }
}