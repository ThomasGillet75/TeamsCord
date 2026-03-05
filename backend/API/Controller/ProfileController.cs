using Application.DTOs.Profile;
using Application.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Route("api/profile")]
public class ProfileController(GetProfileUseCase getProfileUseCase) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetProfile()
    {
        ProfileResponse profileResponse = new ProfileResponse("Gillet","Thomas","thomate@gmail.com");
        
        return Ok(profileResponse);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProfile()
    {
        return Ok();
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