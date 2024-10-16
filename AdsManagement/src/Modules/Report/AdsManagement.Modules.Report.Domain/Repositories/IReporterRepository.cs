using AdsManagement.Modules.Report.Domain.Entities;

namespace AdsManagement.Modules.Report.Domain.Repositories;

public interface IReporterRepository
{
    Task<Reporter> CreateReporterAsync(string name, string email, string phoneNumber);
    Task<Reporter> CreateReporterIfNotExistAsync(string name, string email, string phoneNumber);
}