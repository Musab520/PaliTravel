namespace Application;

public class Program
{
    
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder
            .ConfigureDbContext()
            .ConfigureMappers()
            .ConfigureRepositoriesAndServices()
            .ConfigureValidation()
            .ConfigureAuthentication()
            .ConfigureControllersAndSwagger();

        var app = builder.Build();
        app.ConfigureApp();
        app.Run();
    }
}