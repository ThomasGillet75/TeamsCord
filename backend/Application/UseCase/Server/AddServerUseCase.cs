using Application.DTOs.Server.Requests;
using Application.Interfaces;
using Domain.Entity;

namespace Application.UseCase.Server;

public class AddServerUseCase(IServerChannelEFService serverChannelEFService)
{
    public void Execute(PostServerRequest postServerRequest, string userId)
    {
        serverChannelEFService.AddServerAsync(new ServerEntity(postServerRequest.Name, "icon"), Guid.Parse(userId));
    }
}