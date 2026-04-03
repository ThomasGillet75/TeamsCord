using Application.DTOs.Auth.Requests;
using Application.Interfaces;
using Domain;
using Infrastructure;

namespace Application.UseCase.Auth;

public class SignUpUseCase(IUserEFService userEFService)
{
    public bool Execute(SignUpRequest signUpUseRequest)
    {
        userEFService.AddUser(new UserEntity(signUpUseRequest.Username, signUpUseRequest.Email,signUpUseRequest.Password));
        return true; 
    }
}