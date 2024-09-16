using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain;

public interface IAuthRepository
{
    Task<Officer?> GetOfficerByIdAsync(Guid officerId);
    Task<Officer?> GetOfficerWithRolesPrivilegesByEmailAsync(string email);
    // Add more here
}