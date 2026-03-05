using Application.DTOs.Profile;
using Application.Interfaces;

namespace Application.UseCase;

public class GetProfileUseCase
{
    IEntityFrameworkService _entityFrameworkService;
    
    public GetProfileUseCase(IEntityFrameworkService service)
    {
        _entityFrameworkService = service;
    }

    public ProfileResponse GetProfile()
    {
        ProfileResponse profileResponse = new ProfileResponse("Thomas", "gillet", "thgi@gmail.com");
        return profileResponse; 
    }
}