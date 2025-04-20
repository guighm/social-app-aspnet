namespace dotnet_backend.Repositories;

public interface ILikeRepository
{
    public Task<int> GetLikesCount(long id);
}