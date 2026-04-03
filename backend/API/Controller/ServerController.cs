using System.Security.Claims;
using Application.UseCase.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
public class ServerController(ServerUseCase serverUseCase) : ControllerBase 
{
    [HttpGet("api/servers")]
    [Authorize]
    public async Task<ActionResult> GetUserServers()
    {
        string? userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userIdClaim)) return Unauthorized();
        serverUseCase.GetServers.Execute(userIdClaim);
        return Ok();
    }
}