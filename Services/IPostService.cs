using dotnet_backend.Dtos;
using dotnet_backend.Models;

namespace dotnet_backend.Services;

public interface IPostService
{
    public Task<List<PostDto>> GetAllPosts();
    public Task<Post?> GetOne(long id);

}