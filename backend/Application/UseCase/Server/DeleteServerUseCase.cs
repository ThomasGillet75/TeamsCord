using Application.DTOs.Server.Requests;
using Application.Interfaces;

namespace Application.UseCase.Server;

public class DeleteServerUseCase(IServerChannelEFService serverChannelEFService)
{
    public async void Execute(DeleteServerRequest request)
    {
        serverChannelEFService.DeleteServerAsync(Guid.Parse(request.ServerId));
    }
}