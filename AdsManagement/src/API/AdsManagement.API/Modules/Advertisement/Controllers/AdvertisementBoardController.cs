using AdsManagement.API.Common;
using AdsManagement.Modules.Advertisement.Application.Contracts;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AdsManagement.API.Modules.Advertisement.Controllers;

[ApiVersion(ApiVersions.Version1)]
[ApiController]
[Route("api/v{version:apiVersion}/ads-board")]
public class AdvertisementBoardController : ControllerBase
{
    private readonly IAdvertisementModule _advertisementModule;

    public AdvertisementBoardController(IAdvertisementModule advertisementModule)
    {
        _advertisementModule = advertisementModule;
    }
    
    
}