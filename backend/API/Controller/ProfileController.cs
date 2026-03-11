using Application.DTOs.Profile;
using Application.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Route("api/profile")]
public class ProfileController(ProfileUseCases profileUseCases) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetProfile()
    {
        ProfileResponse profileResponse = profileUseCases.Get.Execute();
        
        return Ok(profileResponse);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProfile(CreateProfileRequest createProfileRequest)
    {
        bool profileResponse = profileUseCases.Create.Execute(createProfileRequest);
        return Ok(profileResponse);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProfile()
    {
        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteProfile()
    {
        return Ok();
    }
}