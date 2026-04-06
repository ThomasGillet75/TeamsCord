namespace Domain.Entity;

public class ChannelEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public Guid ServerId { get; set; }
    
    public ChannelEntity(Guid id, string name, Guid serverId)
    {
        Id = id;
        Name = name;
        ServerId = serverId;
    }
    
    public ChannelEntity(string name, Guid serverId)
    {
        Id = Guid.NewGuid();
        Name = name;
        ServerId = serverId;
    }
}