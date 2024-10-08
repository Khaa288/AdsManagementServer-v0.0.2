using AdsManagement.Modules.Report.Domain.Entities;

namespace AdsManagement.Modules.Report.Domain.Repositories;

public interface IReporterRepository
{
    Task<Reporter> CreateReporter(string name, string email, string phoneNumber);
}