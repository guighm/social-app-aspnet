using System.ComponentModel.DataAnnotations;

namespace dotnet_backend.Models;

public class User
{
    public long Id { get; set; }
    
    [MaxLength(255)]
    public required string Name { get; set; }
    
    [MaxLength(255)]
    public required string Username { get; set; }
    
    [MaxLength(255)]
    public required string Email { get; set; }
    
    [MaxLength(255)]
    public required string Password { get; set; }
    
    [MaxLength(255)]
    public required string Bio { get; set; }
    
    [MaxLength(255)]
    public required string AvatarUrl { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }

    public ICollection<Post> Posts = new List<Post>();
    public ICollection<Comment> Comments = new List<Comment>();
    public ICollection<Like> Likes = new List<Like>();
    public ICollection<Friendship> Friendships = new List<Friendship>();
}