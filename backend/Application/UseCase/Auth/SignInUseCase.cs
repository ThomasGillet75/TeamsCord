using Application.DTOs.Auth.Requests;
using Application.DTOs.Profile;
using Application.Interfaces;
using Domain;
using Infrastructure;

namespace Application.UseCase.Auth;

public class SignInUseCase(IUserEFService userEFService, ITokenService tokenService)
{ public SignInResponse Execute(SignInRequest signInRequest)
    {
        UserEntity user = userEFService.VerifyUser(signInRequest.Email, signInRequest.Password);
        string token =  tokenService.GenerateToken(user.Id);
        // TODO: Generate refresh token 
        return new SignInResponse(token, "refreshToken");
    }
}