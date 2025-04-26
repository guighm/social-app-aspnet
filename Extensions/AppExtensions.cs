using dotnet_backend.Data;
using dotnet_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_backend.Extensions;

public static class AppExtensions
{

    public static async Task MigrateAndSeedAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await dbContext.Database.MigrateAsync();
        await dbContext.SeedAsync();
    }
    
    private static async Task SeedAsync(this AppDbContext dbContext)
    {
        var users = new List<User>();
        var posts = new List<Post>();

        if (!dbContext.Users.Any())
        {
            for (var i = 1; i <= 10; i++)
            {
                var user = new User
                {
                    Name = $"Usuário {i}",
                    Username = $"user{i}",
                    Email = $"user{i}@email.com",
                    Password = "123",
                    Bio = $"Sou o Usuário {i}",
                    AvatarUrl = $"UrlDoUsuario{i}"
                };
                
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
                users.Add(user);
            }
        }
        
        if (!dbContext.Posts.Any())
        {
            for (var i = 1; i <= 10; i++)
            {
                var post = new Post
                {
                    User = users[0],
                    Content = $"Post {i}"
                };
                
                await dbContext.Posts.AddAsync(post);
                await dbContext.SaveChangesAsync();
                posts.Add(post);
            }
        }
        
        if (!dbContext.Comments.Any())
        {
            for (var i = 1; i <= 10; i++)
            {
                var comment = new Comment
                { 
                    User = users[1],
                    Post = posts[1],
                    Content = $"Comentário {i}"
                };
                await dbContext.Comments.AddAsync(comment);
                await dbContext.SaveChangesAsync();
            }
        }

        if (!dbContext.Likes.Any())
        {
            for (var i = 1; i <= 10; i++)
            {
                var like = new Like
                {
                    User = users[1],
                    Post = posts[0]
                };

                await dbContext.Likes.AddAsync(like);
                await dbContext.SaveChangesAsync();

                i++;
                
                like = new Like
                {
                    User = users[2],
                    Post = posts[0]
                };

                await dbContext.Likes.AddAsync(like);
                await dbContext.SaveChangesAsync();
            }
        }

    }
}