using Domain.Enum;

namespace Domain.Entity;

public class ChannelEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public Guid ServerId { get; set; }
    
    public EChannel Type { get; set; }
    
    public ChannelEntity(Guid id, string name, Guid serverId, EChannel type)
    {
        Id = id;
        Name = name;
        ServerId = serverId;
        Type = type;
    }
    
    public ChannelEntity(string name, Guid serverId , EChannel type)
    {
        Id = Guid.NewGuid();
        Name = name;
        ServerId = serverId;
        Type = type;
    }
}