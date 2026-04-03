namespace Domain.Entity;

public class MemberEntity
{
    string ServerId { get; set; }
    
    string UserId { get; set; }
    
    ERole Role { get; set; }
}