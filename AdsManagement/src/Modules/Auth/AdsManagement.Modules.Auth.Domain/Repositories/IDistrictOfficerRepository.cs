using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Repositories;

public interface IDistrictOfficerRepository
{
    Task<List<DistrictOfficer>> GetAllDistrictOfficerAsync();
    
    Task CreateOrUpdateDistrictOfficerAsync(DistrictOfficer officer);
    Task CreateDistrictOfficerAsync(DistrictOfficer officer);
    Task UpdateDistrictOfficerAsync(DistrictOfficer officer);
    Task DeleteDistrictOfficerAsync(DistrictOfficer officer);
}
