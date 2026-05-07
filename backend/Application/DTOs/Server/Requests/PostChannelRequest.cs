using Domain.Entity;
using Domain.Enum;

namespace Application.DTOs.Server.Requests;

public record PostChannelRequest(Guid ServerId, string Name, EChannel Type);