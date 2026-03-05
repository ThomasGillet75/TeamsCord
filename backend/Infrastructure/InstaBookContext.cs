using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class InstaBookContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public string DbPath { get; set; }

    public InstaBookContext()
    {
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string path = Path.Combine(folder);
        DbPath = Path.Combine(path, "InstaBook.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
}