using dotnet_backend.Dtos;
using dotnet_backend.Models;
using dotnet_backend.Repositories;

namespace dotnet_backend.Services;

public class CommentService(ICommentRepository repository): ICommentService
{
    public async Task<Comment?> GetById(long id)
    {
        return await repository.GetById(id);
    }

    public async Task<List<CommentDto>> GetAllComments(long id)
    {
        return await repository.GetAllComments(id);
    }

    public async Task<Comment> CreateComment(CreateCommentDto dto, User user, Post post)
    {
        return await repository.CreateComment(dto, user, post);
    }
}