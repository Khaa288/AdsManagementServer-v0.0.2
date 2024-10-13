namespace AdsManagement.Modules.Report.Domain.Repositories;

public interface IReportImageRepository
{
    Task AddReportImagesAsync(Guid reportId, List<string> urls);
}