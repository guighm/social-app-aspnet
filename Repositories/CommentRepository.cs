using dotnet_backend.Data;
using dotnet_backend.Dtos;
using dotnet_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_backend.Repositories;

public class CommentRepository(AppDbContext context): ICommentRepository
{
    public async Task<Comment?> GetById(long id)
    {
        var comment = await context.Comments.FindAsync(id);
        return comment;
    }
    
    public async Task<List<CommentDto>> GetAllComments(long id)
    {
        var comments = await context.Comments
            .Where(c => c.PostId == id)
            .Select(c => new CommentDto
            {
                Username = c.User.Username,
                Content = c.Content
            })
            .ToListAsync();
        return comments;
    }
    
    public async Task<Comment> CreateComment(CreateCommentDto dto, User user, Post post)
    {
        var comment = new Comment
        {
            User = user,
            Content = dto.Content,
            Post = post
        };

        await context.Comments.AddAsync(comment);
        await context.SaveChangesAsync();
        return comment;
    }
}