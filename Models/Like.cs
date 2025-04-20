using System.ComponentModel.DataAnnotations;

namespace dotnet_backend.Models;

public class Like
{
    public long Id { get; set; }
    
    public long UserId { get; set; }
    public required User User { get; set; }
    
    public long PostId { get; set; }
    public required Post Post { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}