namespace Application.Interfaces;

public interface ITokenService
{
    public string GenerateToken(Guid userId); 
}