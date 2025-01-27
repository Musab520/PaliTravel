using Domain.SieveModel;
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
    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<Deal> Deal { get; set; }
    public DbSet<Confirmation> Confirmation { get; set; }
    public DbSet<AvailableRoom> AvailableRooms { get; set; }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer( "Server=localhost,1433;Database=palitravel;User Id=sa;Password=YourStrongPassword123;Encrypt=False;");
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AvailableRoom>().ToView("AvailableRooms");
    }
}