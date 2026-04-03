using System.Security.Claims;
using Application.DTOs.Server.Requests;
using Application.UseCase.Server;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Route("api/server")]
public class ServerController(ServerUseCase serverUseCase) : ControllerBase 
{
    [Authorize]
    [HttpGet("all")]
    public async Task<ActionResult> GetUserServers()
    {
        string? userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userIdClaim)) return Unauthorized();
        return Ok(serverUseCase.GetServers.Execute(userIdClaim));
    }
    
    [HttpPost]
    public async Task<ActionResult> AddServer(PostServerRequest postServerRequest)
    {
        string? userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userIdClaim)) return Unauthorized();
        serverUseCase.AddServer.Execute(postServerRequest, userIdClaim);
        return Ok();
    }
    
}