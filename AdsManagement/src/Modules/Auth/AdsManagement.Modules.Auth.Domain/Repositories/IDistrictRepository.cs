namespace AdsManagement.Modules.Auth.Domain.Repositories;

public interface IDistrictRepository
{
    Task<bool> IsDistrictExistsByIdAsync(int districtId);
}