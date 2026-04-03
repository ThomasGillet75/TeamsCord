namespace Application.UseCase.Server;

public record ServerUseCase
(
    GetServersUseCase GetServers,
    AddServerUseCase AddServer
);