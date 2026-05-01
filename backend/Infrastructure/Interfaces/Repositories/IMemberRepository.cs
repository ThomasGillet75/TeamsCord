using Infrastructure.Models;

namespace Infrastructure.Interfaces.Repositories;

public interface IMemberRepository
{
    Task<Member?> GetMemberAsync(Guid serverId, Guid userId, CancellationToken cancellationToken = default);
    void AddMember(Member member, CancellationToken cancellationToken = default);
    void DeleteMemberByServerId(Guid serverId, CancellationToken cancellationToken = default);
}

