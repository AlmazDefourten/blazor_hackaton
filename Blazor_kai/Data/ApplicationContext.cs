using Microsoft.EntityFrameworkCore;

namespace Blazor_kai.Data;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=appdb;Trusted_Connection=True;");
    }
}
