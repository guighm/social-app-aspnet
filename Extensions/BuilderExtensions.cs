using dotnet_backend.Data;
using dotnet_backend.Repositories;
using dotnet_backend.Services;
using Microsoft.EntityFrameworkCore;

namespace dotnet_backend.Extensions;

public static class BuilderExtensions
{
    public static void DependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IPostService, PostService>();

        services.AddScoped<ILikeRepository, LikeRepository>();
        services.AddScoped<ILikeService, LikeService>();

        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ICommentService, CommentService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
    }
    
    public static void AddCorsPolicy(this IServiceCollection services, string policyName)
    {
        services.AddCors(opt =>
        {
            opt.AddPolicy(policyName, policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }
    
    public static void AddDbContextConfiguration(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
    }
}