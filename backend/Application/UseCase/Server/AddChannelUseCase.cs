using Application.DTOs.Server.Requests;
using Application.Interfaces;
using Domain.Entity;

namespace Application.UseCase.Server;

public class AddChannelUseCase(IServerChannelEFService serverChannelEFService)
{
    public void Execute(PostChannelRequest request)
    {
        serverChannelEFService.AddChannelAsync(new ChannelEntity(request.Name, request.ServerId));
    }
}