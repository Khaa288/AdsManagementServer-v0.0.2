namespace AdsManagement.Modules.Auth.Domain.Entities;

public class DistrictOfficer : Officer
{
    public District District { get; set; }
    public int DistrictId { get; set; }
}