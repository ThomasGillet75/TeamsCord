using System.Security.Claims;
using System.Text;
using Application.Interfaces;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public class TokenService : ITokenService
{
    private string _issuer;
    private string _audience;
    private JsonWebTokenHandler _handler;
    private SigningCredentials _credentials;
    private TokenValidationParameters _validationParameters;

    public TokenService(string jwtKey, string issuer, string audience)
    {
        _handler = new JsonWebTokenHandler();
        SymmetricSecurityKey signedKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        _credentials = new SigningCredentials(signedKey, SecurityAlgorithms.HmacSha256);
        _issuer = issuer;
        _audience = audience;
        
        _validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signedKey,

            ValidateIssuer = true,
            ValidIssuer = _issuer,

            ValidateAudience = true,
            ValidAudience = _audience,

            ValidateLifetime = true,

            ClockSkew = TimeSpan.FromSeconds(30)
        };
    }
    
    public string GenerateToken(Guid userId, string email)
    {
        SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email)
            }),

            Expires = DateTime.UtcNow.AddHours(24),
            Issuer = _issuer,
            Audience = _audience,
            SigningCredentials = _credentials
        };
        
        return _handler.CreateToken(descriptor);
    }
    
    public async Task<bool> ValidateToken(string token)
    {
        TokenValidationResult result =  await _handler.ValidateTokenAsync(token, _validationParameters);
        if(result.IsValid)
        {
            return true;
        }
        return false;
    }
}