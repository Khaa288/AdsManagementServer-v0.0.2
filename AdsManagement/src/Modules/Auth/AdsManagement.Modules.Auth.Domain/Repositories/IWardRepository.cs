using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Repositories;

public interface IWardRepository
{
    Task<bool> IsWardExistsByIdAsync(int wardId);
    Task<Ward?> GetWardByIdAsync(int wardId);
}