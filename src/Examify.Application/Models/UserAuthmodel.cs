using System;
using Examify.Domain.DTOs;

namespace Examify.Application.Models;

public class UserAuthmodel
{
    public string Token { get; set; }
    public UserDto UserInfo { get; set; }
}
