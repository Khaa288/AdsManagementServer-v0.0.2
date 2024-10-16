using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Domain.Repositories;
using AdsManagement.Modules.Auth.Infrastructure.Database;
using MassTransit.Initializers;
using Microsoft.EntityFrameworkCore;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Repostitories;

public class RoleRepository : IRoleRepository
{
    private readonly AuthContext _authContext;

    public RoleRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }
    
    public async Task<List<Privilege>> GetPrivilegesByRoleId(Guid roleId)
    {
        return await _authContext.Roles
            .Select(r => r.RoleId == roleId)
            
    }

    public async Task<bool> IsPrivilegeExistsInRoleById(Guid privilegeId)
    {
        return await _authContext.Privileges.AnyAsync(p => p.PrivilegeId == privilegeId);
    }
}