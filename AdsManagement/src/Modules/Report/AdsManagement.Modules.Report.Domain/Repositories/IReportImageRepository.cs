namespace AdsManagement.Modules.Report.Domain.Repositories;

public interface IReportImageRepository
{
    Task<bool> AddReportImages(Guid reportId, List<string> urls);
}