using AdsManagement.BuildingBlocks.Application.Files;
using AdsManagement.Modules.Report.Application.Configuration.Commands;
using AdsManagement.Modules.Report.Domain.Repositories;

using AutoMapper;

namespace AdsManagement.Modules.Report.Application.Commands;

public class SendReportCommandHandler : ICommandHandler<SendReportCommand, SendReportResponse>
{
    private readonly IMapper _mapper;
    private readonly IStorageService _storageService;
    private readonly IReportRepository _reportRepository;
    private readonly IReporterRepository _reporterRepository;
    private readonly IReportImageRepository _reportImageRepository;
    private readonly IReportObjectRepository _reportObjectRepository;

    public SendReportCommandHandler(IMapper mapper, IStorageService storageService, IReportRepository reportRepository, IReporterRepository reporterRepository, IReportImageRepository reportImageRepository, IReportObjectRepository reportObjectRepository)
    {
        _mapper = mapper;
        _storageService = storageService;
        _reportRepository = reportRepository;
        _reporterRepository = reporterRepository;
        _reportImageRepository = reportImageRepository;
        _reportObjectRepository = reportObjectRepository;
    }

    public async Task<SendReportResponse> Handle(SendReportCommand request, CancellationToken cancellationToken)
    {
        var reportObject = await _reportObjectRepository
            .GetReportObjectAsync(request.ReportObjectId, request.ReportObjectType);
        
        var reporter = await _reporterRepository
            .CreateReporterIfNotExistAsync(request.ReporterName, request.ReporterEmail, request.ReporterPhoneNumber);
        
        var report = await _reportRepository
            .CreateReport(reporter.ReporterId, reportObject!.SurrogateKey, request.ReportType, request.Content);

        if (request.Images is not null && request.Images.Count > 0)
        {
            var reportImageUrls = await _storageService
                .UploadAsync(request.Images);
            await _reportImageRepository
                .AddReportImagesAsync(report.ReportId, reportImageUrls);
        }
        
        return _mapper.Map<SendReportResponse>(report);
    }
}