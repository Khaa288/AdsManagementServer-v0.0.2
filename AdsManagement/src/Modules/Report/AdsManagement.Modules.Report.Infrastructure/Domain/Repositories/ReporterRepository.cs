using AdsManagement.Modules.Report.Domain.Entities;
using AdsManagement.Modules.Report.Domain.Repositories;
using AdsManagement.Modules.Report.Infrastructure.Database;

namespace AdsManagement.Modules.Report.Infrastructure.Domain.Repositories;

internal class ReporterRepository : IReporterRepository
{
    private readonly ReportContext _reportContext;

    public ReporterRepository(ReportContext reportContext)
    {
        _reportContext = reportContext;
    }

    public async Task<Reporter> CreateReporter(string name, string email, string phoneNumber)
    {
        var reporter = new Reporter()
        {
            ReporterId = Guid.NewGuid(),
            Name = name,
            Email = email,
            PhoneNumber = phoneNumber
        };

        await _reportContext.Reporters.AddAsync(reporter);
        return reporter;
    }
}