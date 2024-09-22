using AdsManagement.API.Common;
using AdsManagement.Modules.Advertisement.Application.Contracts;
using AdsManagement.Modules.Advertisement.Application.Queries;

using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AdsManagement.API.Modules.Advertisement.Controllers;

[ApiVersion(ApiVersions.Version1)]
[ApiController]
[Route("api/v{version:apiVersion}/ads-point")]
public class AdvertisementPointController : ControllerBase
{
    private readonly IAdvertisementModule _advertisementModule;

    public AdvertisementPointController(IAdvertisementModule advertisementModule)
    {
        _advertisementModule = advertisementModule;
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetAllAdvertisementPoints()
    {
        var user = await _advertisementModule.ExecuteQueryAsync(new GetAllAdvertisementPointsQuery());

        return Ok(user);
    }
}