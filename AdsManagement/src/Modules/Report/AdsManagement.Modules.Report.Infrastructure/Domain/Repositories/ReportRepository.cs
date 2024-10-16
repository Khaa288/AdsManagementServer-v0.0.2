using AdsManagement.Modules.Report.Domain.Repositories;
using AdsManagement.Modules.Report.Infrastructure.Database;

namespace AdsManagement.Modules.Report.Infrastructure.Domain.Repositories;

internal class ReportRepository : IReportRepository
{
    private readonly ReportContext _reportContext;

    public ReportRepository(ReportContext reportContext)
    {
        _reportContext = reportContext;
    }
    
    public async Task<Report.Domain.Entities.Report> CreateReport(Guid reporterId, int reportObjectId, string reportType, string content)
    {
        var report = new Report.Domain.Entities.Report()
        {
            ReportId = Guid.NewGuid(),
            ReportType = reportType,
            Content = content,
            Solution = "",
            Status = 1,
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            ReportObjectId = reportObjectId,
            ReporterId = reporterId
        };
        await _reportContext.AddAsync(report);
        return report;
    }
}