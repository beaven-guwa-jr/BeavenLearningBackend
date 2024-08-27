using BeavenLearningBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeavenLearningBackend.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JWTConfig _jwtConfig;
    public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _jwtConfig = configuration.GetSection("JwtConfig").Get<JWTConfig>();
    }
    public Task<string> Login(LoginDto model)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Register(RegisterDto model)
    {
        var user = new ApplicationUser()
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        return result.Succeeded;

    }
}
