using Domain.Entity;

namespace Application.DTOs.Server.Responses;

public record GetServersResponse(IReadOnlyList<ServerEntity> servers);