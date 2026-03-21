using Application.DTOs.Auth.Requests;
using Application.DTOs.Profile;
using Application.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Route("api/auth")]
public class AuthController(AuthUseCase authUseCase) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetProfile()
    {
        authUseCase.Get.Execute();
        
        return Ok();
    }
    
    [HttpPost("signin")]
    public async Task<ActionResult> SignIn(SignInRequest signInRequest)
    {
        SignInResponse signInResponse = authUseCase.SignIn.Execute(signInRequest);
        return Ok(signInResponse);
    }

    [HttpPost("signup")]
    public async Task<ActionResult> SignUp(SignUpRequest signUpRequest)
    {
        bool signUpResponse = authUseCase.SignUp.Execute(signUpRequest);
        return Ok(signUpResponse);
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