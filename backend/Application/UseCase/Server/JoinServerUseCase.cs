using Application.DTOs.Server.Requests;
using Application.Interfaces;

namespace Application.UseCase.Server;

public class JoinServerUseCase(IServerChannelEFService serverChannelEFService)
{
    public void Execute(PostServerRequest postServerRequest, string userId)
    {
        serverChannelEFService.JoinServerAsync(Guid.Parse(postServerRequest.Name), Guid.Parse(userId));
    }
}