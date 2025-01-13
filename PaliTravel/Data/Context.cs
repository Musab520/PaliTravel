using Microsoft.EntityFrameworkCore;
using PaliTravel.Domain.Model;

namespace PaliTravel.Data;

public class Context : DbContext
{
    public Context() { }

    public Context(DbContextOptions<Context> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer( "Server=localhost,1433;User Id=sa;Password=YourStrongPassword123;Encrypt=False;");
        }
    }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     
    //
    //     base.OnModelCreating(modelBuilder);
    // }
}