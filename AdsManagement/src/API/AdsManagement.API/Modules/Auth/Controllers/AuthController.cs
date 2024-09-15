using AdsManagement.Modules.Auth.Application.Contracts;
using Application;
using Microsoft.AspNetCore.Mvc;

namespace AdsManagement.API.Modules.Auth.Controllers;

[ApiController]
[Route("api/auth/login")]
public class AuthController : ControllerBase
{
    private readonly IAuthModule _authModule;

    public AuthController(IAuthModule authModule)
    {
        _authModule = authModule;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAuthenticatedUser()
    {
        var user = await _authModule.ExecuteQueryAsync(new TestQuery("Hihi"));

        return Ok(user);
    }
}
