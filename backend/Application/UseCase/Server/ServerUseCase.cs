namespace Application.UseCase.Server;

public record ServerUseCase
(
    GetServersUseCase GetServers,
    AddServerUseCase AddServer,
    JoinServerUseCase JoinServer,
    GetChannelsUseCase GetChannels,
    AddChannelUseCase AddChannel,
    DeleteServerUseCase DeleteServer
);