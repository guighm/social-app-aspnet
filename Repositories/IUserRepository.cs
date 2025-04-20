using dotnet_backend.Dtos;
using dotnet_backend.Models;

namespace dotnet_backend.Repositories;

public interface IUserRepository
{
    public Task<User?> GetOne(string username);
}