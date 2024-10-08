using AdsManagement.Modules.Report.Domain.Repositories;

namespace AdsManagement.Modules.Report.Infrastructure.Domain.Repositories;

public class ReportRepository : IReportRepository
{
    public async Task<Report.Domain.Entities.Report> CreateReport(Guid reporterId, int reportObjectId, string reportType, string content)
    {
        throw new NotImplementedException();
    }
}