using Application.DTOs.Profile;
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

    public bool Execute(CreateProfileRequest createProfileUseRequest)
    {
        _entityFrameworkService.AddUser(new UserEntity(createProfileUseRequest.Username, createProfileUseRequest.Email,createProfileUseRequest.Password));
        return true; 
    }
}