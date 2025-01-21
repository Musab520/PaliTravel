using System.Text;
using Application.Mapper;
using Application.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Infrastructure;
using Infrastructure.Repository;
using Domain.IRepository;
using Domain.IService;
using Domain.Model;
using Domain.Service;
using Infrastructure.Mapper;

namespace Application;

public class Program
{
    
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args); 
        builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        
        builder.Services.AddDbContext<Context>(options =>
        {
            options.UseSqlServer(builder.Configuration
                .GetConnectionString("DefaultConnection"));
        });

        // Add services to the container
        builder.Services.AddScoped<ModelToUserMapper>();
        builder.Services.AddScoped<ModelToUserDtoMapper>();
        builder.Services.AddScoped<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();
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