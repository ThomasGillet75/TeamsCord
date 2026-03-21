namespace Application.Interfaces;

public interface ITokenService
{
    public string GenerateToken(string userId); 
    public Task<bool> ValidateToken(string token);
}