using dotnet_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_backend.Configuration;

public class PostConfiguration: IEntityTypeConfiguration<Post>
{
    private static Object[] Seed()
    {
        List<Object> posts = new List<Object>();
        for (long i = 1; i <= 10; i++)
        {
            posts.Add(new
            {
                Id = i,
                UserId = 1L,
                Content = $"Post {i}",
                CreatedAt = new DateTime(2025, 04, 11),
                UpdatedAt = new DateTime(2025, 04, 11)
            });
        }

        return posts.ToArray();
    }
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasData(Seed());
    }
}