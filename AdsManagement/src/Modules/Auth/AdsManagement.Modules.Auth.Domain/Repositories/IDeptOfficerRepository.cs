using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Repositories;

public interface IDeptOfficerRepository
{
    Task<List<DeptOfficer>> GetAllDeptOfficerAsync();
    Task<bool> IsDeptOfficerExistsByIdAsync(Guid deptOfficerId);
    Task CreateDeptOfficerAsync(DeptOfficer deptOfficer);
    Task UpdateDeptOfficerAsync(DeptOfficer deptOfficer);
    Task DeleteDeptOfficerAsync(DeptOfficer deptOfficer);
}
