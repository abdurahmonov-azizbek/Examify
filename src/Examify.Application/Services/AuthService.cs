using System;
using Examify.Application.Interfaces;
using Examify.Application.Mappers;
using Examify.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Examify.Application.Services;

public class AuthService(
    IUserService userService,
    IPasswordHasher passwordHasher,
    ITokenService tokenService) : IAuthService
{
    public Task<UserAuthmodel> LoginAsync(LoginDetails loginDetails)
    {
        var user = userService.GetAll().ToList().FirstOrDefault(user => user.PhoneNumber == loginDetails.PhoneNumber)
            ?? throw new Exception("User not found with this phone number!");

        if(!passwordHasher.Verify(loginDetails.Password, user.PasswordHash))
            throw new Exception("Incorrect password");

        var token = tokenService.GenerateToken(user.ToEntity());

        return Task.FromResult(new UserAuthmodel
        {
            Token = token,
            UserInfo = user
        });
    }
}
