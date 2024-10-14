using AdsManagement.Modules.Report.Domain.Entities;
using AdsManagement.Modules.Report.Domain.Repositories;
using AdsManagement.Modules.Report.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AdsManagement.Modules.Report.Infrastructure.Domain.Repositories;

internal class ReporterRepository : IReporterRepository
{
    private readonly ReportContext _reportContext;

    public ReporterRepository(ReportContext reportContext)
    {
        _reportContext = reportContext;
    }

    public async Task<Reporter> CreateReporterAsync(string name, string email, string phoneNumber)
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

    public async Task<Reporter> CreateReporterIfNotExistAsync(string name, string email, string phoneNumber)
    {
        var reporter = await _reportContext.Reporters
            .FirstOrDefaultAsync(r => r.Name == name && r.Email == email && r.PhoneNumber == phoneNumber);
        
        if (reporter is not null)
        {
            return reporter;
        }

        var newReporter = new Reporter()
        {
            ReporterId = Guid.NewGuid(),
            Name = name,
            Email = email,
            PhoneNumber = phoneNumber
        };
        
        await _reportContext.Reporters.AddAsync(newReporter);
        return newReporter;
    }
}