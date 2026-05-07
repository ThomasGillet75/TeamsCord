using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;


[Table("Messages")]
[PrimaryKey(nameof(MessageId))]
public class Message
{
    public Guid MessageId { get; set; }
    
    [MaxLength(2000)]
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    [ForeignKey(nameof(Channel))]
    public Guid ChannelId { get; set; }
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    
    public Channel? Channel { get; set; }
    
    [SetsRequiredMembers]
    public Message(Guid messageId, string content, DateTime createdAt, Guid channelId, Guid userId)
    {
        MessageId = messageId;
        Content = content;
        CreatedAt = createdAt;
        ChannelId = channelId;
        UserId = userId;
    }
}