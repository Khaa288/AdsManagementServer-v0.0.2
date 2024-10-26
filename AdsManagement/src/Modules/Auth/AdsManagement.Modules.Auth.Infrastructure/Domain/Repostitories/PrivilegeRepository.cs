using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Domain.Repositories;
using AdsManagement.Modules.Auth.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Repostitories;

public class PrivilegeRepository : IPrivilegeRepository
{
    private readonly AuthContext _authContext;

    public PrivilegeRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }
    
    public async Task<List<Privilege>> GetAllPrivileges()
    {
        return await _authContext.Privileges.ToListAsync();
    }

    public async Task<Privilege?> GetPrivilegeByIdAsync(Guid privilegeId)
    {
        return await _authContext.Privileges.FindAsync(privilegeId);
    }

    public async Task<bool> IsPrivilegeExistsById(Guid privilegeId)
    {
        return await _authContext.Privileges.AnyAsync(p => p.PrivilegeId == privilegeId);
    }
}