using Application.DTOs.Profile;
using Application.Interfaces;

namespace Application.UseCase;

public class GetProfileUseCase
{
    IEntityFrameworkService _entityFrameworkService;
    ITokenService _tokenService;

    public GetProfileUseCase(IEntityFrameworkService service, ITokenService tokenService)
    {
        _entityFrameworkService = service;
        _tokenService = tokenService;
    }

    public void Execute()
    {
        
    }
}