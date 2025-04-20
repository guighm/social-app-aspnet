using dotnet_backend.Dtos;
using dotnet_backend.Models;

namespace dotnet_backend.Repositories;

public interface ICommentRepository
{
    public Task<Comment?> GetById(long id);
    public Task<List<CommentDto>> GetAllComments(long id);
    public Task<Comment> CreateComment(CreateCommentDto dto, User user, Post post);
}