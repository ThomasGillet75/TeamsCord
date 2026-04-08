using Application.Interfaces;
using Domain;
using Domain.Entity;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Mapper;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ServerChannelEFService(IServerRepository serverRepository, IChannelRepository channelRepository, IMemberRepository memberRepository) : IServerChannelEFService
{
    public async Task<IReadOnlyList<ServerEntity>> GetUserServersAsync(Guid userId)
    {
        if (userId == Guid.Empty) throw new ArgumentException("userId is required", nameof(userId));
        IReadOnlyList<Server> servers = await serverRepository.GetUserServersAsync(userId);
        return servers.Select(ServerMapper.ToDomain).ToList();
    }

    public void AddServerAsync(ServerEntity serverEntity, Guid userId)
    {
        if (serverEntity is null) throw new ArgumentNullException(nameof(serverEntity));
        try
        {
            Server server = ServerMapper.ToModel(serverEntity);
            Member newMember = new Member
            {
                ServerId = server.Id,
                UserId = userId,
                Role = ERole.Admin
            };
            
            serverRepository.AddServer(server);
            memberRepository.AddMember(newMember);
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("error occurred while adding the server to the database");
        }
    }
    
    public void AddChannelAsync(ChannelEntity channelEntity)
    {
        if (channelEntity is null) throw new ArgumentNullException(nameof(channelEntity));
        try
        {
            Channel channel = ChannelMapper.ToModel(channelEntity);
            channelRepository.AddChannel(channel);
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("error occurred while adding the channel to the database");
        }
    }
    
    public async Task<IReadOnlyList<ChannelEntity>> GetChannelsByServerIdAsync(Guid serverId)
    {
        if(serverId == Guid.Empty) throw new ArgumentException("serverId is required", nameof(serverId));
        IReadOnlyList<Channel> channels = await channelRepository.GetServerChannelsAsync(serverId);
        return channels.Select(ChannelMapper.ToDomain).ToList();
    }
}