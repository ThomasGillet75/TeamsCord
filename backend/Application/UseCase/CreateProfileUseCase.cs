using Application.DTOs.Profile.Requests;
using Application.Interfaces;
using Domain;

namespace Application.UseCase;

public class CreateProfileUseCase
{
    IEntityFrameworkService _entityFrameworkService;

    public CreateProfileUseCase(IEntityFrameworkService service)
    {
        _entityFrameworkService = service;
    }

    public bool Execute(SignUpRequest signUpUseRequest)
    {
        _entityFrameworkService.AddUser(new UserEntity(signUpUseRequest.Username, signUpUseRequest.Email,signUpUseRequest.Password));
        return true; 
    }
}