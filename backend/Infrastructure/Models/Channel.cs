using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Domain.Enum;
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
    public EChannel Type { get; set; }
    public Server? Server { get; set; }
    public ICollection<Message> Messages { get; set; }
    
    
    [SetsRequiredMembers]
    public Channel(Guid id, string name, Guid serverId, EChannel type = EChannel.Text)
    {
        Id = id;
        Name = name;
        ServerId = serverId;
        Type = type;
    }

    [SetsRequiredMembers]
    public Channel(string name, Guid serverId, EChannel type = EChannel.Text)
    {
        Id = Guid.NewGuid();
        Name = name;
        ServerId = serverId;
        Type = type;
    }
}