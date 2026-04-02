using System.Security.Claims;
using Application.DTOs.Auth.Requests;
using Application.DTOs.Profile;
using Application.UseCase.Auth;
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
    public async Task<ActionResult> SignIn([FromBody] SignInRequest signInRequest)
    {
        SignInResponse signInResponse = authUseCase.SignIn.Execute(signInRequest);
        return Ok(signInResponse);
    }

    [HttpPost("signup")]
    public async Task<ActionResult> SignUp([FromBody] SignUpRequest signUpRequest)
    {
        bool created = authUseCase.SignUp.Execute(signUpRequest);
        if (created) return Ok();
        return Conflict(new { message = "Une erreur est survenue" });
    }
}