using AdsManagement.Modules.Report.Domain.Entities;
using AdsManagement.Modules.Report.Domain.Repositories;
using AdsManagement.Modules.Report.Infrastructure.Database;

using Microsoft.EntityFrameworkCore;

namespace AdsManagement.Modules.Report.Infrastructure.Domain.Repositories;

public class ReportObjectRepository : IReportObjectRepository
{
    private readonly ReportContext _reportContext;

    public ReportObjectRepository(ReportContext reportContext)
    {
        _reportContext = reportContext;
    }

    public async Task<ReportObject?> GetReportObjectAsync(Guid objectId, string objectType)
    {
        return await _reportContext.ReportObjects
            .FirstOrDefaultAsync(ro => ro.ObjectId == objectId && ro.ObjectType == objectType);
    }
}