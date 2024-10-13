using AdsManagement.BuildingBlocks.Application.Files;
using AdsManagement.Modules.Report.Application.Configuration.Commands;
using AdsManagement.Modules.Report.Domain.Repositories;

namespace AdsManagement.Modules.Report.Application.Commands;

public class SendReportCommandHandler : ICommandHandler<SendReportCommand, SendReportResponse>
{
    private readonly IStorageService _storageService;
    private readonly IReportRepository _reportRepository;
    private readonly IReporterRepository _reporterRepository;
    private readonly IReportImageRepository _reportImageRepository;

    public SendReportCommandHandler(IStorageService storageService, IReporterRepository reporterRepository)
    {
        _storageService = storageService;
        _reporterRepository = reporterRepository;
    }

    public async Task<SendReportResponse> Handle(SendReportCommand request, CancellationToken cancellationToken)
    {
        var urls = await _storageService.UploadAsync(request.Images);

        await _reporterRepository.CreateReporter(request.ReporterName, request.ReporterEmail,
            request.ReporterPhoneNumber);
        
        return new SendReportResponse();
    }
}