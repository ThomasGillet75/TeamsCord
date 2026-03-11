using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("Users")]
[PrimaryKey(nameof(Id))]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    public Guid Id { get; set; }
    [MaxLength(50)]
    public required string Username { get; set; }
    [MaxLength(50)]
    public required string Email { get; set; }
    [MaxLength(50)]
    public required string Password { get; set; }

    [SetsRequiredMembers]
    public User(string username, string email, string password)
    {
        Id = Guid.NewGuid();
        Username = username;
        Email = email;
        Password = password;
    }
}