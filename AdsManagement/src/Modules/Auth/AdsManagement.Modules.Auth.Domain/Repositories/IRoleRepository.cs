using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Repositories;

public interface IRoleRepository
{
    Task<List<Privilege>> GetPrivilegesByRoleId(Guid roleId);
    Task<Role> GetRoleByIdAsync(Guid roleId);
    Task<bool> IsRoleExistsByIdAsync(Guid roleId);
    Task<bool> IsPrivilegeExistsInRoleById(Guid privilegeId);
}