using Application;
using AdsManagement.API.Common;
using AdsManagement.API.Configurations.Attributes;
using AdsManagement.API.Modules.Auth.Dtos;
using AdsManagement.Modules.Auth.Application.Contracts;
using AdsManagement.Modules.Auth.Application.Commands;
using System.Net;
using AdsManagement.BuildingBlocks.Application.Constraints.Constants;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdsManagement.API.Modules.Auth.Controllers;

[ApiVersion(ApiVersions.Version1)]
[ApiController]
[Route("api/v{version:apiVersion}/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthModule _authModule;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthController(
        IAuthModule authModule,
        IHttpContextAccessor httpContextAccessor)
    {
        _authModule = authModule;
        _httpContextAccessor = httpContextAccessor;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> GetAuthenticatedUser(LoginRequestDto request)
    {
        var token = await _authModule.ExecuteCommandAsync(new LoginCommand(request.Email, request.Password));
        
        return Ok(new ApiResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = token
        });
    }

    // [Authorize(Roles = RoleNames.DeptOfficer)]
    // [HasPrivilege(PrivilegeNames.CreateOfficers)]
    [HttpPost("create-officer")]
    public async Task<IActionResult> CreateOfficer(CreateOfficerRequestDto request)
    {
        await _authModule.ExecuteCommandAsync(new CreateOfficerCommand(
            request.Email,
            request.FullName,
            request.DoB,
            request.PhoneNumber,
            request.Password,
            request.RePassword,
            request.WardId,
            request.DistrictId,
            request.RoleId,
            request.Privileges));
        
        return Ok(new ApiResponse
        {
            StatusCode = HttpStatusCode.Created,
        });
    }
    
    // [Authorize]
    [HttpPost("token/refresh")]
    public async Task<IActionResult> CreateNewAccessToken()
    {
        string refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["refresh"];
        var newAccessToken =
            await _authModule.ExecuteCommandAsync(new CreateNewAccessTokenByRefreshTokenCommand(refreshToken));
        return Ok(new ApiResponse { StatusCode = HttpStatusCode.OK, Result = newAccessToken });
    }
    
    // [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout(LogoutRequestDto request)
    {
        await _authModule.ExecuteCommandAsync(new LogoutCommand(request.AccessToken));
        return Ok(new ApiResponse { StatusCode = HttpStatusCode.OK, Result = "Logged out successfully" });
    }
    
    // [Authorize]
    // [HttpPost("forgot-password")]
    // public async Task<IActionResult> RevokeToken(RevokeTokenRequestDto request)
    // {
    //     await _authModule.ExecuteCommandAsync(new RevokeTokenCommand(request.RefreshToken));
    //     return Ok(new ApiResponse { StatusCode = HttpStatusCode.OK, Message = "Token revoked successfully" });
    // }
}