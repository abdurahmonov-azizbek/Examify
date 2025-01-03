using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Examify.Application.Interfaces;
using Examify.Core.Settings;
using Examify.Domain.Entities.sys;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Examify.Application.Services;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public string GenerateToken(User user)
    {
        var jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>()
            ?? throw new Exception("Jwt settings is not configured!");

        var claims = GetClaims(user);
        var credentials = GetSigningCredentials(jwtSettings);

        var tokenOptions = new JwtSecurityToken(
            issuer: jwtSettings.ValidIssuer,
            audience: jwtSettings.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(jwtSettings.Expires),
            signingCredentials: credentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        
        return token;
    }

    private List<Claim> GetClaims(User user)
    {
        return new List<Claim>
        {
            new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };
    }

    private SigningCredentials GetSigningCredentials(JwtSettings jwtSettings)
    {
        var secretKey = jwtSettings.SecretKey;
        var key = Encoding.UTF8.GetBytes(secretKey);
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }
}