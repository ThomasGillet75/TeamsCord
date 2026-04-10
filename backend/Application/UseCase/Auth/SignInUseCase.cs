using Application.DTOs.Auth.Requests;
using Application.DTOs.Profile;
using Application.Interfaces;
using Domain;
using Infrastructure;

namespace Application.UseCase.Auth;

public class SignInUseCase(IUserEFService userEFService, ITokenService tokenService, IPasswordService passwordService)
{
    public SignInResponse Execute(SignInRequest signInRequest)
    {
        UserEntity user = userEFService.VerifyUser(signInRequest.Email);
        if (string.IsNullOrWhiteSpace(signInRequest.Password))
            throw new ArgumentException("password is required");
        if (passwordService.Verify(signInRequest.Password, user.Password) == false)
            throw new UnauthorizedAccessException("Invalid password.");

        string token = tokenService.GenerateToken(user.Id);
        // TODO: Generate refresh token 
        return new SignInResponse(token, "refreshToken");

    }
}