using Application.DTOs.Profile;
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
        UserEntity userEntity = new UserEntity("salut", "salut@salut");
        _entityFrameworkService.AddUser(userEntity);
        return true; 
    }
}