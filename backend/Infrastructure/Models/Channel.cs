using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;


[Table("Channels")]
[PrimaryKey(nameof(Id))]
public class Channel
{
    public Guid Id { get; set; }
    
    [MaxLength(50)]
    public required string Name { get; set; }
    
    [ForeignKey(nameof(Server))]
    public Guid ServerId { get; set; }
    
    public Server? Server { get; set; }
    
    [SetsRequiredMembers]
    public Channel(Guid id, string name, Guid serverId)
    {
        Id = id;
        Name = name;
        ServerId = serverId;
    }

    [SetsRequiredMembers]
    public Channel(string name, Guid serverId)
    {
        Id = Guid.NewGuid();
        Name = name;
        ServerId = serverId;
    }
}