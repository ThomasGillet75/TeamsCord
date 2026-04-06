using System.Security.Claims;
using Application.DTOs.Server.Requests;
using Application.UseCase.Server;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
    
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> AddServer(PostServerRequest postServerRequest)
    {
        string? userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userIdClaim)) return Unauthorized();
        serverUseCase.AddServer.Execute(postServerRequest, userIdClaim);
        return Ok();
    }

    [Authorize]
    [HttpGet("{serverId}")]
    public async Task<ActionResult> GetChannels(Guid serverId)
    {
        return Ok(await serverUseCase.GetChannels.Execute(serverId.ToString()));
    }

    [Authorize]
    [HttpPost("channel")]
    public async Task<ActionResult>  AddChannel(PostChannelRequest postChannelRequest)
    {
        serverUseCase.AddChannel.Execute(postChannelRequest);
        return Ok();
    }
}