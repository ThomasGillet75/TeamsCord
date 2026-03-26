using API.Configuration;
using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace API.Extension;

public static class ServicesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration )
    {
        EnvironmentSettings environmentSettings = new EnvironmentSettings();
        services.AddOpenApi();
        services.AddControllers();
        services.AddScoped<IEntityFrameworkService, EntityFrameworkService>();
        services.AddDbContext<DatabaseContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        services.AddJwtAuthentication(
            environmentSettings.Jwt.Secret,
            environmentSettings.Jwt.Issuer,
            environmentSettings.Jwt.Audience);
        services.AddScoped<ITokenService, TokenService>();
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