using Examify.Domain.DTOs;
using Examify.Domain.Entities.sys;

namespace Examify.Application.Mappers;

public static class UserMapper
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            PasswordHash = user.PasswordHash,
            IsAdmin = user.IsAdmin,
        };
    }

    public static User ToEntity(this UserDto dto)
    {
        return new User()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            PasswordHash = dto.PasswordHash,
            IsAdmin = dto.IsAdmin,
        };
    }
}