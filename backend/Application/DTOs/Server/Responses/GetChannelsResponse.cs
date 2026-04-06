using System.Threading.Channels;
using Domain.Entity;

namespace Application.DTOs.Server.Responses;

public record GetChannelsResponse(IReadOnlyList<ChannelEntity> channels);