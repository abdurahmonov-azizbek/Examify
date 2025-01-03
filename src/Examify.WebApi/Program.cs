using Examify.Application.Interfaces;
using Examify.Application.Services;
using Examify.Domain.DbContexts;
using Examify.WebApi.Configurations;
using Examify.WebApi.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace Examify.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.ConfigureDbContexts(builder.Configuration);
            builder.Services.AddHttpContextAccessor();
            builder.Services.ConfigureJWT(builder.Configuration);
            builder.Services.ConfigureSwaggerServices();

            // Add services to DI
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseMiddleware<ErrorResponseMiddleware>();
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
