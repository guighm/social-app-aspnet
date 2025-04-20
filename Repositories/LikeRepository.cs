using dotnet_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnet_backend.Repositories;

public class LikeRepository(AppDbContext context): ILikeRepository
{
    public async Task<int> GetLikesCount(long id)
    {
        var number = await context.Likes.CountAsync(c => c.PostId == id);
        return number;
    }
}