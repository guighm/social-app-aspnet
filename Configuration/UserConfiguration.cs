using dotnet_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_backend.Configuration;

public class UserConfiguration: IEntityTypeConfiguration<User>
{

    private static User[] Seed()
    {
        List<User> users = new List<User>();
        for (long i = 1; i <= 10; i++)
        {
            users.Add(new User
            {
                Id = i,
                Name = $"Usuário {i}",
                Username = $"user{i}",
                Email = $"user{i}@email.com",
                Password = "123",
                Bio = $"Sou o Usuário {i}",
                AvatarUrl = $"UrlDoUsuario{i}",
                CreatedAt = new DateTime(2025, 04, 11),
                UpdatedAt = new DateTime(2025, 04, 11)
            });
        }

        return users.ToArray();
    }

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(Seed());
    }
}