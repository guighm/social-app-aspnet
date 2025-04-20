using dotnet_backend.Data;
using dotnet_backend.Dtos;
using dotnet_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_backend.Repositories;

public class PostRepository(AppDbContext context): IPostRepository
{
    public async Task<List<PostDto>> GetAllPosts()
    {
        var posts = await context.Posts
            .Select(p => new PostDto
            {
                Id = p.Id,
                Name = p.User.Name,
                Username = p.User.Username,
                Content = p.Content
            })
            .ToListAsync();
        return posts;
    }
    
    public async Task<Post?> GetOne(long id)
    {
        var post = await context.Posts.FindAsync(id);
        return post;
    }
}