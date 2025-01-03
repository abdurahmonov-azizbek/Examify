using Examify.Domain.DTOs;
using Examify.Domain.Entities.sys;

namespace Examify.Application.Interfaces;

public interface IUserService
{
    IQueryable<UserDto> GetAll();
    ValueTask<UserDto> GetByIdAsync(int userId);
    ValueTask CreateAsync(UserDto userDto);
    ValueTask UpdateAsync(UserDto userDto);
    ValueTask DeleteAsync(int userId);
}