using API.Configuration;
using DotNetEnv;

namespace API.Configuration;
public class EnvironmentSettings
{
    public JwtSettings Jwt { get; set; }
    public EnvironmentSettings()
    {
        SettingVariable();
    }
    private void SettingVariable()
    {
        Jwt = new JwtSettings(
            GetRequired("AUDIENCE"),
            GetRequired("ISSUER"),
            GetRequired("JWT_SECRET"));
    }
    
    private static string GetRequired(string key) =>
        Environment.GetEnvironmentVariable(key)
        ?? throw new InvalidOperationException($"Variable d'environnement manquante : {key}");
}