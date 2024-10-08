using AdsManagement.API.Common;
using AdsManagement.Modules.Report.Application.Contracts;

using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AdsManagement.API.Modules.Report.Controllers;

[ApiVersion(ApiVersions.Version1)]
[ApiController]
[Route("api/v{version:apiVersion}/report")]
public class ReportController : ControllerBase
{
    private readonly IReportModule _reportModule;

    public ReportController(IReportModule reportModule)
    {
        _reportModule = reportModule;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendReport()
    {
        return Ok();
    }
}