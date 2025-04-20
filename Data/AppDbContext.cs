using dotnet_backend.Configuration;
using dotnet_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_backend.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Friendship> Friendships { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CommentConfiguration());

        modelBuilder.ApplyConfiguration(new FriendshipConfiguration());
        
        modelBuilder.ApplyConfiguration(new LikeConfiguration());
        
        modelBuilder.ApplyConfiguration(new PostConfiguration());
        
        modelBuilder.ApplyConfiguration(new UserConfiguration());

    }
}