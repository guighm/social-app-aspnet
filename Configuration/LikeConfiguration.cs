using dotnet_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_backend.Configuration;

public class LikeConfiguration: IEntityTypeConfiguration<Like>
{
    private static Object[] Seed()
    {
        List<Object> likes = new List<Object>();
        for (long i = 1; i <= 10; i++)
        {
            likes.Add(new
            {
                Id = i,
                UserId = 2L,
                PostId = 1L,
                CreatedAt = new DateTime(2025, 04, 11)
            });

            i++;
            
            likes.Add(new
            {
                Id = i,
                UserId = 3L,
                PostId = 1L,
                CreatedAt = new DateTime(2025, 04, 11)
            });
        }

        return likes.ToArray();
    }
    
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.HasOne(l => l.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(Seed());

    }
}