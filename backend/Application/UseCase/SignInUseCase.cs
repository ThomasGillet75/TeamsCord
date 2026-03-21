using Application.DTOs.Auth.Requests;
using Application.DTOs.Profile;
using Application.Interfaces;

namespace Application.UseCase;

public class SignInUseCase
{
    IEntityFrameworkService _entityFrameworkService;
    
    public SignInUseCase(IEntityFrameworkService service)
    {
        _entityFrameworkService = service;
    }
    public SignInResponse Execute(SignInRequest signInRequest)
    {
        if (_entityFrameworkService.VerifyUser(signInRequest.Email, signInRequest.Password))
        {
            return new SignInResponse("accessToken", "refreshToken");
        }
        throw new Exception("Invalid email or password");
    }
}