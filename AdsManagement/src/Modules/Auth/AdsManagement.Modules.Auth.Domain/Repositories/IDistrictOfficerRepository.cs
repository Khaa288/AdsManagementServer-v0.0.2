using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Repositories;

public interface IDistrictOfficerRepository
{
    Task<List<DistrictOfficer>> GetAllDistrictOfficerAsync();
    Task<bool> IsDistrictOfficerExistsByIdAsync(Guid districtOfficerId);
    Task CreateDistrictOfficerAsync(DistrictOfficer districtOfficer);
    Task UpdateDistrictOfficerAsync(DistrictOfficer districtOfficer);
    Task DeleteDistrictOfficerAsync(DistrictOfficer districtOfficer);
}
