using BeavenLearningBackend.Models;
using BeavenLearningBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeavenLearningBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService service) : ControllerBase
{


    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var newUser = await service.Register(model);
        if (newUser)
        {
            return Ok(new
            {
                message = "User Registered"
            });
        }
        return BadRequest();
    }
}

// Assignment: try to set up login from the controller - comms with service, getting data and back!