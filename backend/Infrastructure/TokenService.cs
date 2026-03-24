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
    public TokenService(TokenValidationParameters validationParameters)
    {
        _handler = new JsonWebTokenHandler();
        _credentials = new SigningCredentials(validationParameters.IssuerSigningKey, SecurityAlgorithms.HmacSha256);
        _issuer = validationParameters.ValidIssuer;
        _audience = validationParameters.ValidAudience;
    }
    
    public string GenerateToken(Guid userId)
    {
        SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            }),

            Expires = DateTime.UtcNow.AddHours(24),
            Issuer = _issuer,
            Audience = _audience,
            SigningCredentials = _credentials
        };
        
        return _handler.CreateToken(descriptor);
    }
}