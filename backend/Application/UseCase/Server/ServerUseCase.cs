namespace Application.UseCase.Server;

public record ServerUseCase
(
    GetServersUseCase GetServers,
    AddServerUseCase AddServer,
    GetChannelsUseCase GetChannels,
    AddChannelUseCase AddChannel,
    DeleteServerUseCase DeleteServer
);