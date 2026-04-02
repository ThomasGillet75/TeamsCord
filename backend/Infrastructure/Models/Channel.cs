using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
}