using AdsManagement.API.Common;
using AdsManagement.API.Configurations.Attributes;
using AdsManagement.API.Modules.Auth.Dtos;
using AdsManagement.Modules.Auth.Application.Contracts;
using Application;
using Application.Commands.Login;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdsManagement.API.Modules.Auth.Controllers;

[ApiVersion(ApiVersions.Version1)]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthModule _authModule;

    public AuthController(IAuthModule authModule)
    {
        _authModule = authModule;
    }

    [HttpPost("login")]
    public async Task<IActionResult> GetAuthenticatedUser(LoginRequestDto request)
    {
        var user = await _authModule.ExecuteCommandAsync(new LoginCommand(request.Email, request.Password));
        return Ok(user);
    }
    
    [Authorize]
    [HasPrivilege("Manage Usersss")]
    [HttpGet("authenticate")]
    public async Task<IActionResult> GetUser()
    {
        var user = await _authModule.ExecuteQueryAsync(new TestQuery("Hihi"));

        return Ok(user);
    }
}
