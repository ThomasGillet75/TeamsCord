using Infrastructure.Interfaces.Repositories;
using Infrastructure.Models;

namespace Infrastructure.Repository;

public class MemberRepository(DatabaseContext db) : IMemberRepository
{
    public Task<Member?> GetMemberAsync(Guid serverId, Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void AddMember(Member member, CancellationToken cancellationToken = default)
    {
        
        db.Members.Add(member);
        db.SaveChanges();
    }

    public void DeleteMemberByServerId(Guid serverId, CancellationToken cancellationToken = default)
    {
        IQueryable<Member> membersToDelete = db.Members.Where(member => member.ServerId == serverId);
        db.Members.RemoveRange(membersToDelete);
        db.SaveChanges();
    }
}

