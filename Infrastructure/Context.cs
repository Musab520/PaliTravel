using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure;

public class Context : DbContext
{
    
    public Context() { }

    public Context(DbContextOptions<Context> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<City> City { get; set; }
    public DbSet<Hotel> Hotel { get; set; }
    public DbSet<Room> Room { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer( "Server=localhost,1433;Database=palitravel;User Id=sa;Password=YourStrongPassword123;Encrypt=False;");
        }
    }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     
    //
    //     base.OnModelCreating(modelBuilder);
    // }
}