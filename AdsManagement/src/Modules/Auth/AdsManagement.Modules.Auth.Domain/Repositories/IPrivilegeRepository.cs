using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Repositories;

public interface IPrivilegeRepository
{
    Task<List<Privilege>> GetAllPrivileges();
    Task<Privilege?> GetPrivilegeByIdAsync(Guid privilegeId);
    Task<bool> IsPrivilegeExistsById(Guid privilegeId); 
}