using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Repositories;

public interface IAuthRepository
{
    Task<Officer?> GetOfficerByIdAsync(Guid officerId);
    Task<Officer?> GetOfficerWithRolesPrivilegesByEmailAsync(string email);
    Task<bool> IsOfficerExistsByEmailAsync(string email);
    // Add more here
}