using Examify.Application.Interfaces;
using Examify.Application.Mappers;
using Examify.Domain.DbContexts;
using Examify.Domain.DTOs;

namespace Examify.Application.Services;

public class UserService(IPasswordHasher passwordHasher, EContext context) : IUserService
{
    public IQueryable<UserDto> GetAll()
        => context.Users.Where(user => user.IsActive).Select(user => user.ToDto());

    public async ValueTask<UserDto> GetByIdAsync(int userId)
    {
        var foundUser = await context.Users.FindAsync(userId)
                        ?? throw new Exception($"User not found with id: {userId}");

        return foundUser.ToDto();
    }

    public async ValueTask CreateAsync(UserDto userDto)
    {
        var user = userDto.ToEntity();
        user.IsActive = true;
        user.PasswordHash = passwordHasher.Hash(user.PasswordHash);
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async ValueTask UpdateAsync(UserDto userDto)
    {
        var user = userDto.ToEntity();
        user.PasswordHash = passwordHasher.Hash(user.PasswordHash);
        user.ModifiedDate = DateTime.UtcNow.AddHours(5);
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(int userId)
    {
        var user = context.Users.Find(userId)
                   ?? throw new Exception($"User not found with id: {userId}");

        user.IsActive = false;
        await context.SaveChangesAsync();
    }
}