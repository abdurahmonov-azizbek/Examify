using System;
using Examify.Application.Interfaces;
using Examify.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examify.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpGet("login")]
    public async ValueTask<IActionResult> Login([FromQuery] LoginDetails loginDetails)
    {
        var result = await authService.LoginAsync(loginDetails);
        return Ok(result);
    }
}
