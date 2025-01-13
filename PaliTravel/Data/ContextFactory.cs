using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PaliTravel.Data;

public class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<Context>();
        optionsBuilder.UseSqlServer( "Server=localhost,1433;Database=palitravel;User Id=sa;Password=YourStrongPassword123;Encrypt=False;");
        var context = new Context(optionsBuilder.Options);

        return context;
    }
}