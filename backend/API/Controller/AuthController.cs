using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.DTOs.Auth.Requests;
using Application.DTOs.Profile;
using Application.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Route("api/auth")]
public class AuthController(AuthUseCase authUseCase) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<ActionResult> GetProfile()
    {
        string? userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userIdClaim)) return Unauthorized();
        GetUserResponse getUserResponse = await authUseCase.Get.Execute(userIdClaim);
        return Ok(getUserResponse);
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
        authUseCase.SignUp.Execute(signUpRequest);
        return Ok();
    }
}