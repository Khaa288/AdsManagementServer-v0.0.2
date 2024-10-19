using AdsManagement.API.Common;
using AdsManagement.API.Modules.Report.Dtos;
using AdsManagement.BuildingBlocks.Application.Common.Files;
using AdsManagement.Modules.Report.Application.Commands;
using AdsManagement.Modules.Report.Application.Contracts;
using AdsManagement.Modules.Report.Application.Queries;

using System.Net;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdsManagement.API.Modules.Report.Controllers;

[ApiVersion(ApiVersions.Version1)]
[ApiController]
[Route("api/v{version:apiVersion}/report")]
public class ReportController : ControllerBase
{
    private readonly IReportModule _reportModule;
    private readonly IMapper _mapper;

    public ReportController(IReportModule reportModule, IMapper mapper)
    {
        _reportModule = reportModule;
        _mapper = mapper;
    }
    
    [HttpPost("reporter")]
    public async Task<IActionResult> GetReporterAllReport([FromBody] GetReporterReportRequestDto request)
    {
        var reports = await _reportModule.ExecuteQueryAsync(new GetAllReportsQuery(
            request.Name,
            request.Email,
            request.PhoneNumber
        ));
        return Ok(new ApiResponse { StatusCode = HttpStatusCode.OK, Result = reports });
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendReport([FromForm] SendReportRequestDto request)
    {
        var report = await _reportModule.ExecuteCommandAsync(new SendReportCommand(
            request.ReporterName,
            request.ReporterEmail,
            request.ReporterPhoneNumber,
            request.ReportType,
            request.Content,
            request.ReportObjectId,
            request.ReportObjectType,
            _mapper.Map<ICollection<FileData>>(request.Images),
            request.ReCaptchaResponseToken
        ));
        
        return Ok(new ApiResponse { StatusCode = HttpStatusCode.OK, Result = report });
    }
}