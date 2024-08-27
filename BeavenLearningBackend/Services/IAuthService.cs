using BeavenLearningBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeavenLearningBackend.Services;

public interface IAuthService
{
    public Task<bool> Register(RegisterDto model);
    public Task<string> Login(LoginDto model);
}
