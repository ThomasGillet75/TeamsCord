using Application.Interfaces;
using Domain.Entity;
using Infrastructure;

namespace Application.UseCase.Server;

public class GetServersUseCase(IServerChannelEFService serverChannelEFService)
{
    public async Task<IReadOnlyList<ServerEntity>> Execute(string userId)
    {
        return await serverChannelEFService.GetUserServersAsync(Guid.Parse(userId));
    }
}