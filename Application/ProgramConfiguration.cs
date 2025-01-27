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
using Domain.SieveModel;
using Domain.Service;
using Infrastructure.Mapper;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace Application
{
    public static class ProgramConfiguration
    {

        public static WebApplication ConfigureApp(this WebApplication app)
        {
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

            return app;
        }

        // Configure DbContext and SQL Server
        internal static WebApplicationBuilder ConfigureDbContext(this WebApplicationBuilder builder)
        {
            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration
                    .GetConnectionString("DefaultConnection"));
            });

            return builder;
        }

        // Configure Mappers
        internal static WebApplicationBuilder ConfigureMappers(this WebApplicationBuilder builder)
        {
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
            builder.Services.AddScoped<ModelToAvailableRoomMapper>();

            return builder;
        }

        // Configure Repositories and Services
        internal static WebApplicationBuilder ConfigureRepositoriesAndServices(this WebApplicationBuilder builder)
        {
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
            builder.Services.AddScoped<SieveProcessor>();

            return builder;
        }

        // Configure Validation
        internal static WebApplicationBuilder ConfigureValidation(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IValidator<UserModel>, UserValidator>();
            builder.Services.AddScoped<IValidator<CityModel>, CityValidator>();
            builder.Services.AddScoped<IValidator<HotelModel>, HotelValidator>();
            builder.Services.AddScoped<IValidator<RoomModel>, RoomValidator>();
            builder.Services.AddScoped<IValidator<ReservationModel>, ReservationValidator>();
            builder.Services.AddScoped<IValidator<DealModel>, DealValidator>();
            builder.Services.AddScoped<IValidator<ConfirmationModel>, ConfirmationValidator>();

            return builder;
        }

        // Configure Authentication (JWT Bearer Setup)
        internal static WebApplicationBuilder ConfigureAuthentication(this WebApplicationBuilder builder)
        {
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

            return builder;
        }

        // Configure Controllers, Endpoints, and Swagger
        internal static WebApplicationBuilder ConfigureControllersAndSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder;
        }
    }
}
