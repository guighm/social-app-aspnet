using dotnet_backend.Repositories;

namespace dotnet_backend.Services;

public class LikeService(ILikeRepository repository): ILikeService
{
    public async Task<int> GetLikesCount(long id)
    {
        return await repository.GetLikesCount(id);
    }
}