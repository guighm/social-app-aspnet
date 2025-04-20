using dotnet_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_backend.Configuration;

public class CommentConfiguration: IEntityTypeConfiguration<Comment>
{

    private static Object[] Seed()
    {
        List<Object> comments = new List<Object>();
        for (long i = 1; i <= 10; i++)
        {
            comments.Add(new
            {
                Id = i,
                UserId = 2L,
                PostId = 2L,
                Content = $"Comentário {i}",
                CreatedAt = new DateTime(2025, 04, 11),
                UpdatedAt = new DateTime(2025, 04, 11)
            });
        }

        return comments.ToArray();
    }
    
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(Seed());
    }
}