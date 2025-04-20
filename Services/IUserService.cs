using dotnet_backend.Dtos;
using dotnet_backend.Models;

namespace dotnet_backend.Services;

public interface IUserService
{
    public Task<User?> GetOne(string username);
}