using System.Security.Claims;
using Application.DTOs.Server.Requests;
using Application.UseCase.Server;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("join/server")]
    [Authorize]
    public async Task<ActionResult> JoinServer(PostServerRequest joinServerRequest)
    {
        string? userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userIdClaim)) return Unauthorized();
        serverUseCase.JoinServer.Execute(joinServerRequest, userIdClaim);
        return Ok();
    }

    [HttpDelete("delete/server/{serverId}")]
    [Authorize]
    public async Task<ActionResult> DeleteServer(string serverId)
    {
        DeleteServerRequest request = new DeleteServerRequest(serverId);
        serverUseCase.DeleteServer.Execute(request);
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