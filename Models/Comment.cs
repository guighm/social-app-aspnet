using System.ComponentModel.DataAnnotations;

namespace dotnet_backend.Models;

public class Comment
{
    public long Id { get; set; }
    
    public long UserId { get; set; }
    public required User User { get; set; }
    
    public long PostId { get; set; }
    public required Post Post { get; set; }
    
    [MaxLength(255)]
    public required string Content { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
}