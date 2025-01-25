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
        builder.Services.AddScoped<ModelToCityDtoMapper>();
        builder.Services.AddScoped<ModelToCityMapper>();
        builder.Services.AddScoped<ModelToHotelDtoMapper>();
        builder.Services.AddScoped<ModelToHotelMapper>();
        builder.Services.AddScoped<ModelToRoomDtoMapper>();
        builder.Services.AddScoped<ModelToRoomMapper>();
        builder.Services.AddScoped<ModelToReservationDtoMapper>();
        builder.Services.AddScoped<ModelToReservationMapper>();
        builder.Services.AddScoped<ModelToDealDtoMapper>();
        builder.Services.AddScoped<ModelToDealMapper>();
        builder.Services.AddScoped<ModelToConfirmationDtoMapper>();
        builder.Services.AddScoped<ModelToConfirmationMapper>();
        builder.Services.AddScoped<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<ICityRepository, CityRepository>();
        builder.Services.AddScoped<ICityService, CityService>();
        builder.Services.AddScoped<IHotelRepository, HotelRepository>();
        builder.Services.AddScoped<IHotelService, HotelService>();
        builder.Services.AddScoped<IRoomRepository, RoomRepository>();
        builder.Services.AddScoped<IRoomService, RoomService>();
        builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
        builder.Services.AddScoped<IReservationService, ReservationService>();
        builder.Services.AddScoped<IDealRepository, DealRepository>();
        builder.Services.AddScoped<IDealService, DealService>();
        builder.Services.AddScoped<IConfirmationRepository, ConfirmationRepository>();
        builder.Services.AddScoped<IConfirmationService, ConfirmationService>();
        builder.Services.AddScoped<DatabaseSeeder>();

        //Add Validation
        builder.Services.AddScoped<IValidator<UserModel>, UserValidator>();
        builder.Services.AddScoped<IValidator<CityModel>, CityValidator>();
        builder.Services.AddScoped<IValidator<HotelModel>, HotelValidator>();
        builder.Services.AddScoped<IValidator<RoomModel>, RoomValidator>();
        builder.Services.AddScoped<IValidator<ReservationModel>, ReservationValidator>();
        builder.Services.AddScoped<IValidator<DealModel>, DealValidator>();
        builder.Services.AddScoped<IValidator<ConfirmationModel>, ConfirmationValidator>();





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
            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
                seeder.SeedDataAsync().Wait();
            }
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}