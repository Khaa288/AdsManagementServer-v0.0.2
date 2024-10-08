using AdsManagement.Modules.Report.Domain.Repositories;

namespace AdsManagement.Modules.Report.Infrastructure.Domain.Repositories;

public class ReportImageRepository : IReportImageRepository
{
    public async Task<bool> AddReportImages(Guid reportId, List<string> urls)
    {
        throw new NotImplementedException();
    }
}