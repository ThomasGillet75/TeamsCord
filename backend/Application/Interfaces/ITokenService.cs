namespace Application.Interfaces;

public interface ITokenService
{
    public string GenerateToken(Guid userId, string email); 
    public Task<bool> ValidateToken(string token);
}