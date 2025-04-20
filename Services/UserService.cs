using dotnet_backend.Dtos;
using dotnet_backend.Models;
using dotnet_backend.Repositories;

namespace dotnet_backend.Services;

public class UserService(IUserRepository repository): IUserService
{
    public async Task<User?> GetOne(string username)
    {
        return await repository.GetOne(username);
    }
}