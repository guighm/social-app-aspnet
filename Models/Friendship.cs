using System.ComponentModel.DataAnnotations;

namespace dotnet_backend.Models;

public class Friendship
{
    public long Id { get; set; }
    
    public long UserId { get; set; }
    public required User User { get; set; }
    
    public long FriendId { get; set; }
    public required User Friend { get; set; }
    
    [MaxLength(255)]
    public required string Status { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}