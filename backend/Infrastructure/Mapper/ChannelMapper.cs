using Domain.Entity;
using Infrastructure.Models;

namespace Infrastructure.Mapper;

public class ChannelMapper
{
    public static ChannelEntity ToDomain(Channel channel) => new ChannelEntity(channel.Id, channel.Name, channel.ServerId, channel.Type); 
    
    public static Channel ToModel(ChannelEntity channel)=> new Channel(channel.Id, channel.Name, channel.ServerId, channel.Type);
}