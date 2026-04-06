using Domain.Entity;

namespace Application.DTOs.Server.Requests;

public record PostChannelRequest(Guid ServerId, string Name);