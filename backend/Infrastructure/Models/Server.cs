using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
}