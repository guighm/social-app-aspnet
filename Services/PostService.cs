using dotnet_backend.Dtos;
using dotnet_backend.Models;
using dotnet_backend.Repositories;

namespace dotnet_backend.Services;

public class PostService(IPostRepository repository): IPostService
{
    public async Task<List<PostDto>> GetAllPosts()
    {
        return await repository.GetAllPosts();
    }
    
    public async Task<Post?> GetOne(long id)
    {
        return await repository.GetOne(id);
    }
}