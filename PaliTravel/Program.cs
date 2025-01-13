using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaliTravel.Application.Mapper;
using PaliTravel.Application.Validation;
using PaliTravel.Data;
using PaliTravel.Data.Repository;
using PaliTravel.Domain.IRepository;
using PaliTravel.Domain.Model;
using PaliTravel.Domain.Service;

namespace PaliTravel;

public class Program
{
    
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args); 
        builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
            .Build();
        
        builder.Services.AddDbContext<Context>(options =>
        {
            options.UseSqlServer(builder.Configuration
                .GetConnectionString("DefaultConnection"));
        });

        // Add services to the container.
        builder.Services.AddScoped<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();
        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();

        //Add Validation
        builder.Services.AddScoped<IValidator<UserModel>, UserValidator>();
        //Add Auth
        builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Authentication:Issuer"],
                ValidAudience = builder.Configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
            };
        });
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}