using Application.Interfaces;
using Domain;
using Domain.Entity;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Mapper;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ServerChannelEFService(IServerRepository serverRepository, IMemberRepository memberRepository) : IServerChannelEFService
{
    public async Task<IReadOnlyList<ServerEntity>> GetUserServersAsync(Guid userId)
    {
        if (userId != Guid.Empty) throw new ArgumentException("userId is required", nameof(userId));
        IReadOnlyList<Server> servers = await serverRepository.GetUserServersAsync(userId);
        return servers.Select(ServerMapper.ToDomain).ToList();
    }

    public void AddServerAsync(ServerEntity serverEntity, Guid userId)
    {
        if (serverEntity is null) throw new ArgumentNullException(nameof(serverEntity));
        try
        {
            Server server = ServerMapper.ToModel(serverEntity);
            serverRepository.AddServerAsync(server);
            memberRepository.AddMember(new Member
            {
                ServerId = server.Id,
                UserId = userId,
                Role = ERole.Admin
            });
            
            
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("error occurred while adding the server to the database");
        }
    }
}