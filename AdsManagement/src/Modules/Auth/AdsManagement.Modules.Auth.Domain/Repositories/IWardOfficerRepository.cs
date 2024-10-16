using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Repositories;

public interface IWardOfficerRepository
{
    Task<List<WardOfficer>> GetAllWardOfficerAsync();
    
    Task CreateOrUpdateWardOfficerAsync(WardOfficer officer);
    Task CreateWardOfficerAsync(WardOfficer officer);
    Task UpdateWardOfficerAsync(WardOfficer officer);
    Task DeleteDistrictOfficerAsync(WardOfficer officer);
}
