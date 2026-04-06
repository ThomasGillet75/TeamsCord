using Application.DTOs.Server.Requests;
using Application.DTOs.Server.Responses;
using Application.Interfaces;
using Domain.Entity;

namespace Application.UseCase.Server;

public class GetChannelsUseCase(IServerChannelEFService serverChannelEFService)
{
    public async Task<GetChannelsResponse> Execute(GetChannelsRequest request)
    {
        IReadOnlyList<ChannelEntity> channels = await serverChannelEFService.GetChannelsByServerIdAsync(request.ServerId);
        return new GetChannelsResponse(channels);
    }
}