using Application.DTOs.Profile;
using Application.DTOs.Profile.Requests;
using Application.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Route("api/auth")]
public class ProfileController(AuthUseCase authUseCase) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetProfile()
    {
        ProfileResponse profileResponse = authUseCase.Get.Execute();
        
        return Ok(profileResponse);
    }

    [HttpPost]
    public async Task<ActionResult> SignUp(SignUpRequest signUpRequest)
    {
        bool profileResponse = authUseCase.SignUp.Execute(signUpRequest);
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