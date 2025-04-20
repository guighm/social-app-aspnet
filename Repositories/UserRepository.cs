using dotnet_backend.Data;
using dotnet_backend.Dtos;
using dotnet_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_backend.Repositories;

public class UserRepository(AppDbContext context): IUserRepository
{
    public async Task<User?> GetOne(string username)
    {
        var user = await context.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
        return user;
    }
}