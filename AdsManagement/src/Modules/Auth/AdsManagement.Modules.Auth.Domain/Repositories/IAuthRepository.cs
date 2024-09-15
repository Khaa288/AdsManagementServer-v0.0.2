using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain;

public interface IAuthRepository
{
    Task<Officer?> GetByOfficerIdAsync(Guid officerId);
    
    // Add more here
}