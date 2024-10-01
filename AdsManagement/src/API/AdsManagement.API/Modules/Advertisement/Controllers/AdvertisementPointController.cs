using System.Net;
using AdsManagement.API.Common;
using AdsManagement.API.Modules.Advertisement.Dtos;
using AdsManagement.Modules.Advertisement.Application.Contracts;
using AdsManagement.Modules.Advertisement.Application.Queries;
using Application.Queries.GetAdvertisementPointsPagin;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AdsManagement.API.Modules.Advertisement.Controllers;

[ApiVersion(ApiVersions.Version1)]
[ApiController]
[Route("api/v{version:apiVersion}/advertisement/point")]
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
        var points = await _advertisementModule.ExecuteQueryAsync(new GetAllAdvertisementPointsQuery());
        return Ok(new ApiResponse { StatusCode = HttpStatusCode.OK, Result = points });
    }
    
    [HttpGet("pagination")]
    public async Task<IActionResult> GetAdvertisementPointsPagin([FromQuery] AdvertisementPointQueryRequestDto request)
    {
        var points = await _advertisementModule
            .ExecuteQueryAsync(new GetAdvertisementPointsPaginQuery(
                request.PageNumber,
                request.PageSize,
                request.LocationType,
                request.AdvertisingForm,
                request.IsPlanned
            ));
        return Ok(new ApiResponse { StatusCode = HttpStatusCode.OK, Result = points });
    }
    
    [HttpGet("{pointId}")]
    public async Task<IActionResult> GetAdvertisementPointByPointId([FromRoute] Guid pointId)
    {
        var point = await _advertisementModule.ExecuteQueryAsync(new GetAdvertisementPointQuery(pointId));
        return Ok(new ApiResponse { StatusCode = HttpStatusCode.OK, Result = point });
    }
    
    [HttpGet("ward/{wardId}")]
    public async Task<IActionResult> GetAdvertisementPointByWardId([FromRoute] int wardId)
    {
        var points = await _advertisementModule.ExecuteQueryAsync(new GetWardAdvertisementPointsQuery(wardId));
        return Ok(new ApiResponse { StatusCode = HttpStatusCode.OK, Result = points });
    }
    
    [HttpGet("district/{districtId}")]
    public async Task<IActionResult> GetAdvertisementPointByDistrictId([FromRoute] int districtId)
    {
        var points = await _advertisementModule.ExecuteQueryAsync(new GetDistrictAdvertisementPointsQuery(districtId));
        return Ok(new ApiResponse { StatusCode = HttpStatusCode.OK, Result = points });
    }
}