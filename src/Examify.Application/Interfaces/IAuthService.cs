using System;
using Examify.Application.Models;

namespace Examify.Application.Interfaces;

public interface IAuthService
{
    Task<UserAuthmodel> LoginAsync(LoginDetails loginDetails);
}
