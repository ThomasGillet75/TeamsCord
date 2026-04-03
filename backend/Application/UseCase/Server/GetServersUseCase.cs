using Application.DTOs.Server.Responses;
using Application.Interfaces;

namespace Application.UseCase.Server;

public class GetServersUseCase(IServerChannelEFService serverChannelEFService)
{
    public async Task<GetServersResponse> Execute(string userId)
    {
        return new GetServersResponse(await serverChannelEFService.GetUserServersAsync(Guid.Parse(userId)));
    }
}