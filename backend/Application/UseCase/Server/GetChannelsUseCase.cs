using Application.DTOs.Server.Responses;
using Application.Interfaces;
using Domain.Entity;

namespace Application.UseCase.Server;

public class GetChannelsUseCase(IServerChannelEFService serverChannelEFService)
{
    public async Task<GetChannelsResponse> Execute(string serverId)
    {
        IReadOnlyList<ChannelEntity> channels = await serverChannelEFService.GetChannelsByServerIdAsync(Guid.Parse(serverId));
        return new GetChannelsResponse(channels);
    }
}