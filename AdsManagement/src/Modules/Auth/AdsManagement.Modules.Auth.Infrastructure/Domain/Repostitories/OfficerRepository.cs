using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Domain.Repositories;
using AdsManagement.Modules.Auth.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Repostitories;

internal class OfficerRepository : IOfficerRepository
{
    private readonly AuthContext _authContext;

    public OfficerRepository(
        AuthContext authContext
    )
    {
        _authContext = authContext;
    }

    public async Task<bool> IsOfficerExistsByIdAsync(Guid officerId)
    {
        return await _authContext.Officers.AnyAsync(o => o.OfficerId == officerId);
    }

    public async Task<Officer?> GetOfficerByEmailAsync(string email)
    {
        return await _authContext.Officers.FirstOrDefaultAsync(e => e.Email == email);
    }

    public async Task<Officer?> GetOfficerByIdAsync(Guid officerId)
    {
        return await _authContext.Officers.FindAsync(officerId);
    }

    public async Task<bool> IsOfficerExistsByEmailAsync(string email)
    {
        return await _authContext.Officers.AnyAsync(o => o.Email == email);
    }

    public async Task<Officer?> GetOfficerWithRolesPrivilegesByEmailAsync(string email)
    {
        return await _authContext.Officers
            .Include(o => o.Role)
            .Include(o => o.Privileges)
            .FirstOrDefaultAsync(o => o.Email == email);
    }

    public async Task<List<Officer>> GetAllOfficersAsync()
    {
        return await _authContext.Officers.ToListAsync();
    }

    public async Task<List<DistrictOfficer>> GetAllDistrictOfficerAsync()
    {
        return await _authContext.DistrictOfficers.ToListAsync();
    }

    public async Task<List<DeptOfficer>> GetAllDeptOfficerAsync()
    {
        return await _authContext.DeptOfficers.ToListAsync();
    }

    public async Task CreateOfficerAsync(Officer officer)
    {
        await _authContext.Officers.AddAsync(officer);
    }

    public Task UpdateOfficerAsync(Officer officer)
    {
        _authContext.Officers.Update(officer);
        return Task.CompletedTask;
    }

    public Task DeleteOfficerAsync(Officer officer)
    {
        _authContext.Officers.Remove(officer);
        return Task.CompletedTask;
    }
}