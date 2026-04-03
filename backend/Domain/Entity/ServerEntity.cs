using System.Diagnostics.CodeAnalysis;

namespace Domain.Entity;

public class ServerEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Icon { get; set; }
    
    public ServerEntity(Guid id, string name, string icon)
    {
        Id = id;
        Name = name;
        Icon = icon;
    }

    public ServerEntity(string name, string icon)
    {
        Id = Guid.NewGuid();
        Name = name;
        Icon = icon;
    }
}