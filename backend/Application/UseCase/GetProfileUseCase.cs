using Application.DTOs.Auth.Requests;
using Application.DTOs.Profile;
using Application.Interfaces;
using Domain;

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

    public async Task<GetUserResponse> Execute(GetUserRequest getUserRequest)
    {
        bool isTokenValid = await _tokenService.IsTokenValid(getUserRequest.accessToken);
        if(isTokenValid)
        {
            throw new Exception("Invalid token");
        }
        UserEntity userEntity = _entityFrameworkService.GetUserById(Guid.Parse(getUserRequest.Id));
        return new GetUserResponse(userEntity);
    }
}