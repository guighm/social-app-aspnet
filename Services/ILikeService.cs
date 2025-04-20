namespace dotnet_backend.Services;

public interface ILikeService
{
    public Task<int> GetLikesCount(long id);
}