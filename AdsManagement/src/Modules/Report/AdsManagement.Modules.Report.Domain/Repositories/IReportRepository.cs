namespace AdsManagement.Modules.Report.Domain.Repositories;

public interface IReportRepository
{
    Task<Entities.Report> CreateReport(Guid reporterId, int reportObjectId, string reportType, string content);
}