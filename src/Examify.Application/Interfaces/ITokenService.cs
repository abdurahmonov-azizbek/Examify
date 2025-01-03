using Examify.Domain.Entities.sys;

namespace Examify.Application.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}