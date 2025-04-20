namespace dotnet_backend.Dtos;

public class PostDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Username { get; set; }
    public required string Content { get; set; }
}