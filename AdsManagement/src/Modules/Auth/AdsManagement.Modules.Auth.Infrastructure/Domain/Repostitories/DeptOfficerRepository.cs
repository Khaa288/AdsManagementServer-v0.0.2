using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Domain.Repositories;
using AdsManagement.Modules.Auth.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Repostitories;

public class DeptOfficerRepository : IDeptOfficerRepository
{
    private readonly AuthContext _authContext;

    public DeptOfficerRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }
    
    public async Task<List<DeptOfficer>> GetAllDeptOfficerAsync()
    {
        return await _authContext.DeptOfficers.ToListAsync();
    }

    public async Task<bool> IsDeptOfficerExistsByIdAsync(Guid deptOfficerId)
    {
        return await _authContext.DeptOfficers.AnyAsync(d => d.OfficerId == deptOfficerId);
    }

    public async Task CreateDeptOfficerAsync(DeptOfficer deptOfficer)
    {
        await _authContext.DeptOfficers.AddAsync(deptOfficer);
    }

    public Task UpdateDeptOfficerAsync(DeptOfficer deptOfficer)
    {
        _authContext.DeptOfficers.Update(deptOfficer);
        return Task.CompletedTask;
    }

    public Task DeleteDeptOfficerAsync(DeptOfficer deptOfficer)
    {
        _authContext.DeptOfficers.Remove(deptOfficer);
        return Task.CompletedTask;
    }
}