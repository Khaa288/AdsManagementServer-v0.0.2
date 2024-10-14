using AdsManagement.Modules.Report.Domain.Entities;

namespace AdsManagement.Modules.Report.Domain.Repositories;

public interface IReportObjectRepository
{
    Task<ReportObject?> GetReportObjectAsync(Guid objectId, string objectType);
}