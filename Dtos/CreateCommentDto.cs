using System.ComponentModel.DataAnnotations;

namespace dotnet_backend.Dtos;

public class CreateCommentDto
{
    public long PostId { get; set; }
    
    [MaxLength(255)] 
    public required string Content { get; set; }
    
    [MaxLength(255)]
    public required string Username { get; set; }
}