using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Repositories;

public interface IWardOfficerRepository
{
    Task<List<WardOfficer>> GetAllWardOfficerAsync();
    Task<bool> IsWardOfficerExistsByIdAsync(Guid wardOfficerId);
    Task CreateWardOfficerAsync(WardOfficer wardOfficer);
    Task UpdateWardOfficerAsync(WardOfficer wardOfficer);
    Task DeleteWardOfficerAsync(WardOfficer wardOfficer);
}
