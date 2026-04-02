using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("Servers")]
[PrimaryKey(nameof(Id))]
public class Server
{
    [ForeignKey(nameof(Server))]
    public Guid Id { get; set; }

    [MaxLength(50)]
    public required string Name { get; set; }

    [MaxLength(255)]
    public required string Icon { get; set; }
    
    public ICollection<Channel> Channels { get; set; } = new List<Channel>();
    public ICollection<Member> Members { get; set; } = new List<Member>();

    [SetsRequiredMembers]
    public Server(Guid id, string name, string icon)
    {
        Id = id;
        Name = name;
        Icon = icon;
    }
    [SetsRequiredMembers]
    public Server(string name, string icon)
    {
        Id = Guid.NewGuid();
        Name = name;
        Icon = icon;
    }


}