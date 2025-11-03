using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TechAndSolve.WBAPI.Clients.Application.Clients.Requests;
using TechAndSolve.WBAPI.Clients.Application.Clients.Services;
using TechAndSolve.WBAPI.Clients.Infrastructure.Persistence;
using TechAndSolve.WBAPI.Clients.Infrastructure.Persistence.Repositories.Clients;

namespace TechAndSolve.WBAPI.Clients.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.Scan(scanner => scanner
            .FromAssemblies(
                typeof(ClientsRepository).Assembly)
            .AddClasses()
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }

    public static IServiceCollection AddServices (this IServiceCollection services)
    {
        services.Scan(scanner => scanner
            .FromAssemblies(
                typeof(IClientsService).Assembly)
            .AddClasses()
            .AsMatchingInterface()
            .WithTransientLifetime());

        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.Scan(scanner => scanner
            .FromAssemblies(
                typeof(ClientRegisterRequest).Assembly)
            .AddClasses(c =>
                c.AssignableTo(typeof(IValidator<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }

    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
            });

        return services;
    }
}