using Application.DTOs.Auth.Requests;
using Application.DTOs.Profile;
using Application.Interfaces;
using Domain;
using Infrastructure;

namespace Application.UseCase.Auth;

public class SignInUseCase(IUserEFService userEFService, ITokenService tokenService, IPasswordHasher passwordHasher)
{ public SignInResponse Execute(SignInRequest signInRequest)
    {
        UserEntity user = userEFService.VerifyUser(signInRequest.Email, signInRequest.Password);
        if(passwordHasher.Verify(user.Password , signInRequest.Password) == false)
            throw new UnauthorizedAccessException("Invalid email or password.");
        string token =  tokenService.GenerateToken(user.Id);
        // TODO: Generate refresh token 
        return new SignInResponse(token, "refreshToken");
    }
}