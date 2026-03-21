namespace API.Configuration;

public class JwtSettings
{

    public string Audience;
    public string Issuer;
    public string Secret;

    public JwtSettings(string audience, string issuer, string secret)
    {
        Audience = audience;
        Issuer = issuer;
        Secret = secret;
    }
}