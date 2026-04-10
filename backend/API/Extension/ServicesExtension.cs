using API.Configuration;
using API.Middleware;
using Application.Interfaces;
using Infrastructure;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace API.Extension;

public static class ServicesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration )
    {
        EnvironmentSettings environmentSettings = new EnvironmentSettings();
        services.AddExceptionHandler<ExceptionHandler>();
        services.AddOpenApi();
        services.AddControllers();
        
        services.AddScoped<IUserEFService, UserEFService>();
        services.AddScoped<IServerChannelEFService, ServerChannelEFService>();
        services.AddScoped<IServerRepository, ServerRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IChannelRepository, ChannelRepository>(); 
        
        services.AddDbContext<DatabaseContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        services.AddJwtAuthentication(
            environmentSettings.Jwt.Secret,
            environmentSettings.Jwt.Issuer,
            environmentSettings.Jwt.Audience);
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPasswordService, PasswordService>();
        
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
        return services;
    }
}