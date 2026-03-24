using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extension;

public static class AuthenticationExtension
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, string secret, string issuer,
        string audience)
    {
        SymmetricSecurityKey signedKey = new(Encoding.UTF8.GetBytes(secret));
        TokenValidationParameters ValidationParameters = new()
        {
            ValidateIssuerSigningKey = true, 
            IssuerSigningKey = signedKey,
            
            ValidateIssuer = true, 
            ValidIssuer = issuer,
            
            ValidateAudience = true, 
            ValidAudience = audience,
            
            ValidateLifetime = true, 
            ClockSkew = TimeSpan.FromSeconds(30)
        };
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = ValidationParameters;
        });
        
        services.AddSingleton(ValidationParameters);
        
        return services;
        
        
    }
}