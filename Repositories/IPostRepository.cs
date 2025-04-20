using dotnet_backend.Dtos;
using dotnet_backend.Models;

namespace dotnet_backend.Repositories;

public interface IPostRepository
{
    public Task<List<PostDto>> GetAllPosts();
    public Task<Post?> GetOne(long id);
}