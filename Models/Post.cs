using System.ComponentModel.DataAnnotations;

namespace dotnet_backend.Models;

public class Post
{
    public long Id { get; set; }
    
    public long UserId { get; set; }
    public required User User { get; set; }
    
    [MaxLength(255)]
    public required string Content { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }

    public ICollection<Comment> Comments = new List<Comment>();
    public ICollection<Like> Likes = new List<Like>();
}