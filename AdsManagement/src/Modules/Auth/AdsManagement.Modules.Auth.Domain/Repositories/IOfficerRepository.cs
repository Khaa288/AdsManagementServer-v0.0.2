using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Repositories;

public interface IOfficerRepository
{
    Task<bool> IsOfficerExistsByEmailAsync(string email);
    Task<bool> IsOfficerExistsByIdAsync(Guid officerId);
    Task<Officer?> GetOfficerByEmailAsync(string email);
    Task<Officer?> GetOfficerByIdAsync(Guid officerId);
    Task<Officer?> GetOfficerWithRolesPrivilegesByEmailAsync(string email);
    
    Task<List<Officer>> GetAllOfficersAsync();
    Task<List<DistrictOfficer>> GetAllDistrictOfficerAsync();
    Task<List<DeptOfficer>> GetAllDeptOfficerAsync();
    
    Task CreateOfficerAsync(Officer officer);
    Task UpdateOfficerAsync(Officer officer);
    Task DeleteOfficerAsync(Officer officer);
}