using AdsManagement.API.Common;
using AdsManagement.Modules.Report.Application.Contracts;

using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdsManagement.API.Modules.Report.Controllers;

[ApiVersion(ApiVersions.Version1)]
[ApiController]
[Route("api/v{version:apiVersion}/reporter")]
public class ReporterController : ControllerBase
{
    private readonly IReportModule _reportModule;
    private readonly IMapper _mapper;

    public ReporterController(IReportModule reportModule, IMapper mapper)
    {
        _reportModule = reportModule;
        _mapper = mapper;
    }

    [HttpGet("{reporterId}/report")]
    public async Task<IActionResult> GetReporterAllReport([FromRoute] Guid reporterId)
    {
        
        return Ok();
    }
}