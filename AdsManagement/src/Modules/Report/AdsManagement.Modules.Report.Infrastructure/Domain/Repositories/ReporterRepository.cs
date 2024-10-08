using AdsManagement.Modules.Report.Domain.Entities;
using AdsManagement.Modules.Report.Domain.Repositories;
using AdsManagement.Modules.Report.Infrastructure.Database;

namespace AdsManagement.Modules.Report.Infrastructure.Domain.Repositories;

public class ReporterRepository : IReporterRepository
{
    private readonly ReportContext _reportContext;

    public ReporterRepository(ReportContext reportContext)
    {
        _reportContext = reportContext;
    }

    public async Task<Reporter> CreateReporter(string name, string email, string phoneNumber)
    {
        var reporter = new Reporter();

        reporter.ReporterId = Guid.NewGuid();
        reporter.Name = name;
        reporter.Email = email;
        reporter.PhoneNumber = phoneNumber;

        await _reportContext.Reporters.AddAsync(reporter);

        return reporter;
    }
}