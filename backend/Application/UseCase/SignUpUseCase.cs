using Application.DTOs.Auth.Requests;
using Application.Interfaces;
using Domain;

namespace Application.UseCase;

public class SignUpUseCase
{
    IEntityFrameworkService _entityFrameworkService;

    public SignUpUseCase(IEntityFrameworkService service)
    {
        _entityFrameworkService = service;
    }

    public bool Execute(SignUpRequest signUpUseRequest)
    {
        _entityFrameworkService.AddUser(new UserEntity(signUpUseRequest.Username, signUpUseRequest.Email,signUpUseRequest.Password));
        return true; 
    }
}