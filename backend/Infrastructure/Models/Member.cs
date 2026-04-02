using System.ComponentModel.DataAnnotations.Schema;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;


[Table("Members")]
[PrimaryKey(nameof(ServerId), nameof(UserId))]
public class Member
{
    [ForeignKey(nameof(Server))]

    public Guid ServerId { get; set; }
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public EPermission Permission { get; set; }    
    
    public Server? Server { get; set; }
    public User? User { get; set; }
    
}