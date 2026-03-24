using Application.DTOs.Auth.Requests;
using Application.DTOs.Profile;
using Application.Interfaces;
using Domain;

namespace Application.UseCase;

public class SignInUseCase
{
    IEntityFrameworkService _entityFrameworkService;
    ITokenService _tokenService;
    public SignInUseCase(IEntityFrameworkService service, ITokenService tokenService)
    {
        _entityFrameworkService = service;
        _tokenService = tokenService;
    }
    public SignInResponse Execute(SignInRequest signInRequest)
    {
        UserEntity user = _entityFrameworkService.VerifyUser(signInRequest.Email, signInRequest.Password);
        string token =  _tokenService.GenerateToken(user.Id);
        return new SignInResponse(token, "refreshToken");
    }
}