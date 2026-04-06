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
    [HttpGet("all/servers")]
    [Authorize]
    public async Task<ActionResult> GetUserServers()
    {
        string? userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userIdClaim)) return Unauthorized();
        return Ok(await serverUseCase.GetServers.Execute(userIdClaim));
    }
    
    [HttpPost("add/server")]
    [Authorize]
    public async Task<ActionResult> AddServer(PostServerRequest postServerRequest)
    {
        string? userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userIdClaim)) return Unauthorized();
        serverUseCase.AddServer.Execute(postServerRequest, userIdClaim);
        return Ok();
    }

    [HttpGet("all/channels")]
    [Authorize]
    public async Task<ActionResult> GetChannels([FromQuery] GetChannelsRequest request)
    {
        return Ok(await serverUseCase.GetChannels.Execute(request));
    }

    [HttpPost("add/channel")]
    [Authorize]
    public async Task<ActionResult>  AddChannel(PostChannelRequest postChannelRequest)
    {
        serverUseCase.AddChannel.Execute(postChannelRequest);
        return Ok();
    }
}