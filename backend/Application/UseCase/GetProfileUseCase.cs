using Application.DTOs.Profile;
using Application.Interfaces;
using Domain;

namespace Application.UseCase;

public class GetProfileUseCase
{
    IEntityFrameworkService _entityFrameworkService;

    public GetProfileUseCase(IEntityFrameworkService service, ITokenService tokenService)
    {
        _entityFrameworkService = service;
    }

    public async Task<GetUserResponse> Execute(string userId)
    {
        UserEntity userEntity = _entityFrameworkService.GetUserById(Guid.Parse(userId));
        return new GetUserResponse(userEntity.Username);
    }
}